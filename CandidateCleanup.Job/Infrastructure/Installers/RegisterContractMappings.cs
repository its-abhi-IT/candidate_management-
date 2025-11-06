namespace CandidateCleanup.Job.Infrastructure.Installers;
public class RegisterContractMappings : IServiceRegistration
{
    public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ApplicationDbContext>();
        services.AddScoped(typeof(IDbFactoryBase<>), typeof(DbFactoryBase<>));
    }
}
