using MineriaAlimentosCarnicos.Controllers.V1.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.Email
{
    public interface IEmailServices
    {
        /// <summary>
        /// Interfaz para el servicio de correos, no solo queda instanciado para mandar Html
        /// Es configurable para mandar cualquier tipo de correo
        /// </summary>
        /// <param name="message"></param>
        /// <param name="subject"></param>
        /// <param name="clients"></param>
        /// <param name="IsHtml"></param>
        /// <returns></returns>
        Task SendEmail(string message, string subject, int clients, bool IsHtml);
        Task ErrorMail(string message);
    }
}
