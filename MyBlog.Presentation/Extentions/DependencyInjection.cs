using AspNetCoreHero.ToastNotification;
using MyBlog.Infrastructure.AppContext;
using Microsoft.AspNetCore.Identity;

namespace MyBlog.Presentation.Extentions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddUIServices(this IServiceCollection services)
        {

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            services.AddNotyf(config =>
            {
                config.HasRippleEffect = true;
                config.DurationInSeconds = 5;
                config.Position = NotyfPosition.BottomRight;

            });
            return services;
        }
    }
}
