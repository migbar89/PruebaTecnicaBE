using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace PruebaTecnia.net7.Services;

public class MailServices : IMailServices
{
    IConfiguration _configuration;

    public MailServices(IConfiguration configuration)
    {
        this._configuration = configuration;

    }
    public Task SendEmailGmail(String email, String subject, String message)
    {

        var mail = _configuration["usuariogmail"];
        var pw = this._configuration["passwordgmail"];
        var port = Convert.ToInt32(_configuration["portGmail"]);
        var host = _configuration["hostGmail"];
        var client = new SmtpClient(host, port)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail, pw)
        };

        return client.SendMailAsync(new MailMessage(from: mail,
            to: email, subject, message));


    }
}