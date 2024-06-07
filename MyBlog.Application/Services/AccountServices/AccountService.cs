
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlog.Domain.Enums;
using System.Linq.Expressions;

namespace MyBlog.Applicationn.Services.AccountServices
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression)
        {
            return await _userManager.Users.AnyAsync(expression);
        }

        public async Task<IdentityResult> CreateUserAsync(IdentityUser user, Roles role)
        {
            var result = await _userManager.CreateAsync(user, "Password.1");
            if (!result.Succeeded)
            {
                return result;
            }
            return await _userManager.AddToRoleAsync(user, role.ToString());
        }


        public async Task<IdentityResult> DeleteUserAsync(string identityId)
        {
            var user = await _userManager.FindByIdAsync(identityId);
            if (user == null)
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "Kullanıcı Bulunamadı",
                    Description = "Kullanıcı Bulunamadı"
                });
            }
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityUser?> FindByIdAsync(string identityId)
        {
            return await _userManager.FindByIdAsync(identityId);
        }

        public async Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser identityUser)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(identityUser);
        }

        public async Task<Guid> GetUserIdAsync(string identityId, string role)
        {
            return Guid.NewGuid();
        }

        public async Task<IdentityResult> UpdateUserAsync(IdentityUser user)
        {
            var updatingUser = await _userManager.FindByIdAsync(user.Id);
            if (updatingUser == null)
            {
                return IdentityResult.Failed(new IdentityError()
                {
                    Code = "Güncellenecek User Bulunamadı",
                    Description = "Güncellenecek User Bulunamadı"
                });
            }
            return await _userManager.UpdateAsync(user);
        }
    }
}
