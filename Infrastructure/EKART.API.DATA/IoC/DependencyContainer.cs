using EKART.API.DATA.Context;
using EKART.API.DATA.Repositories.Authorization;
using EKART.API.DATA.Repositories.Categories;
using EKART.API.DATA.Repositories.Token;
using EKART.API.DATA.Repositories.User;
using EKART.API.DATA.Services;
using EKART.API.SERVICES.Services;
using EKART.USER.CORE.Repositories.Authorization;
using EKART.USER.CORE.Repositories.Categories;
using EKART.USER.CORE.Repositories.Token;
using EKART.USER.CORE.Repositories.UserDetails;
using EKART.USER.CORE.Services.Others;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace EKART.API.DATA.IoC
{
    public static class DependencyContainer
    {
        public static void ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EKartDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DbConnection")), ServiceLifetime.Scoped);
            services.AddScoped<IAuthorizeRepository, AuthorizeRepository>();
            services.AddScoped<ITokenGenerator, TokenService>();
            services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
            services.AddScoped<ITokenDetailsRepository, TokenDetailsRepository>();
            services.AddScoped<ICategoriesReadRepository, CategoryReadRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISessionContext, SessionContext>();
        }
    }

}