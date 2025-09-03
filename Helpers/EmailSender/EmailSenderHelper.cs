using Microsoft.Extensions.Options;

namespace Shoes_Ecommerce.Helpers.EmailSender
{
    public class EmailSenderHelper
    {
        private readonly EmailSettings _emailSettings;

        public EmailSenderHelper(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient(_emailSettings.Host)
            {
                Port = _emailSettings.Port,
                Credentials = new NetworkCredential(_emailSettings.EmailFrom, _emailSettings.Password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailSettings.EmailFrom, "Shoes Ecommerce"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}