using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories.AuthorRepositories
{
    public interface IAuthorRepository : IAsyncRepository, IAsyncInsertableRepository<Author>, IAsyncFindableRepository<Author>, IAsyncQueryableRepository<Author>, IAsyncDeletableRepository<Author>, IAsyncUpdatableRepository<Author>
    {
        Task<Author?> GetByIdentityId(string identityId);
    }
}
