using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineriaAlimentosCarnicos.Core.V1.Workers;

namespace MineriaAlimentosCarnicos.Installers.V1
{
    public class MinersInstaller : IInstaller
    {
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddSingleton<IMiners, Miners>();
        }
    }
}
