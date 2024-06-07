using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.AppContext;
using MyBlog.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories.ArticleRepositories
{
    public class ArticleRepository: EFBaseRepository<Article>,IArticleRepository
    {
        public ArticleRepository(AppDbContext context): base(context)
        {
                
        }
    }
}
