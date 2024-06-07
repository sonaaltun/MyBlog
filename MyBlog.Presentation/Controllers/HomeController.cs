using MyBlog.Applicationn.Services.ArticleServices;
using MyBlog.Applicationn.Services.SubjectServices;
using MyBlog.Presentation.Areas.Author.Models.SubjectVMs;
using MyBlog.Presentation.Models;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MyBlog.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleService _articleService;
        private readonly ISubjectService _subjectService;

        public HomeController(ILogger<HomeController> logger, IArticleService articleService, ISubjectService subjectService)
        {
            _logger = logger;
            _articleService = articleService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _articleService.GetAllAsync();
            var articleVMs = result.Data.Adapt<List<GuestArticleListVM>>();
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
               return View(articleVMs);
            }

            NotifiySuccess(result.Messages);
           return View(articleVMs);
        }
        [Authorize(Roles ="Author")]
        public async Task<IActionResult> IndexTop5()
        {
            var result = await _articleService.Top5GetAllAsync();
            var articleVMs = result.Data.Adapt<List<GuestArticleListVM>>();
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return View(articleVMs);
            }

            NotifiySuccess(result.Messages);
            return View(articleVMs);
        }

        public async Task<IActionResult>Read(Guid id)
        {
            var result = await _articleService.GetByIdAsync(id);
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return RedirectToAction("Index");
            }
            await _articleService.UpViewCountByArticleId(id);
            NotifiySuccess(result.Messages);
            return View(result.Data.Adapt<GuestArticleReadVM>());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> GetSubjects()
        {
            var result = await _subjectService.GetAllAsync();
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return View(result.Data.Adapt<List<SubjectListVM>>());
            }
            NotifiySuccess(result.Messages);
            return View(result.Data.Adapt<List<SubjectListVM>>());
        }

        public async Task<IActionResult> GetArticles(Guid id)
        {
            var result = await _articleService.GetAllBySubjectIdAsync(id);
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return View(result.Data.Adapt<List<GuestArticleListVM>>());
            }
            NotifiySuccess(result.Messages);
            return View(result.Data.Adapt<List<GuestArticleListVM>>());
        }

    }
}
