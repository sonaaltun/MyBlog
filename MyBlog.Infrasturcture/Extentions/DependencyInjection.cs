using MyBlog.Infrastructure.AppContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Infrastructure.Repositories.SubjectRepositories;
using MyBlog.Infrastructure.Repositories.AuthorRepositories;
using MyBlog.Infrastructure.Repositories.ArticleRepositories;

namespace MyBlog.Infrastructure.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(configuration.GetConnectionString(AppDbContext.DevConnectionString));
            });

            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            return services;
        }
    }
}
