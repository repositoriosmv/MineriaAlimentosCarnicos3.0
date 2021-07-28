using Microsoft.AspNetCore.Mvc;
using MineriaAlimentosCarnicos.Contracts.V1;
using MineriaAlimentosCarnicos.Controllers.V1.Response;
using MineriaAlimentosCarnicos.Core.V1.Workers;
using MineriaAlimentosCarnicos.Services.V1.MongoDB;
using MineriaAlimentosCarnicos.Services.V1.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Controllers.V1
{
    public class ExtraccionController : Controller
    {
        private readonly IMiners _miners;
        public ExtraccionController(IMiners miners)
        {
            _miners = miners;
        }


        // Localhost:PORT/api/v1/ExtraccionAnimalesPie
        [HttpGet(ApiRoutes.Extraccion.ExtraccionAnimalesPie)]
        public IActionResult ExtraccionAnimalesPie()
        {
            try
            {
                return Ok(_miners.GuardadoMongoDBAnimalesPie(_miners.ValidacionesAnimalesPie(_miners.ExtraccionAnimalesPie())));
            }
            catch (Exception)
            {
                return BadRequest("Internal Server Error");
            }

        }

        // Localhost:PORT/api/v1/ExtraccionBeneficio
        [HttpGet(ApiRoutes.Extraccion.ExtraccionBeneficio)]
        public IActionResult ExtraccionBeneficio()
        {
            try
            {
                return Ok(_miners.GuardadoMongoDBBeneficio(_miners.ValidacionesBeneficio(_miners.ExtraccionBeneficio())));
            }
            catch (Exception)
            {
                return BadRequest("Internal Server Error");
            }

        }


        /// <summary>
        /// CANALES NO SE UTILIZA EN ESTA APLICACION, PORQUE TIENE SU PROPIA API 
        /// </summary>
        /// <returns></returns>
        [HttpGet(ApiRoutes.Extraccion.ExtraccionCanales)]
        public IActionResult ExtraccionCanales()
        {
            try
            {
                return null;
            }
            catch (Exception)
            {
                return BadRequest("Internal Server Error");
            }

        }
    }
}
