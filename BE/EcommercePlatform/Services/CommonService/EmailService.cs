using MimeKit;
using MailKit.Net.Smtp;

namespace EcommercePlatform.Services.CommonService
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var emailMessage = new MimeKit.MimeMessage();
            emailMessage.From.Add(new MimeKit.MailboxAddress("Ecommerce Platform", _config["Email:From"]));
            emailMessage.To.Add(MimeKit.MailboxAddress.Parse(to));
            emailMessage.Subject = subject;
            emailMessage.Body = new MimeKit.TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = body
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync(_config["Email:SmtpHost"], int.Parse(_config["Email:SmtpPort"]), true);
            await client.AuthenticateAsync(_config["Email:Username"], _config["Email:Password"]);
            await client.SendAsync(emailMessage);
            await client.DisconnectAsync(true);
        }
    }
}
