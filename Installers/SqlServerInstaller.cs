using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MineriaAlimentosCarnicos.Services.V1.SqlServer;

namespace MineriaAlimentosCarnicos.Installers
{
    public class SqlServerInstaller : IInstaller
    {
        public void InstallServices(IConfiguration Configuration, IServiceCollection services)
        {
            // Version 1 (V1)
            services.AddSingleton<ISqlServicesAnimalesPie, SqlServicesAnimalesPie>();
            services.AddSingleton<ISqlServicesBeneficio, SqlServicesBeneficio>();
            services.AddSingleton<ISqlServerCanales, SqlServerCanales>();
        }
    }
}
