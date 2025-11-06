using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Core.Interface;

public interface IServiceRegistration
{
    void RegisterAppServices(IServiceCollection services, IConfiguration configuration);
}
