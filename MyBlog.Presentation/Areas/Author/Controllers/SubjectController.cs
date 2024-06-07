using MyBlog.Applicationn.DTOs.SubjectDTOs;
using MyBlog.Applicationn.Services.AuthorServices;
using MyBlog.Applicationn.Services.SubjectServices;
using MyBlog.Presentation.Areas.Author.Models.SubjectVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MyBlog.Presentation.Areas.Author.Controllers
{
    public class SubjectController : AuthorBaseController
    {
        private readonly ISubjectService _subjectService;
        private readonly IAuthorService _authorService;

        public SubjectController(ISubjectService subjectService, IAuthorService authorService)
        {
            _subjectService = subjectService;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
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

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SubjectCreateVM model)
        {
            if (ModelState.IsValid)
            {
                var result = await _subjectService.AddAsync(model.Adapt<SubjectCreateDTO>());
                if (!result.IsSuccess)
                {
                    NotifiyError(result.Messages);
                    return View(model);
                }
                NotifiySuccess(result.Messages);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _subjectService.DeleteAsync(id);
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return RedirectToAction("Index");
            }
            NotifiySuccess(result.Messages);
            return RedirectToAction("Index");
        }
    }
}
