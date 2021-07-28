using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MineriaAlimentosCarnicos.Contracts.V1;
using MineriaAlimentosCarnicos.Controllers.V1.Response;
using MineriaAlimentosCarnicos.Services.V1.SqlServer;
using MineriaAlimentosCarnicos.Services.V1.MongoDB;
using MongoDB.Bson;

namespace MineriaAlimentosCarnicos.Core.V1.Workers
{
    public class Miners : IMiners
    {
        private readonly ISqlServicesAnimalesPie _sqlServicesAnimalesPie;
        private readonly IMongoServices _mongoServices;
        private readonly ISqlServicesBeneficio _sqlServicesBeneficio;
        List<Idlote> IdloteIp;

        /// <summary>
        /// Extrae los datos de SQL y Guarda En MongoDB
        /// </summary>
        /// <param name="sqlServicesAnimalesPie"></param>
        /// <param name="mongoServices"></param>
        public Miners(ISqlServicesAnimalesPie sqlServicesAnimalesPie, IMongoServices mongoServices, ISqlServicesBeneficio sqlServicesBeneficio)
        {
            _sqlServicesAnimalesPie = sqlServicesAnimalesPie;
            _sqlServicesBeneficio = sqlServicesBeneficio;
            _mongoServices = mongoServices;
            IdloteIp = null;
        }

        #region ANIMALESPIE

        // Saca Los Datos de SQL y devuelve una Lista de Objetos del modelo de Animales en pie
        public List<AnimalesPieMongoDBModel> ExtraccionAnimalesPie()
        {
            // PASO 1
            try
            {
                // <EXTRACCION MANUAL> (AÑO/MES/DIA HORA:MINUTO:SEGUNDOS)                

                var SqlResponse = _sqlServicesAnimalesPie.GetAnimalesPieId(Convert.ToDateTime("2021-06-25 00:00:00"),
                                                                           Convert.ToDateTime("2021-06-25 23:59:59"));



                // <EXTRACCION PRODUCCION> (AÑO/MES/DIA HORA:MINUTO:SEGUNDOS)

                // Parametros definidos por Alimentos Carnicos
                //DateTime Fechainicio = Convert.ToDateTime($"{ DateTime.Now.AddHours(-30) }");
                //DateTime FechaFin = DateTime.Now;

                // Consulta los Idlote por rango de fecha 
                //var SqlResponse = _sqlServicesAnimalesPie.GetAnimalesPieId(Fechainicio, FechaFin);
                // Serializacion y Deserializacion de los datos en el modelo
                string Data = JsonConvert.SerializeObject(SqlResponse);
                IdloteIp = JsonConvert.DeserializeObject<List<Idlote>>(Data);


                if (IdloteIp is null)
                    return null;

                List<AnimalesPieMongoDBModel> ListaAnimalesPie = new List<AnimalesPieMongoDBModel>();
                // buscamos por cada uno de los id lote
                IdloteIp.ForEach(x => 
                {
                    var SqlResponseLotes = _sqlServicesAnimalesPie.GetAnimalesPie(x.IdLoteIP);
                    string Datos = JsonConvert.SerializeObject(SqlResponseLotes);
                    List<AnimalesPieMongoDBModel> AnimalesPieLote = JsonConvert.DeserializeObject<List<AnimalesPieMongoDBModel>>(Datos);

                    ListaAnimalesPie.AddRange(AnimalesPieLote);
                });
                


                if (ListaAnimalesPie is null)
                    return null;

                return ListaAnimalesPie;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                return null;
            }
        }

        // Valida y Actualiza Datos Existentes en MongoDB
        public List<AnimalesPieMongoDBModel> ValidacionesAnimalesPie(List<AnimalesPieMongoDBModel> Data)
        {
            try
            {
                // PASO 2

                    // VALIDA QUE LOS DATOS ESTEN NULOS
                if (Data is null)
                     return null;


                List<AnimalesPieMongoDBModel> PorCrear = new List<AnimalesPieMongoDBModel>();

                Data.ForEach(x =>
                {
                    
                    AnimalesPieMongoDBModel Check = _mongoServices.FindOne(x.IdLoteIP);
                    if (Check != null) 
                    {
                        // SI EL REGISTRO YA FUE GUARDADO EN MONGO db LO ACTUALIZA
                        _mongoServices.Update(x.IdLoteIP, x); 
                    }
                    else
                    { 
                        // SINO LO AÑADE A LA LISTA DE DOCUMETOS POR CREAR
                        PorCrear.Add(x);
                    }                       
                });

                return PorCrear;
            }
            catch (Exception Ex)
            {       
                Ex.Message.ToString();
                return null;
            }
        }

        // Guarda Los Datos Validados en Mongo DB
        public ExtraccionResponse GuardadoMongoDBAnimalesPie(List<AnimalesPieMongoDBModel> DataValidada)
        {
            try
            {
                // PASO 3

                // OBJETOS DE RESPUESTA JSON
                ExtraccionResponse NullResponse = new ExtraccionResponse()
                {
                    Message = "Internal Server Error",
                    Errors ="No llegaron datos al Servidor o Todo El Contenido Ya fue creado con Anterioridad",
                    Fecha = DateTime.Now.ToString(),
                };

                ExtraccionResponse Response = new ExtraccionResponse()
                {
                    Message = "Extraccion De Datos Animales en Pie Exitosa!",
                    Errors = null,
                    Fecha = DateTime.Now.ToString(),
                };

                if (DataValidada is null) 
                    // Mandar Mail
                    return NullResponse;               
                   // CREA EN MONGO DB UN DOCUMENTO POR CADA ELEMENTO DE LA LISTA
                DataValidada.ForEach(x =>
                {
                    _mongoServices.Create(x);
                });


                return Response;
            }
            catch (Exception Ex)
            {
                ExtraccionResponse ServerError = new ExtraccionResponse()
                {
                    Message = "Error Interno, Cuando La Data Llego A MongoDB",
                    Errors = Ex.Message.ToString(),
                    Fecha = null,
                };        
                return ServerError;
            }
        }

        #endregion

        #region BENEFICIO
        // Saca Los Datos de SQL y devuelve una Lista de Objetos del modelo de Beneficio
        public List<BeneficioMongoDBModel> ExtraccionBeneficio()
        {
            // PASO 1 EXTRACCION 
            try
            {

                // TRAE LOS ID DE LOTE
                // <MODO LOCAL>
                DateTime FechaInicio = Convert.ToDateTime("2021-07-24 21:00:00");           
                DateTime FechaFin = Convert.ToDateTime("2021-07-25 20:59:59");
                var SqlResponse = _sqlServicesBeneficio.GetBeneficioID(FechaInicio, FechaFin);

                // TRAE LOS ID DE LOTE
                // <MODO PRODUCCION>
                //var SqlResponse = _sqlServicesBeneficio.GetBeneficioID(DateTime.Now.AddHours(-30), DateTime.Now);

                // Serializacion y Deserializacion de los datos  par aguardarlos en un modelo de mongoDB
                var Data = JsonConvert.SerializeObject(SqlResponse);
                IdloteIp = JsonConvert.DeserializeObject<List<Idlote>>(Data);


                List<BeneficioMongoDBModel> Beneficios = new List<BeneficioMongoDBModel>();

                if (IdloteIp != null)
                {
                    IdloteIp.ForEach(X => 
                    { 
                        // POR CADA ID DE LOTE TRAE EJECUTA OTRO SP QUE YA TRAE LA INFORMACION
                        var LotesBeneficio = _sqlServicesBeneficio.GetBeneficioLotes(X.IdLoteIP);
                        var Datos = JsonConvert.SerializeObject(LotesBeneficio);
                        var Response = JsonConvert.DeserializeObject<List<BeneficioMongoDBModel>>(Datos);

                        Beneficios.AddRange(Response);
                    });
                }
                if (Beneficios is null)
                    return null;

                return Beneficios;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                return null;
            }
        }

        public List<BeneficioMongoDBModel> ValidacionesBeneficio(List<BeneficioMongoDBModel> Data)
        {
            // PASO 2 VALIDACIONES
            try
            {
                
                if (Data is null)
                    return null;
                List<BeneficioMongoDBModel> PorCrear = new List<BeneficioMongoDBModel>();
                // VALIDAR SI TIENE QUE ACTUALIZAR EL LOTE O CREARLO
                Data.ForEach(x =>
                {    
                    // BUSCAR EN MONGODB SI EL LOTE EXISTE
                    BeneficioMongoDBModel Check = _mongoServices.FindOneBeneficio(x.IdLoteIP);
                    if (Check != null)
                    {
                        // Validar completo  O incompleto para hacer update
                        x.Completo = ValidacionCompletos(x);

                        if (Check.Enviado == 1)
                            x.Enviado = 1;
                        else
                            x.Enviado = 0;

                        // Guardado de actualizaciones
                        _mongoServices.UpdateBeneficio(x.IdLoteIP, x);
                    }
                    else
                    {
                        x.Enviado = 0;
                        x.Completo = ValidacionCompletos(x);
                        PorCrear.Add(x);
                    }
                });
                return PorCrear;
            }
            catch (Exception Ex)
            {
                // Mandar Mail
                Ex.Message.ToString();
                return null;
            }
        }

        // LOGICA PARA LA VALIDACION DE COMPLETOS 
        private int ValidacionCompletos(BeneficioMongoDBModel Data)
        { 
            try
            {
                if (Data is null)
                    return 0;
                 //  suma los muertos antes de sacrificio y los animales inspeccionados
                 // para compararlos con la cantidad del lote, si coinciden devuelve un 1 que sigifica Completo
                 // sino devuelve un 0 para que siga buscando actualizaciones del lote
                int result = Data.MuertosCorrales + Data.MuertosCorralObservacion;
                if ((Data.TotalInspeccionados + result) == Data.CantidadLote)
                    return 1;

                return 0;
            }
            catch (Exception Ex)
            {
                // Mandar Mail
                Ex.Message.ToString();
                return 0;
            }
        }


        public ExtraccionResponse GuardadoMongoDBBeneficio(List<BeneficioMongoDBModel> DataValidada)
        {
            // PASO 3
            try
            {     
                // ESTRUCTURACION DE RESPUESTAS JSON
                ExtraccionResponse NullResponse = new ExtraccionResponse()
                {
                    Message = "Internal Server Error",
                    Errors = "No llegaron datos al Servidor o Todo El Contenido Ya fue creado con Anterioridad",
                    Fecha = DateTime.Now.ToString(),
                };

                ExtraccionResponse Response = new ExtraccionResponse()
                {
                    Message = "Extraccion De Datos Beneficio Exitosa!",
                    Errors = null,
                    Fecha = DateTime.Now.ToString(),
                };

                if (DataValidada is null)
                    return NullResponse;

                // CREA LOS DATOS EN MONGODB POR CADA LOTE QUE LLEGA
                DataValidada.ForEach(x =>
                {
                    _mongoServices.Create(x);
                });

                return Response;
            }
            catch (Exception Ex)
            {
                // Mandar Mail
                ExtraccionResponse Response = new ExtraccionResponse()
                {
                    Message = "Error Interno, Cuando La Data Llego A MongoDB",
                    Errors = Ex.Message.ToString(),
                    Fecha = null,
                };
                return Response;
            }
        }

        #endregion







    }
}
