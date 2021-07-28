using Microsoft.Extensions.Configuration;
using MineriaAlimentosCarnicos.Contracts.V1;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.MongoDB
{
    public class MongoServices : IMongoServices
    {
        /// <summary>
        /// Esta clase abre la conexión con MongoDB
        /// Debe incluir TOdos los metodos de la interfaz IMongoServices
        /// </summary>
        IMongoCollection<AnimalesPieMongoDBModel> AnimalesPie;
        IMongoCollection<BeneficioMongoDBModel> Beneficio;
        IMongoCollection<CanalesDespachadasMongoDBModel> Canales;
        private readonly IConfiguration _Configuration;
        public MongoServices(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public string Connnection()
        {
            try
            {              
                MongoClient client = new MongoClient(_Configuration.GetConnectionString("TramaAnimalesEnPie"));
                IMongoDatabase database = client.GetDatabase("LotesAlimentosCarnicos");
                AnimalesPie = database.GetCollection<AnimalesPieMongoDBModel>("AnimalesPie");
                Beneficio = database.GetCollection<BeneficioMongoDBModel>("Beneficio");
                Canales = database.GetCollection<CanalesDespachadasMongoDBModel>("Canales");
                return "Connection Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        #region CREATE

        // insertar en mongoDB los modelos de Animales en pie
        public IMongoCollection<AnimalesPieMongoDBModel> Create(AnimalesPieMongoDBModel data)
        {
            try
            {
                Connnection();
                AnimalesPie.InsertOne(data);
                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
        // Insertar en MOngoDB los modelos de Beneficio
        public IMongoCollection<BeneficioMongoDBModel> Create(BeneficioMongoDBModel data)
        {
            try
            {
                Connnection();
                Beneficio.InsertOne(data);
                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        // Insertar los modelos de canales en MongoDB
        public IMongoCollection<CanalesDespachadasMongoDBModel> Create(CanalesDespachadasMongoDBModel data)
        {
            try
            {
                Connnection();
                Canales.InsertOne(data);
                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
        #endregion

        #region UPDATE

        // Actualizar el modelo de Animales en pie en MOngoDB
        public IMongoCollection<AnimalesPieMongoDBModel> Update(int Id, AnimalesPieMongoDBModel data)
        {
            try
            {
                Connnection();

                var trama = AnimalesPie.Find(d => d.IdLoteIP == Id).FirstOrDefault();
                AnimalesPie.ReplaceOne(d => d.IdLoteIP == trama.IdLoteIP, data);

                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        // Actualizar el modelo de beneficio en MOngoDB
        public IMongoCollection<BeneficioMongoDBModel> UpdateBeneficio(int Id, BeneficioMongoDBModel data)
        {
            try
            {
                Connnection();

                var trama = Beneficio.Find(d => d.IdLoteIP == Id).FirstOrDefault();
                Beneficio.ReplaceOne(d => d.IdLoteIP == trama.IdLoteIP, data);

                return null;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
        #endregion

        #region FINDONE

        // busca por Id de lote en MOngoDB y trae la trama de Animales En pie
        public AnimalesPieMongoDBModel FindOne(int Id)
        {
            try
            {
                Connnection();
                return AnimalesPie.Find(d => d.IdLoteIP == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        // Busca por ID de lote en MOngoDB y trae la trama de Beneficio
        public BeneficioMongoDBModel FindOneBeneficio(int Id)
        {
            try
            {
                Connnection();
                return Beneficio.Find(d => d.IdLoteIP == Id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        // Trae por un ID de certificado SyT el modelo de las canales despachadas
        public CanalesDespachadasMongoDBModel FindOneCanales(int IdCerrtificadoSyT)
        {
            try
            {
                Connnection();
                return Canales.Find(d => d.IdCertificadoSyT == IdCerrtificadoSyT).FirstOrDefault();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
        #endregion

        #region FINDLIST

        // Busca la lsita de Modelos en MOngoDB de animalesPie por rango de fecha
        public List<AnimalesPieMongoDBModel> FindList(string filter)
        {
            try
            {
                Connnection();
                return AnimalesPie.Find(filter).ToList();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        // Busca la lista de Modelos en MOngoDB de beneficio por rango de fecha
        public List<BeneficioMongoDBModel> FindListBeneficio(string filter)
        {
            try
            {
                Connnection();
                return Beneficio.Find(filter).ToList();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }

        // busca la lista de certificados despachados por un rango de fechas
        public List<CanalesDespachadasMongoDBModel> FindListCanales(string filter)
        {
            try
            {
                Connnection();
                return Canales.Find(filter).ToList();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                throw;
            }
        }
        #endregion
    }
}
