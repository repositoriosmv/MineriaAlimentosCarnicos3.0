using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Services.V1.SqlServer
{
    public class SqlServicesAnimalesPie : ISqlServicesAnimalesPie
    {
        private readonly IConfiguration _configuration;
        public SqlServicesAnimalesPie(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        SqlConnection conn;

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



        public DataTable GetAnimalesPieId(DateTime FechaInicial, DateTime FechaFinal)
        {
            SqlCommand cmd;
            DataTable dt;
            SqlParameter[] param;
            try
            {
                Connection();
                param = new SqlParameter[2];

                param[0] = new SqlParameter("@FechaInicio", SqlDbType.DateTime)
                {
                    Value = FechaInicial
                };
                param[1] = new SqlParameter("@FechaFin", SqlDbType.DateTime)
                {
                    Value = FechaFinal
                };

                cmd = new SqlCommand("LogisticaAnimalesPieV2IdLotes", conn)             
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddRange(param);
                cmd.CommandTimeout = 250;

                dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
                 
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
            
            
        }

        public DataTable GetAnimalesPie(int IdLoteIP)
        {
            SqlCommand cmd;
            DataTable dt;
            SqlParameter[] param;
            try
            {
                Connection();
                param = new SqlParameter[1];

                param[0] = new SqlParameter("@IdLoteIP", SqlDbType.BigInt)
                {
                    Value = IdLoteIP
                };

                cmd = new SqlCommand("LogisticaAnimalesPieV2Lotes", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddRange(param);
                cmd.CommandTimeout = 250;

                dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }
        }
    }
}
