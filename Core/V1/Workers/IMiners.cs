using MineriaAlimentosCarnicos.Contracts.V1;
using MineriaAlimentosCarnicos.Controllers.V1.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Core.V1.Workers
{
    public interface IMiners
    {
        List<AnimalesPieMongoDBModel> ExtraccionAnimalesPie();
        List<AnimalesPieMongoDBModel> ValidacionesAnimalesPie(List<AnimalesPieMongoDBModel> Data);
        ExtraccionResponse GuardadoMongoDBAnimalesPie(List<AnimalesPieMongoDBModel> DataValidada);

        List<BeneficioMongoDBModel> ExtraccionBeneficio();
        List<BeneficioMongoDBModel> ValidacionesBeneficio(List<BeneficioMongoDBModel> Data);
        ExtraccionResponse GuardadoMongoDBBeneficio(List<BeneficioMongoDBModel> DataValidada);
    }
}
