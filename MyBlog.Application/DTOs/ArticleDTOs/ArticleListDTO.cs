using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.DTOs.ArticleDTOs
{
    public class ArticleListDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }       
        public byte[]? Image { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreadtedDate { get; set; }
        public TimeSpan ReadTime{ get; set; }

    }
}
