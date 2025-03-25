using RegisterLoginJWT.Interfaces;
using System.Net.Mail;

namespace RegisterLoginJWT.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string email)
        {
            var appPassword = "asdasd";

            var message = new MailMessage()
            {
                From = new MailAddress(email),
                Subject = "Test email",
                Body = "Test email",
                IsBodyHtml = false
            };


        }
    }
}
