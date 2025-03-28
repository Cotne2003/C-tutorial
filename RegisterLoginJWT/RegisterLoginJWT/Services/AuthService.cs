using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RegisterLoginJWT.Enums;
using RegisterLoginJWT.Interfaces;
using RegisterLoginJWT.Models;
using RegisterLoginJWT.Models.DTOS.Auth;
using RegisterLoginJWT.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RegisterLoginJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<int>> Register(UserRegisterDTO dto)
        {
            var response = new ServiceResponse<int>();
            if (await UserExists(dto.UserName))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            CreatePasswordHash(dto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                UserName = dto.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            await _context.users.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;
            return response;
        }
        public async Task<ServiceResponse<string>> Login(UserLoginDTO dto)
        {
            var response = new ServiceResponse<string>();

            var user = await _context.users.Include(x => x.Roles).FirstOrDefaultAsync(x => x.UserName.ToLower() == dto.UserName.ToLower());

            if (user != null && user.Status != Status.Active)
            {
                response.Success = false;
                response.Data = "User is not active please contact administrator";
                return response;
            }

            if (user is null)
            {
                response.Success = false;
                response.Message = HelperService.GetResourceValue("UserNotFound");
                return response;
            }
            else if (!VerifyPasswordHash(dto.Password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "User password is incorrect";
                return response;
            }
            else
            {
                var roleNames = user.Roles.Select(x => x.Name).ToList();
                var result = GenerateTokens(user, dto.StaySignedIn, roleNames);
                response.Data = result.Accesstoken;
                response.Success = true;
            }

            if (dto.StaySignedIn)
            {
                _context.users.Update(user);
                await _context.SaveChangesAsync();
            }

            return response;
        }

        #region PrivateMethods
        private async Task<bool> UserExists(string userName)
        {
            if (await _context.users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
                return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            using (var hmac = new HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                return computedHash.SequenceEqual(storedHash);
            }
        }

        private TokenDTO GenerateTokens(User user, bool staySignedIn, List<string>? roleNames)
        {
            string refreshToken = string.Empty;

            if (staySignedIn)
            {
                refreshToken = GenerateRefreshToken(user);
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpirationDate = DateTime.Now.AddDays(2);
            }
            var accessToken = GenerateAccessToken(user, roleNames);

            return new TokenDTO { Accesstoken = accessToken, RefreshToken = refreshToken };
        }

        private string GenerateAccessToken(User user, List<string>? roleNames)
        {
            //claims

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            if (claims != null)
                claims.AddRange(roleNames.Select(roleName => new Claim(ClaimTypes.Role, roleName)));
            // Key SymmetricSecurityKey

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWTOptions:Secret").Value ?? string.Empty));

            // Credentials

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Desscriptor SecurityTokenDescriptor

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials,
                Issuer = _configuration.GetSection("JWTOptions:Issuer").Value,
                Audience = _configuration.GetSection("JWTOptions:Audience").Value
            };

            // handler JwtSecurityTokenHandler

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // SecurityToken

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

        private string GenerateRefreshToken(User user)
        {
            //claims

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            // Key SymmetricSecurityKey

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JWTOptions:Secret").Value ?? string.Empty));

            // Credentials

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            // Desscriptor SecurityTokenDescriptor

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(2),
                SigningCredentials = credentials,
                Issuer = _configuration.GetSection("JWTOptions:Issuer").Value,
                Audience = _configuration.GetSection("JWTOptions:Audience").Value
            };

            // handler JwtSecurityTokenHandler

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            // SecurityToken

            SecurityToken token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
        #endregion
    }
}
