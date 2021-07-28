using MineriaAlimentosCarnicos.Contracts.V1;
using MineriaAlimentosCarnicos.Controllers.V1.Response;
using System;
using System.Collections.Generic;

namespace MineriaAlimentosCarnicos.Core.V1.Workers
{
    public interface IEmailSender
    {
        List<AnimalesPieMongoDBModel> GetDataFromMongoDB();
        EmailResponse SendEmail(List<AnimalesPieMongoDBModel> Data);
        List<BeneficioMongoDBModel> GetDataFromMongoDB(DateTime FechaInicial, DateTime FechaFinal);
        List<BeneficioMongoDBModel> GetNOEnviadosCompletos();
        EmailResponse SendEmail(List<BeneficioMongoDBModel> Data, List<BeneficioMongoDBModel> NoEnviadosCompletos);
    }
}
