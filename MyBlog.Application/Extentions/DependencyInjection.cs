using MyBlog.Applicationn.Services.AccountServices;
using MyBlog.Applicationn.Services.ArticleServices;
using MyBlog.Applicationn.Services.AuthorServices;
using MyBlog.Applicationn.Services.MailServices;
using MyBlog.Applicationn.Services.SubjectServices;
using Microsoft.Extensions.DependencyInjection;

namespace MyBlog.Applicationn.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<ISubjectService, SubjectService>();
            services.AddScoped<IArticleService, ArticleService>();

            return services;
        }
    }
}
