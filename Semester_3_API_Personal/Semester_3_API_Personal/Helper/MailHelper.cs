using System.Net.Mail;
using System.Net;

namespace Semester_3_API_Personal.Helper;

public class MailHelper
{
    private IConfiguration configuration;

    public MailHelper(IConfiguration _configuration)
    {
        configuration = _configuration;
    }

    public bool Send(string from, string to, string subject, string body)
    {
        try
        {
            var host = configuration["Gmail:Host"];
            var port = int.Parse(configuration["Gmail:Port"]);
            var username = configuration["Gmail:Username"];
            var password = configuration["Gmail:Password"];
            var enable = bool.Parse(configuration["Gmail:SMTP:starttls:enable"]);
            var smtpClient = new SmtpClient
            {
                Host = host,
                Port = port,
                EnableSsl = enable,
                Credentials = new NetworkCredential(username, password)
            };

            var mailMessage = new MailMessage(from, to);
            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);
            return true;
        }
        catch
        {
            return false;
        }
    }

}
