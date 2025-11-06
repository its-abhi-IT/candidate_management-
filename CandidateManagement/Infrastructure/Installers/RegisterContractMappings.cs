using Candidate.API.Contracts;
using Candidate.API.Data.DataManager;

namespace Candidate.API.Infrastructure.Installers;
public class RegisterContractMappings : IServiceRegistration
{
    public void RegisterAppServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, ApplicationDbContext>();
        services.AddScoped<ICandidateRepository, CandidateRepository>();
        services.AddScoped(typeof(IDbFactoryBase<>), typeof(DbFactoryBase<>));
    }
}
