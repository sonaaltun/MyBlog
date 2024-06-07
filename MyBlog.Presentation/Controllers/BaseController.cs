using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.Presentation.Controllers
{
    public class BaseController : Controller
    {
        protected INotyfService NotyfService => HttpContext.RequestServices.GetService(typeof(INotyfService)) as INotyfService;

        protected void NotifiySuccess(string message)
        {
            NotyfService.Success(message);
        }

        protected void NotifiyError(string message)
        {
            NotyfService.Error(message);
        }
        protected void NotifiyWarning(string message)
        {
            NotyfService.Warning(message);
        }


    }
}
