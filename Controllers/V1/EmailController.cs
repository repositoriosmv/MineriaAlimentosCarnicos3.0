using Microsoft.AspNetCore.Mvc;
using MineriaAlimentosCarnicos.Contracts.V1;
using MineriaAlimentosCarnicos.Core.V1.Workers;
using MineriaAlimentosCarnicos.Services.V1.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Controllers.V1
{
    public class EmailController : Controller
    {

        private IEmailSender _emailSender;
        private IEmailServices _emailServices;
        public EmailController(IEmailSender emailSender, IEmailServices emailServices)
        {
            _emailSender = emailSender;
            _emailServices = emailServices;
        }


        /// <summary>
        /// Este controlador envia los lotes que recibidos entre las 00:00 ddel presente dia
        /// hasta el 23:59 del presente dia
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.EnvioEmail.EnvioAnimalesPie)]
        public IActionResult SendEmailAnimalesPie()
        {
            try
            {
                return Ok(_emailSender.SendEmail(_emailSender.GetDataFromMongoDB()));
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return BadRequest("error");
            }
        }

        /// <summary>
        ///  Este Controlador Envia Las canales Beneficiadas Del rango de horarios
        ///  9 PM del Dia Anterior hasta las 12 del Medio dia Actual
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.EnvioEmail.EnvioBeneficio12PM)]
        public IActionResult SendEmailBeneficio12PM()
        {
            try
            {
                
                
                // Rango de fechas establecido por Alimentos Carnicos
                DateTime FechaInicio = Convert.ToDateTime($"{DateTime.Now.AddDays(-1).ToShortDateString()} 21:00:00");
                DateTime FechaFin = DateTime.Now;

                // la funcion Send Email (La primera de izquierda a derecha)  recibe dos parametros que son dos funciones
                // la primera  busca los lotes qeu esten en el rango de fechas
                
                // La segunda Busca Los lotes  que no fueron enviados en rangos de fechas anteriores y ya se pueden enviar (los que se completaron)
                return Ok(_emailSender.SendEmail(_emailSender.GetDataFromMongoDB(FechaInicio, FechaFin), _emailSender.GetNOEnviadosCompletos()));
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return BadRequest("error");
            }
        }

        [HttpGet(ApiRoutes.EnvioEmail.EnvioBeneficio9PM)]
        public IActionResult SendEmailBeneficio9PM()
        {
            try
            {
                DateTime FechaInicio = Convert.ToDateTime("2020-10-09 00:00:00");
                DateTime FechaFin = Convert.ToDateTime("2020-10-09 23:59:00");
                //DateTime FechaFin = Convert.ToDateTime("2020-10-09 10:00:00");
                //Rango de fechas Establecido popr Alimentos Carnicos
                //DateTime FechaInicio = Convert.ToDateTime($"{DateTime.Now.ToShortDateString()} 00:00:00");
                //DateTime FechaFin = DateTime.Now;

                // la funcion Send Email (La primera de izquierda a derecha)  recibe dos parametros que son dos funciones
                // la primera  busca los lotes qeu esten en el rango de fechas
                // La segunda Busca Los lotes  que no fueron enviados en rangos de fechas anteriores y ya se pueden enviar (los que se completaron)
                return Ok(_emailSender.SendEmail(_emailSender.GetDataFromMongoDB(FechaInicio, FechaFin), _emailSender.GetNOEnviadosCompletos()));
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return BadRequest("error");
            }
        }


        // ESTOS TRS CONTROLADORES NO SE UTILIZAN, ELLOS TIENEN SU PROPIA API
        [HttpGet(ApiRoutes.EnvioEmail.EnvioCanales4AM)]
        public IActionResult SendEmailCanalesCanales4AM()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return BadRequest("error");
            }
        }

        [HttpGet(ApiRoutes.EnvioEmail.EnvioCanales12PM)]
        public IActionResult SendEmailCanalesCanales12PM()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return BadRequest("error");
            }
        }

        [HttpGet(ApiRoutes.EnvioEmail.EnvioCanales4PM)]
        public IActionResult SendEmailCanalesCanales4PM()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return BadRequest("error");
            }
        }
    }
}
