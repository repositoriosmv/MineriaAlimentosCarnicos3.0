using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.SqlServer
{
    public interface ISqlServicesBeneficio
    {

        string Connection();
        DataTable GetBeneficioID(DateTime FechaInicial, DateTime FechaFinal);
        DataTable GetBeneficioLotes(int IdLoteIp);
    }
}

