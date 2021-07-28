using MineriaAlimentosCarnicos.Contracts.V1;
using MineriaAlimentosCarnicos.Controllers.V1.Response;
using MineriaAlimentosCarnicos.Controllers.V1.Request;
using MineriaAlimentosCarnicos.Core.V1.EmailTemplates;
using MineriaAlimentosCarnicos.Services.V1.Email;
using MineriaAlimentosCarnicos.Services.V1.MongoDB;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Core.V1.Workers
{
    public class EmailSender : IEmailSender
    {

        private readonly IMongoServices _mongoServices;
        private readonly IEmailServices _emailServices;
        private readonly IEmailBuilder _emailBuilder;

        public EmailSender(IMongoServices mongoServices, IEmailServices emailServices, IEmailBuilder emailBuilder)
        {
            _mongoServices = mongoServices;
            _emailServices = emailServices;
            _emailBuilder = emailBuilder;
        }

        #region ANIMALES PIE
        public List<AnimalesPieMongoDBModel> GetDataFromMongoDB()
        {
            try
            {
                // PASO 1

                // <MODO LOCAL>
                DateTime FechaInicial = Convert.ToDateTime("2021-06-25 00:00:00");
                DateTime FechaFinal = Convert.ToDateTime("2021-06-25 23:59:59");

                // <MODO PRODUCCION>
               // DateTime FechaInicial = Convert.ToDateTime($"{DateTime.Now.ToShortDateString()} 00:00:00");
                //DateTime FechaFinal = Convert.ToDateTime($"{DateTime.Now.ToShortDateString()} 23:59:59");
                var Filter = "{'FechaLlegadaPlanta':{ $gte: " + FechaInicial.ToJson() + ", $lt: " + FechaFinal.ToJson() + " }}";

                // CONSULTa TODOS LOS LOTES QEU HAY ENTRE EL RANGO DE FECHA
                List<AnimalesPieMongoDBModel> Response = _mongoServices.FindList(Filter);
                return Response;
            }
            catch(Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return null;
            }
        }

        public  EmailResponse SendEmail(List<AnimalesPieMongoDBModel> Data)
        {
            try
            {
                // PASO 2
                
                // CONSTRUYE LAS ESTADISTICAS DEL CORREO
                string Subject = "Información Alimentos Carnicos - Trama Animales en Pie";
                bool IsHtml = true;
                int Clientes = 1; // Equivale a la lista De correos para AnimalesPie En el servicio de envio de Emails
                _emailServices.SendEmail(_emailBuilder.EmailBuilderAnimalesPie(Data), Subject, Clientes, IsHtml);

                // RESPUESTA JSON EXITOSA
                EmailResponse Response = new EmailResponse()
                {
                    Message = "Emails Mandados Correctamente",
                    Errors = null,
                    Fecha = DateTime.Now.ToString()
                };
                return Response;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return null;
            }
        }
        #endregion

        #region SACRIFICIO
        public List<BeneficioMongoDBModel> GetDataFromMongoDB(DateTime FechaInicial, DateTime FechaFinal)
        {
            try
            {
                // PASO 1 OBSOLETO NO SE UTILIZA

                // CREA FILTRO
                var Filter = "{'FechaInicioInspeccionpostmortem':{ $gte: " + FechaInicial.ToJson() + ", $lt: " + FechaFinal.ToJson() + " }}";
                List<BeneficioMongoDBModel> Response = _mongoServices.FindListBeneficio(Filter); // BUSCA EN MONGODB
                return Response;
            }
            catch (Exception ex)
            {                
                string err = ex.Message.ToString();
                _emailServices.ErrorMail($"[Beneficio -GetDataFromMongoDB] {err}");
                return null;
            }
        }

        public List<BeneficioMongoDBModel> GetNOEnviadosCompletos()
        {
            try
            {
                // BUSCA EN LA BASE DE DATOS EN MONGO, LOS DOCUMENTOS QEU NUNCA HAN SIDO ENVIADOS
                var Filter = "{'Enviado':" + "" + 0 + "}";
                List<BeneficioMongoDBModel> Response = _mongoServices.FindListBeneficio(Filter);
                return Response;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail($"[Beneficio - GetNoEnviadosCompletos] {err}");
                return null;
            }
        }
        public EmailResponse SendEmail(List<BeneficioMongoDBModel> Data, List<BeneficioMongoDBModel> NoEnviadosCompletos)
        {
            try
            {
                // ARMA EL CORREO Y MANDA LOS DATOS AL HTML
                string Subject = "Trama Beneficio - lotes";
                bool IsHtml = true;
                int Clientes = 2; // Equivale a la lista De correos para BENEFICIO En el servicio de envio de Emails
                _emailServices.SendEmail(_emailBuilder.EmailBuilderBeneficio(Data, DateTime.Now, NoEnviadosCompletos), Subject, Clientes, IsHtml);

                EmailResponse Response = new EmailResponse()
                {
                    Message = "Emails Mandados Correctamente",
                    Errors = null,
                    Fecha = DateTime.Now.ToString()
                };
                return Response;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail($"[beneficio - SendMail] {err}");
                return null;
            }
        }

        #endregion
    }
}
