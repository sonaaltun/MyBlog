using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories.ArticleRepositories
{
    public interface IArticleRepository: IAsyncRepository, IAsyncInsertableRepository<Article>, IAsyncFindableRepository<Article>, IAsyncQueryableRepository<Article>, IAsyncDeletableRepository<Article>, IAsyncUpdatableRepository<Article>,IAsyncOrderableRepository<Article>
    {
    }
}
