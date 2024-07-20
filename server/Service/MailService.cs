using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using server.Interfaces;

namespace server.Service
{

    public class MailService : IMailService
    {
        private readonly IConfiguration _config;
        public MailService(IConfiguration config)
        {
            _config = config;
        }
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _config.GetSection("Smtp").Get<SmtpSettings>();

            using (var client = new SmtpClient(smtpSettings.Host, smtpSettings.Port))
            {
                client.EnableSsl = smtpSettings.EnableSsl;
                client.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(smtpSettings.Username),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                };

                mailMessage.To.Add(toEmail);

                await client.SendMailAsync(mailMessage);
            }
        }
    }

}
public class SmtpSettings
{
    public string Host { get; set; }
    public int Port { get; set; }
    public bool EnableSsl { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}