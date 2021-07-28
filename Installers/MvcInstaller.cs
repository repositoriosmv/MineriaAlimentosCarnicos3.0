using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MineriaAlimentosCarnicos.Installers
{
    public class MvcInstaller : IInstaller
    {

        /// <summary>
        ///  Instancia del servicio de MVC de Asp.Net Core 2.2
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="services"></param>
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
    }
}
