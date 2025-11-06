using Interview.API.Contracts;
using Interview.API.Data.DataManager;

namespace Interview.API.Infrastructure.Installers;
public class RegisterContractMappings : IServiceRegistration
{
    public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ApplicationDbContext>();
        services.AddScoped(typeof(IDbFactoryBase<>), typeof(DbFactoryBase<>));
        services.AddScoped<IInterviewRepository, InterviewRepository>();
    }
}
