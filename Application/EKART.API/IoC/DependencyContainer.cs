using EKART.API.DATA.IoC;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace EKART.API.IoC
{
    public static class DependencyContainer
    {

        public static void ConfigureApplication(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddMediatR(context => context.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddAutoMapper(typeof(DependencyContainer));
            services.ConfigureRepositories(configuration);
        }
    }
}
