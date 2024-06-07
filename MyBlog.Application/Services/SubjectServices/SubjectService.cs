using MyBlog.Applicationn.DTOs.SubjectDTOs;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Utilities.Concretes;
using MyBlog.Domain.Utilities.Interfaces;
using MyBlog.Infrastructure.Repositories.SubjectRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Applicationn.Services.SubjectServices
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public async Task<IDataResult<SubjectDTO>> AddAsync(SubjectCreateDTO subjectCreateDTO)
        {
            if (await _subjectRepository.AnyAsync(x=>x.Name.ToLower() == subjectCreateDTO.Name.ToLower()))
            {
                return new ErrorDataResult<SubjectDTO>("Konu Sistemde Kayıtlı");
            }
            var newSubject = subjectCreateDTO.Adapt<Subject>();
            await _subjectRepository.AddAsync(newSubject);
            await _subjectRepository.SaveChangesAsync();
            return new SuccessDataResult<SubjectDTO>(newSubject.Adapt<SubjectDTO>(), "Konu Ekleme Başarılı");
        }

        public async Task<IResult> DeleteAsync(Guid id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject is null)
            {
                return new ErrorResult("Silinecek Makale Bulunamadı");
            }
            await _subjectRepository.DeleteAsync(subject);
            await _subjectRepository.SaveChangesAsync();
            return new SuccessResult("Makale Silme Başarılı");
        }

        public async Task<IDataResult<List<SubjectListDTO>>> GetAllAsync()
        {
            var subjects = await _subjectRepository.GetAllAsync();
            if (subjects.Count() <= 0)
            {
                return new ErrorDataResult<List<SubjectListDTO>>(subjects.Adapt<List<SubjectListDTO>>(), "Listelenecek Konu Bulunmamakta");
            }

            return new SuccessDataResult<List<SubjectListDTO>>(subjects.Adapt<List<SubjectListDTO>>(), "Konu Listeleme Başarılı");
        }

        public Task<IDataResult<SubjectDTO>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<SubjectDTO>> UpdateAsync(SubjectUpdateDTO subjectUpdateDTO)
        {
            throw new NotImplementedException();
        }
    }
}
