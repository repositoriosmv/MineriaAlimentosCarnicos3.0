using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.SqlServer
{
    public interface ISqlServerCanales
    {
        string Connection();
        DataTable CanalesCertificado(int NroCertificadoSyT);
        DataTable CertificadosRangoFecha(DateTime StartDate, DateTime EndDate);
    }
}
