using MineriaAlimentosCarnicos.Contracts.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Core.V1.EmailTemplates
{
    public interface IEmailBuilder 
    {
        string EmailBuilderAnimalesPie(List<AnimalesPieMongoDBModel> Data);

        string EmailBuilderBeneficio(List<BeneficioMongoDBModel> Data, DateTime FechaBeneficio, List<BeneficioMongoDBModel> NoEnviadosCompletos);

        string EmailBuilderCanales(List<CanalesDespachadasMongoDBModel.CanalAC> Data);
    }
}
