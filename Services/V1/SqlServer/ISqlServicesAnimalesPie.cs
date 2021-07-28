using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.SqlServer
{
    public interface ISqlServicesAnimalesPie
    {
        string Connection();
        DataTable GetAnimalesPieId(DateTime FechaInicial, DateTime FechaFinal);
        DataTable GetAnimalesPie(int IdLoteIP);
    }
}
