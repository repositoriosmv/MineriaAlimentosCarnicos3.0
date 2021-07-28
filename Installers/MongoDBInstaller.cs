using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineriaAlimentosCarnicos.Services.V1.MongoDB;

namespace MineriaAlimentosCarnicos.Installers
{
    public class MongoDBInstaller : IInstaller
    {
        /// <summary>
        /// Instala los servicios de MongoDB por versiones Mediante Singleton
        /// Refiere a los Archivos en La carpeta Services/V1/MongoDB
        /// </summary>
        /// <param name="Configuration"></param>
        /// <param name="services"></param>
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            // Versión 1 (V1) 
            services.AddSingleton<IMongoServices, MongoServices>();

            // Versión 2 (V2)
        }
    }
}
