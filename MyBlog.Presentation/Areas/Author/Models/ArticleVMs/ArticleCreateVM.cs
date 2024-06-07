using MyBlog.Presentation.Extentions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyBlog.Presentation.Areas.Author.Models.ArticleVMs
{
    public class ArticleCreateVM
    {
        public string Title { get; set; }
        public string Content { get; set; }
        [MaxFileSizeAttribute(1024*512)]
        public IFormFile? NewImage { get; set; }       
        public Guid AuthorId { get; set; }
        public SelectList? Subjects { get; set; }
        public Guid SubjectId { get; set; }
    }
}
