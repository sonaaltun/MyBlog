using System.ComponentModel.DataAnnotations;

namespace MyBlog.Presentation.Models
{
    public class GuestArticleListVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public byte[]? Image { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        public int ViewCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreadtedDate { get; set; }
        public TimeSpan ReadTime { get; set; }
    }
}
