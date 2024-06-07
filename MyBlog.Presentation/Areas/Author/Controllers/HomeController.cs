using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Presentation.Areas.Author.Controllers
{
    public class HomeController : AuthorBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
