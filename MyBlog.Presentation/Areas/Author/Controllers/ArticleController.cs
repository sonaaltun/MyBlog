using MyBlog.Applicationn.DTOs.ArticleDTOs;
using MyBlog.Applicationn.Services.ArticleServices;
using MyBlog.Applicationn.Services.AuthorServices;
using MyBlog.Applicationn.Services.SubjectServices;
using MyBlog.Presentation.Areas.Author.Models.ArticleVMs;
using MyBlog.Presentation.Extentions;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MyBlog.Presentation.Areas.Author.Controllers
{
    public class ArticleController : AuthorBaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IArticleService _articleService;
        private readonly ISubjectService _subjectService;

        public ArticleController(IAuthorService authorService, IArticleService articleService, ISubjectService subjectService)
        {
            _authorService = authorService;
            _articleService = articleService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var authorId = await _authorService.GetAuthorIdByIdentityId(userId);
            var result = await _articleService.GetAllAsync(authorId);
            var articleListVms = result.Data.Adapt<List<ArticleListVM>>();
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return View(articleListVms);
            }
            NotifiySuccess(result.Messages);
            return View(articleListVms);
        }


        public async Task<IActionResult> Create()
        {
            var createVM = new ArticleCreateVM()
            {
                Subjects = await GetSubjects()
            };
            return View(createVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ArticleCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                model.Subjects = await GetSubjects();
                return View(model);
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var authorId = await _authorService.GetAuthorIdByIdentityId(userId);
            var articleCreateDto = model.Adapt<ArticleCreateDTO>();
            articleCreateDto.ReadTime = await model.Content.CalculeTimeForString();
            articleCreateDto.AuthorId = authorId;
            if (model.NewImage !=null && model.NewImage.Length>0)
            {
                articleCreateDto.Image = await model.NewImage.StringToByteArrayAsync();
            }
            var result = await _articleService.AddAsync(articleCreateDto);
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                model.Subjects = await GetSubjects();
                return View(model);
            }
            NotifiySuccess(result.Messages);
            return RedirectToAction("Index");

        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var authorId = await _authorService.GetAuthorIdByIdentityId(userId);
            var result = await _articleService.DeleteAsync(id,authorId);
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return RedirectToAction("Index");
            }
            NotifiySuccess(result.Messages);
            return RedirectToAction("Index");
        }

        private async Task<SelectList> GetSubjects(Guid? subjectId = null)
        {
            var subjects = (await _subjectService.GetAllAsync()).Data;
            return new SelectList(subjects.Select(src => new SelectListItem
            {
                Value = src.Id.ToString(),
                Text = src.Name,
                Selected = src.Id == (subjectId != null ? subjectId.Value : subjectId)
            }).OrderBy(x => x.Text), "Value", "Text");
        }
    }
}
