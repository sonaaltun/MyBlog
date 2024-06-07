namespace MyBlog.Presentation.Areas.Author.Models.ArticleVMs
{
    public class ArticleListVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public byte[]? Image { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
    }
}
