using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Controllers.V1.Response
{
    /// <summary>
    /// DTO Response  
    /// ExtraccionController V1
    /// Ruta Controllers/V1/ExtraccionCOntroller.cs
    /// </summary>
    public class ExtraccionResponse
    {
        public string Message { get; set; }
        public string Errors { get; set; }
        public string Fecha{ get; set; }
    }
}
