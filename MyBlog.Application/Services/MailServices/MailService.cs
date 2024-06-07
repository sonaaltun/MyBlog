using MyBlog.Applicationn.DTOs.MailDTOs;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.Services.MailServices
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(SendMailDTO sendMailDTO)
        {
            try
            {
                var newMail = new MimeMessage();
                newMail.From.Add(MailboxAddress.Parse("sonaaltun21@gmail.com"));
                newMail.To.Add(MailboxAddress.Parse(sendMailDTO.Email));
                newMail.Subject = sendMailDTO.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = sendMailDTO.Message;
                newMail.Body = builder.ToMessageBody();
                var smtp = new SmtpClient();
                await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync("sonaaltun21@gmail.com", "cdxnpzmoteprhkas");
                await smtp.SendAsync(newMail);
                await smtp.DisconnectAsync(true);

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException($"E-posta Gönderiminde bir hata oluştu: {ex.Message}");
            }
        }
    }
}
