using Humanizer.Bytes;

namespace MyBlog.Presentation.Models.ProfileVMs
{
    public class ProfileEditVM
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public IFormFile? NewImage { get; set; }
        public string Email { get; set; }
    }
}
