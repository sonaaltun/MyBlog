namespace MyBlog.Presentation.Models.ProfileVMs
{
    public class ProfileVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[]? Image { get; set; }
        public string Email { get; set; }
    }
}
