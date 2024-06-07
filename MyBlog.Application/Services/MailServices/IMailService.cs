using MyBlog.Applicationn.DTOs.MailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.Services.MailServices
{
    public interface IMailService
    {
        Task SendMailAsync(SendMailDTO sendMailDTO);
    }
}
