using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Installers
{
    public static class InstallerExtensions
    {

        /// <summary>
        /// Instala  e inicializa todas las extensiones del proyecto
        /// para instanciar cualquier archivo se debe utulizar la interfaz IInstaller
        /// Este archivo toda todas las configuraciones de las interfaces que se encuentras en la carpeta Installers
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            // Crea la lista de Dependencias para instsanciar
            var Installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                                            typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            // Activa una por una 
            Installers.ForEach(installer => installer.InstallServices(configuration, services));
        }
    }
}
