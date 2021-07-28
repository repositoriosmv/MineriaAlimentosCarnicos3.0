using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Contracts.V1
{
    public static class ApiRoutes
    {

        /// <summary>
        /// Rutas para la Ejecucion de Controllers
        /// Version 1
        /// Las siguientes rutas Se utilizan en Controllers/V1 
        /// En todos los controladores dentro de este folder
        /// </summary>
       
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Extraccion
        {
            // Extraccion de los tres modelos
            public const string ExtraccionAnimalesPie = Base + "/ExtraccionAnimalesPie"; 
            public const string ExtraccionBeneficio = Base + "/ExtraccionBeneficio";
            public const string ExtraccionCanales = Base + "/ExtraccionCanales"; // Aun no tiene funcionalidad
        }
        public static class EnvioEmail
        {
            // Envios Animales Pie
            public const string EnvioAnimalesPie = Base + "/EnvioEmailAnimalesPie"; // VA EN LAS TAREAS PROGRAMADAS

            // Envios Beneficio
            public const string EnvioBeneficio12PM = Base + "/EnvioEmailBeneficio12PM"; // VA EN LAS TAREAS PROGRAMADAS
            public const string EnvioBeneficio9PM = Base + "/EnvioEmailBeneficio9PM"; // VA EN LAS TAREAS PROGRAMADAS
            public const string EnvioBeneficio = Base + "/EnvioBeneficio";

            // Envios Canales Despachadas
            public const string EnvioCanales4AM = Base + "/EnvioEmailCanales4AM";
            public const string EnvioCanales12PM = Base + "/EnvioEmailCanales12PM";
            public const string EnvioCanales4PM = Base + "/EnvioEmailCanales4PM";
        }
    }
}
