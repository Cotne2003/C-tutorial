using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Interfaces;
using ProductManagementSystem.Models;
using ProductManagementSystem.Models.Entites;
using ProductManagementSystem.Policies.Handlers;
using ProductManagementSystem.Policies.Requirements;
using ProductManagementSystem.Services;

namespace ProductManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            //builder.Services.AddDefaultIdentity<ApplicationUser>().AddEntityFrameworkStores<ApplicationDbContext>();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Auth/AccessDenied";
            });


            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("TestPolicy", policy => policy.RequireClaim("TestClaim"));
                options.AddPolicy("FiveYearsEmployee", policy => policy.Requirements.Add(new FiveYearsRequirement(5)));
                options.AddPolicy("TsotnesPolicy", policy => policy.Requirements.Add(new TsotnesPageRequirement("Tsotne")));
            });

            builder.Services.AddScoped<IAuthorizationHandler, FiveYearsHandler>();
            builder.Services.AddScoped<IAuthorizationHandler, TsotnesPageHandler>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
