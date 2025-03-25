namespace RegisterLoginJWT.Interfaces
{
    public interface IEmailSender
    {
        public Task SendEmailAsync(string email);
    }
}
