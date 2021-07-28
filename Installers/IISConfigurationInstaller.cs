using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MineriaAlimentosCarnicos.Installers
{
    public class IISConfigurationInstaller : IInstaller
    {
        /// <summary>
        /// Configuración de las opciones del IIS para deploys
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="services"></param>
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            // IIS Configuration (Production - Deployment)
            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
                options.ForwardClientCertificate = false;
            });

        }
    }
}
