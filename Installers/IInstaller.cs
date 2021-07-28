using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MineriaAlimentosCarnicos.Installers
{

    /// <summary>
    ///  Interfaz para la funcion que se encarga de instalar los servicios
    ///  debe heredarse donde sea necesario crear un services.AddSingleton<Iemaplo, ejemplo>();
    /// </summary>
    public interface IInstaller
    {
        void InstallServices(IConfiguration Configuration, IServiceCollection services);
    }
}
