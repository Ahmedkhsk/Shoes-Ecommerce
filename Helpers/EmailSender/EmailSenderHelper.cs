namespace Shoes_Ecommerce.Helpers.EmailSender
{
    public class EmailSenderHelper
    {
        private readonly string _smtpServer = "";
        private readonly int _port = 0;
        private readonly string _emailFrom = "";
        private readonly string _password = "";

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var smtpClient = new SmtpClient(_smtpServer)
            {
                Port = _port,
                Credentials = new NetworkCredential(_emailFrom, _password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailFrom, "Shoes Ecommerce"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}