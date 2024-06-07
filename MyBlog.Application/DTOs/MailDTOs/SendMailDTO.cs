using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.DTOs.MailDTOs
{
    public class SendMailDTO
    {
        public string Message { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
    }
}
