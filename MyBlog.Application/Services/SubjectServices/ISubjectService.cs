using MyBlog.Applicationn.DTOs.SubjectDTOs;
using MyBlog.Domain.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.Services.SubjectServices
{
    public interface ISubjectService
    {
        Task<IDataResult<SubjectDTO>> AddAsync(SubjectCreateDTO subjectCreateDTO);
        Task<IDataResult<SubjectDTO>> UpdateAsync(SubjectUpdateDTO subjectUpdateDTO);
        Task<IDataResult<SubjectDTO>> GetByIdAsync(Guid id);
        Task<IResult> DeleteAsync(Guid id);
        Task<IDataResult<List<SubjectListDTO>>> GetAllAsync();
    }
}
