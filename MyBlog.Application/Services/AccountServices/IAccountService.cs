using MyBlog.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.Services.AccountServices
{
    public interface IAccountService
    {
        Task<bool> AnyAsync(Expression<Func<IdentityUser, bool>> expression);
        Task<IdentityUser?> FindByIdAsync(string identityId);
        Task<IdentityResult> CreateUserAsync(IdentityUser user, Roles role);
        Task<IdentityResult> DeleteUserAsync(string identityId);
        Task<Guid> GetUserIdAsync(string identityId, string role);
        Task<IdentityResult> UpdateUserAsync(IdentityUser user);
        Task<string> GenerateEmailConfirmationTokenAsync(IdentityUser identityUser);
    }
}
