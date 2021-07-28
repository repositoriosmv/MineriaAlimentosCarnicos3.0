using MineriaAlimentosCarnicos.Controllers.V1.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.Email
{
    public class EmailServices : IEmailServices
    {
        /// <summary>
        /// Función para el envio de correos 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="subject"></param>
        /// <param name="clients"></param>
        /// <param name="IsHtml"></param>
        /// <returns></returns>
        public async Task SendEmail(string message, string subject, int clients, bool IsHtml)
        {
            using (SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("soporte@infoporcinos.com", "!soporte142")
            })
            {
                string from = "soporte@infoporcinos.com";
                using (MailMessage sends = new MailMessage())
                {
                    sends.From = new MailAddress(from);
                    if (clients == 1)
                    {
                        // Lista Animales en Pie
                        //sends.To.Add("analista2@mercadeo-virtual.com");
                        sends.To.Add("pabolivar@mercadeo-virtual.com");
                        //sends.To.Add("corrales.porcinos@centralganadera.com");
                        //sends.To.Add("administrador.porcinos@centralganadera.com");
                        //sends.To.Add("coordinador.planeacion@centralganadera.com");

                    } else if(clients == 2)
                    {
                        sends.To.Add("pabolivar@mercadeo-virtual.com");
                        //sends.To.Add("analista4@infoporcinos.com");
                        // Lista Befenicio 
                        //sends.To.Add("analista2@mercadeo-virtual.com");
                        //sends.To.Add("pabolivar@mercadeo-virtual.com");
                        //sends.To.Add("administrador.porcinos@centralganadera.com");
                        //sends.To.Add("supervisor.porcinos@centralganadera.com");
                        //sends.To.Add("coordinador.planeacion@centralganadera.com");
                    }
                    else if(clients == 3)
                    {
                        // Lista Canales Despachadas
                       // sends.To.Add("analista2@mercadeo-virtual.com");
                        sends.To.Add("pabolivar@mercadeo-virtual.com");
                       // sends.To.Add("administrador.porcinos@centralganadera.com");
                       // sends.To.Add("frio.porcinos@centralganadera.com");
                       // sends.To.Add("coordinador.planeacion@centralganadera.com");
                    }
                    sends.Subject = subject;
                    sends.Body = message;
                    sends.IsBodyHtml = IsHtml;

                   await smtpClient.SendMailAsync(sends);
                }
            }
        }

        public async Task ErrorMail(string message)
        {
            using (SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new NetworkCredential("soporte@infoporcinos.com", "!soporte142")
            })
            {
                string from = "soporte@infoporcinos.com";
                using (MailMessage sends = new MailMessage())
                {
                    sends.From = new MailAddress(from);
 
                    //sends.To.Add("analista4@infoporcinos.com");
                    sends.To.Add("pabolivar@mercadeo-virtual.com");

                    sends.Subject = "Errores en Envios";
                    sends.Body = message;
                    sends.IsBodyHtml = false;

                    await smtpClient.SendMailAsync(sends);
                }
            }
        }
    }
}
