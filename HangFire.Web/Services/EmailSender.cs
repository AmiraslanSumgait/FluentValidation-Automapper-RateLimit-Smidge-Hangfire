using SendGrid;
using SendGrid.Helpers.Mail;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Sender(string userId, string message)
        {
            //bu userId ye sahib istifadecinin email adresini tap
            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("emiraslaneliyev45@gmail.com","Example User");
            var subject = "www.mysite.com bilgilendirme";
            var to = new EmailAddress("emiraslaneliyev12@gmail.com", "Example User");
            //  var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = $"<strong>{message}</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            await client.SendEmailAsync(msg);
        }
    }
}
