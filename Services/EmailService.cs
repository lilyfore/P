using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace P.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string name, string email, string message)
        {
            var smtpSettings = _config.GetSection("SmtpSettings");
            var smtpClient = new SmtpClient(smtpSettings["Host"], int.Parse(smtpSettings["Port"]))
            {
                Credentials = new NetworkCredential(smtpSettings["User"], smtpSettings["Password"]),
                EnableSsl = bool.Parse(smtpSettings["EnableSsl"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpSettings["User"]),
                Subject = $"Portfolio Contact from {name}",
                Body = $"Name: {name}\nEmail: {email}\n\n{message}",
                IsBodyHtml = false,
            };

            mailMessage.To.Add(smtpSettings["User"]); // Sends the email to yourself

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
