using CandidateManagement.Core.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CandidateManagement.Core.Extensions;

public static class ServiceRegistrationExtension
{
    public static void AddServicesInAssembly(this IServiceCollection services, IConfiguration configuration, Type type)
    {
        var appServices = type.Assembly.DefinedTypes
                        .Where(x => typeof(IServiceRegistration)
                        .IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                        .Select(Activator.CreateInstance)
                        .Cast<IServiceRegistration>().ToList();

        appServices.ForEach(svc => svc.RegisterAppServices(services, configuration));
    }
}
