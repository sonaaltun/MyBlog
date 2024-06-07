using MyBlog.Domain.Entities;
using MyBlog.Infrastructure.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Repositories.SubjectRepositories
{
    public interface ISubjectRepository: IAsyncRepository, IAsyncInsertableRepository<Subject>, IAsyncFindableRepository<Subject>, IAsyncQueryableRepository<Subject>, IAsyncDeletableRepository<Subject>, IAsyncUpdatableRepository<Subject>
    {
    }
}
