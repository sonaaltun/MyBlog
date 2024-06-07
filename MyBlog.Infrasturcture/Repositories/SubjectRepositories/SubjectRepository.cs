using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.AppContext;
using MyBlog.Infrastructure.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories.SubjectRepositories
{
    public class SubjectRepository : EFBaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
