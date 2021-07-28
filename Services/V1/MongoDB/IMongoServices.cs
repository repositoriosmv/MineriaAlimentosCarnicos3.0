using MineriaAlimentosCarnicos.Contracts.V1;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MineriaAlimentosCarnicos.Services.V1.MongoDB
{
    /// <summary>
    /// MongoDB Services Interface Version 1
    /// </summary>
    public interface IMongoServices
    {
        string Connnection();
        AnimalesPieMongoDBModel FindOne(int Id);
        BeneficioMongoDBModel FindOneBeneficio(int Id);
        CanalesDespachadasMongoDBModel FindOneCanales(int IdCerrtificadoSyT);

        List<AnimalesPieMongoDBModel> FindList(string filter);
        List<BeneficioMongoDBModel> FindListBeneficio(string filter);
        List<CanalesDespachadasMongoDBModel> FindListCanales(string filter);

        IMongoCollection<AnimalesPieMongoDBModel> Create(AnimalesPieMongoDBModel data);
        IMongoCollection<BeneficioMongoDBModel> Create(BeneficioMongoDBModel data);
        IMongoCollection<CanalesDespachadasMongoDBModel> Create(CanalesDespachadasMongoDBModel data);

        IMongoCollection<AnimalesPieMongoDBModel> Update(int Id, AnimalesPieMongoDBModel data);
        IMongoCollection<BeneficioMongoDBModel> UpdateBeneficio(int Id, BeneficioMongoDBModel data);

    }
}
