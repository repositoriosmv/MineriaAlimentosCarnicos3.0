using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineriaAlimentosCarnicos.Core.V1.EmailTemplates;
using MineriaAlimentosCarnicos.Core.V1.Workers;
using MineriaAlimentosCarnicos.Services.V1.Email;

namespace MineriaAlimentosCarnicos.Installers
{
    public class EmailsInstallers : IInstaller
    {
        /// <summary>
        /// Instalador del Servicio de Envios de Correos
        /// Refiere los archivos  en la carpeta Services/V1/Email
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="services"></param>
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            // Versión 1 (V1)
            services.AddSingleton<IEmailServices, EmailServices>();
            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IEmailBuilder, EmailBuilder>();
            // Versión 2 (V2)
        }

    }
}
