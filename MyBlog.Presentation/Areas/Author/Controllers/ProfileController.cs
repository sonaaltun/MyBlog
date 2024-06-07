
using MyBlog.Presentation.Extentions;
using MyBlog.Presentation.Models.ProfileVMs;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using MyBlog.Applicationn.Services.AuthorServices;
using MyBlog.Applicationn.Services.AccountServices;
using MyBlog.Applicationn.DTOs.AuthorDTOs;

namespace MyBlog.Presentation.Areas.Author.Controllers
{
    public class ProfileController : AuthorBaseController
    {
        private readonly IAuthorService _authorService;
        private readonly IAccountService _accountService;

        public ProfileController(IAuthorService authorService, IAccountService accountService)
        {
            _authorService = authorService;
            _accountService = accountService;
        }


        public async Task<IActionResult> ProfileEdit(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var profileUserId = await _authorService.GetAuthorIdByIdentityId(userId);
            var result = await _authorService.GetByIdAsync(profileUserId);
            if (!result.IsSuccess)
            {
                NotifiyError(result.Messages);
                return RedirectToAction("Profile");
            }
            NotifiySuccess(result.Messages);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(ProfileEditVM model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _accountService.FindByIdAsync(userId);
            user.Email = model.Email;
            user.UserName = model.Email;
            var identituResult = await _accountService.UpdateUserAsync(user);
            var authorId = await _authorService.GetAuthorIdByIdentityId(userId);
            var result = await _authorService.GetByIdAsync(authorId);
            if (identituResult.Succeeded)
            {
                model.Id = result.Data.Adapt<ProfileEditVM>().Id;
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var authorUpdateDto = model.Adapt<AuthorUpdateDTO>();

                if (model.NewImage != null && model.NewImage.Length > 0)
                {
                    authorUpdateDto.Image = await model.NewImage.StringToByteArrayAsync();
                }
                else
                {
                    authorUpdateDto.Image = result.Data.Adapt<AuthorUpdateDTO>().Image;
                }

                var result2 = await _authorService.UpdateAsync(authorUpdateDto);
                if (!result2.IsSuccess)
                {
                    model.Image = result.Data.Adapt<ProfileEditVM>().Image;
                    NotifiyError(result2.Messages);
                    return View(model);
                }

                NotifiySuccess(result2.Messages);
                return RedirectToAction("Profile"); 
            }
            model.Image = result.Data.Adapt<ProfileEditVM>().Image;
                NotifiyError("Bu Mail Adresi Kullanılıyor");
            return View(model);
            
        }
    }
}
