using MyBlog.Applicationn.DTOs.ArticleDTOs;
using MyBlog.Domain.Entities;
using MyBlog.Domain.Utilities.Concretes;
using MyBlog.Domain.Utilities.Interfaces;
using MyBlog.Infrastructure.Repositories.ArticleRepositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.Applicationn;

namespace MyBlog.Applicationn.Services.ArticleServices
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<IDataResult<ArticleDTO>> AddAsync(ArticleCreateDTO articleCreateDTO)
        {
            var newArticle = articleCreateDTO.Adapt<Article>();
            try
            {
                await _articleRepository.AddAsync(newArticle);
                await _articleRepository.SaveChangesAsync();
                return new SuccessDataResult<ArticleDTO>(newArticle.Adapt<ArticleDTO>(), Messages.Added_Succes);
            }
            catch (Exception)
            {

                return new ErrorDataResult<ArticleDTO>(newArticle.Adapt<ArticleDTO>(), Messages.Added_Fail);
            }
        }

        public async Task<IResult> DeleteAsync(Guid id, Guid authorId)
        {
            var article = await _articleRepository.GetByIdAsync(id);
            if (article.AuthorId != authorId)
            {
                return new ErrorResult("Bu Makaleyi Silme Yetkin Yok");
            }
            if (article is null)
            {
                return new ErrorResult("Silinecek Makale Bulunamadı");
            }
            await _articleRepository.DeleteAsync(article);
            await _articleRepository.SaveChangesAsync();
            return new SuccessResult("Makale Silme Başarılı");
        }

        public async Task<IDataResult<List<ArticleListDTO>>> GetAllAsync()
        {
            var articles = await _articleRepository.GetAllAsync(x=>x.CreadtedDate,true);
            if (articles.Count() <= 0)
            {
                return new ErrorDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Listelenecek Makale Bulunamadı");
            }
            return new SuccessDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Makele Listeleme Başarılı");
        }

        public async Task<IDataResult<List<ArticleListDTO>>> GetAllAsync(Guid authorId)
        {
            var articles = await _articleRepository.GetAllAsync(x => x.AuthorId == authorId);
            if (articles.Count() <= 0)
            {
                return new ErrorDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Listelenecek Makale Bulunamadı");
            }
            return new SuccessDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Makele Listeleme Başarılı");
        }

        public async Task<IDataResult<List<ArticleListDTO>>> GetAllBySubjectIdAsync(Guid subjectId)
        {
            var articles = await _articleRepository.GetAllAsync(x => x.SubjectId == subjectId);
            if (articles.Count() <= 0)
            {
                return new ErrorDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Listelenecek Makale Bulunamadı");
            }
            return new SuccessDataResult<List<ArticleListDTO>>(articles.Adapt<List<ArticleListDTO>>(), "Makele Listeleme Başarılı");

        }

        public async Task<IDataResult<ArticleDTO>> GetByIdAsync(Guid id)
        {
           var article = await _articleRepository.GetByIdAsync(id);
            if (article is null)
            {
                return new ErrorDataResult<ArticleDTO>(article.Adapt<ArticleDTO>(), "Detay Görüntüleme Başarısız");
            }
                return new SuccessDataResult<ArticleDTO>(article.Adapt<ArticleDTO>(), "Detay Görüntüleme Başarılı");

        }

        public async Task<IDataResult<List<ArticleListDTO>>> Top5GetAllAsync()
        {
            var result = (await _articleRepository.GetAllAsync(x=>x.ViewCount,true)).Take(5);
            return new SuccessDataResult<List<ArticleListDTO>>(result.Adapt<List<ArticleListDTO>>(), $"En çok okunan {result.Count()} makale listleendi");
        }

        public async Task UpViewCountByArticleId(Guid articleId)
        {
            var article = await _articleRepository.GetByIdAsync(articleId);
            article.ViewCount++;
            await _articleRepository.UpdateAsync(article);
            await _articleRepository.SaveChangesAsync();
        }
    }
}
