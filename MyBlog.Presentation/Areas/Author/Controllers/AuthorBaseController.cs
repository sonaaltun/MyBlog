using MyBlog.Presentation.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Presentation.Areas.Author.Controllers
{
    [Area("Author")]
    [Authorize(Roles ="Author")]
    public class AuthorBaseController : BaseController
    {
        
    }
}
