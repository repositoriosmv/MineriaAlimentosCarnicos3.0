using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.SqlServer
{
    public class SqlServerCanales : ISqlServerCanales
    {

        private readonly IConfiguration _configuration;
        SqlConnection conn;
        SqlCommand cmd;
        SqlParameter[] param;
        SqlDataAdapter da;
        DataTable dt;
        public SqlServerCanales(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public string Connection()
        {
            try
            {
                // la conexión esta leyendo los datos de appsettings.json
                conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("Infoporcinos").Value);
                conn.Open();
                return "Connection Success!";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }


        // Get Data
        public DataTable CanalesCertificado(int NroCertificadoSyT)
        {
            try
            {
                Connection();

                //param = new SqlParameter[1];
                //param[0] = new SqlParameter("@IdCertificadoSyT", SqlDbType.BigInt)
                //{
                //    Value = NroCertificadoSyT
                //};

                cmd = new SqlCommand("LogisticaCanales", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@IdCertificadoSyT", NroCertificadoSyT);

                dt = new DataTable();
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                conn.Close();

                return dt;
            }
            catch (Exception Ex)
            {
                Ex.Message.ToString();
                return null;
                throw;
            }
        }

        // Get Certificados
        public DataTable CertificadosRangoFecha(DateTime StartDate, DateTime EndDate)
        {
            Connection();

            param = new SqlParameter[2];

            param[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime)
            {
                Value = StartDate
            };

            param[1] = new SqlParameter("@FechaFin", SqlDbType.DateTime)
            {
                Value = EndDate
            };

            cmd = new SqlCommand("LogisticaCertificadosSyT", conn)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddRange(param);

            dt = new DataTable();
            da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            conn.Close();

            return dt;
        }
    }
}
