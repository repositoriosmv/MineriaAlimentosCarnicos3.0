using System;
using System.Text;
using System.Collections.Generic;
using MineriaAlimentosCarnicos.Contracts.V1;
using System.Linq;
using MineriaAlimentosCarnicos.Services.V1.MongoDB;
using MineriaAlimentosCarnicos.Services.V1.Email;

namespace MineriaAlimentosCarnicos.Core.V1.EmailTemplates
{
    public class EmailBuilder : IEmailBuilder
    {
        private readonly IMongoServices _mongoServices;
        private readonly IEmailServices _emailServices;
        public EmailBuilder(IMongoServices mongoServices, IEmailServices emailServices)
        {
            _mongoServices = mongoServices;
            _emailServices = emailServices;
        }

        /// <summary>
        ///  Recibe el modelo de datos  y construye el HTML para enviar el correo
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string EmailBuilderAnimalesPie(List<AnimalesPieMongoDBModel> Data)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                _ = stringBuilder.Append($@"                       
                        <html>
                        <head>
                            <meta charset= 'utf - 8' />
                        </head>
                        <body>
                            <div>
                                <div>
                                    <img src='http://www.infoporcinos.com/plantasacrificio/Imagenes/Logo/logo_infoporcinos_peque.png'>
                                    <h3>Logística Animales en Pie - Lotes Recibidos:  { DateTime.Now.ToShortDateString() } </h3>
                                    <h5>Fecha generación reporte: { DateTime.Now } </h5>
                                </div>
                                <div>
                                    <table>
                                        <tbody>
                                            <tr>        
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nro. ident. fis.1</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Granja PigKnows</th>  
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Centro Granja</th>                                  
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Lote Granja Ceba</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Lote Planta</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Fecha Llegada Planta</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Hora Ingreso Planta</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Fecha Ingreso planta</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Tipo Cerdo</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Sexo Lote</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nro Cerdos Remisionados</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nro Cerdos recibidos</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Kilos Cerdos Recibidos</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Peso Total Cerdos</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Peso Promedio Lote</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nro Muertos Transporte</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nro Muertos Desembarque</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nro. Remisión</th>                                                                                      
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Placa del Carro</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nit Transportador</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nombre Conductor</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Guía Movilización</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Hora Salida Granja</th>
                                            </tr>");

                // POR CADA DATO QUE LLEGA  CREA UNA FILA 
                Data.ForEach(x =>
                {

                    decimal PesoTotalLote = Convert.ToDecimal(x.PesoTotalLotePie);
                    decimal PesoPromLote = Convert.ToDecimal(x.PesoPromedioLotePie);
                    string Placa = x.PlacaVehiculo;
                    string HoraSalidaGranja = x.HoraSalidaGranja;
                    if (x.HoraSalidaGranja == "00:00:00") { HoraSalidaGranja = "N.D."; }


                    stringBuilder.AppendFormat($@"
                                            <tr>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.NitPlanta} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.Granja} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.CodigoGranja} </td>           
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.LoteCeba} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.LoteInfoPorcinos} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.FechaLlegadaPlanta.ToString(@"dd/MM/yyyy")} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.HoraIngresoPlanta.ToString(@"HH:mm:ss")} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.HoraIngresoPlanta.ToString(@"dd/MM/yyyy")} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.TipoCerdo} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.Sexo} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.AnimalesRemisionados} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.AnimalesRecibidos} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {string.Format("{0:0.00}", PesoTotalLote)} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {string.Format("{0:0.00}", PesoTotalLote)} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {string.Format("{0:0.00}", PesoPromLote)} </td>  
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.MuertosTransporte} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.MuertosDesembarque} </td>   
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.NroRemision} </td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {Placa.Remove(3, 1)} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.NitTransportador} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.NombreConductor} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {x.GuiaMovilizacion} </td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '> {HoraSalidaGranja} </td>
                                            </tr>");
                });
                stringBuilder.Append(@" 
                                                    </tbody>
                                                </table>
                                            </div>
                                            <p>Esta información es recibida únicamente por las personas de su empresa y está acorde con la <a href='http://www.infoporcinos.com/PoliticaConfidencialidad.aspx'>
                                               Política de confidencialidad y reserva de la información</a> de Mercadeo Virtual S.A. <br><br> Atentamente, <br> Grupo de trabajo<br></p><br>
                                            <h3>Mercadeo Virtual S.A.</h3>
                                        </div>
                                    </body>
                                    </html>");

                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return "error";
            }
        }

        /// <summary>
        /// Recibe el modelo de datos de los lotes completos y que no han sido enviados 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="FechaBeneficio"></param>
        /// <param name="NoEnviadosCompletos"></param>
        /// <returns></returns>
        public string EmailBuilderBeneficio(List<BeneficioMongoDBModel> Data, DateTime FechaBeneficio, List<BeneficioMongoDBModel> NoEnviadosCompletos)
        {
            StringBuilder stringBuilder = new StringBuilder();
            try
            {              
                _ = stringBuilder.Append($@"                       
                        <html>
                        <head>
                            <meta charset= 'utf - 8' />
                        </head>
                        <body>
                            <div>
                                <div>
                                    <img src='http://www.infoporcinos.com/plantasacrificio/Imagenes/Logo/logo_infoporcinos_peque.png'>
                                    <h3>Logística Beneficio - Canales</h3>
                                    <h5>Fecha generación reporte:  {DateTime.Now.ToShortDateString() } </h5>
                                </div>
                                <div>
                                    <table>
                                        <tbody>
                                            <tr>     
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Acreedor</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Granja</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Werks D</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Lote PK</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Lote </th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Tipo Cerdo</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Sexo</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Cantidad</th>                                       
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Peso Total Lote</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Peso Prom. Lote</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Muertos Corrales</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Muertos Corral Obs</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales Decomisadas</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales Inspeccionadas</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Total PCC</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Prom. PCC</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Rendimiento CC</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Prom. GD</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Prom. Magro</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Total Kg. Magro</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Prom. Longitud Lomo</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales T0</th> 
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales T1</th> 
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales T2</th> 
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales T3</th> 
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales T4</th> 
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Canales T5</th> 
                                            </tr>");


                // ARMA UNA FILA DE LA TABAL POR CADA ELEMENTO DEL PARAMETRO QUE LLEGA
                NoEnviadosCompletos.ForEach(x =>
                {
                    // SI COMPLETO ES = A 1 Y ENVIADO ES = 0 LO AÑADE A LA LSITA
                    if (x.Completo == 1 && x.Enviado == 0)
                    {
                        stringBuilder.AppendFormat($@"
                                            <tr>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.NitPlanta }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.Granja }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CodigoGranja }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.LoteCeba }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.LoteInfoPorcinos }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.TipoCerdo }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.Sexo }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.AnimalesRemisionados }</td>                                        
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.PesoTotalLotePie) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.PesoPromedioLotePie) }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.MuertosCorrales }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.MuertosCorralObservacion }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesDecomisadasCompletas }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.TotalInspeccionados }</td>                                                 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.TotalPCC) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.PromPCC) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.RendimientoCC) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.PromGD) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.PromMagro) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.TotalKgMagro) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ string.Format("{0:0.00}", x.PromLongitudLomo) }</td>
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesT0 }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesT1 }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesT2 }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesT3 }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesT4 }</td> 
                                                <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{ x.CanalesT5 }</td> 
                                            </tr>");
                        x.Enviado = 1;
                        x.Completo = 1;
                    // Guardado de actualizaciones
                    // Llamado a MOngoDB para actualizar el estado de completo y enviado
                    _mongoServices.UpdateBeneficio(x.IdLoteIP, x);
                    }
                    else
                    {
                        x.Enviado = 0;
                    // Guardado de actualizaciones
                    _mongoServices.UpdateBeneficio(x.IdLoteIP, x);
                    }


                });

                stringBuilder.Append(@" 
                                                    </tbody>
                                                </table>
                                            </div>
                                            <p> Esta información es recibida únicamente por las personas de su empresa y está acorde con la <a href='http://www.infoporcinos.com/PoliticaConfidencialidad.aspx'>
                                                Política de confidencialidad y reserva de la información</a> de Mercadeo Virtual S.A. <br><br> Atentamente, <br> Grupo de trabajo<br></p><br>
                                            <h3>Mercadeo Virtual S.A.</h3>
                                        </div>
                                    </body>
                                    </html>"
                );

                return stringBuilder.ToString();
            }
            catch(Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail($"[Beneficio - StringBuilder] {err}");
                return null;
            } 
        }


        /// <summary>
        /// ESTE NO TIENE FUNCION,  ESTE TINE API PROPIA
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public string EmailBuilderCanales(List<CanalesDespachadasMongoDBModel.CanalAC> Data)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                _ = stringBuilder.Append($@"
                        <html>
                        <head>
                            <meta charset= 'utf - 8' />
                        </head>
                        <body>
                            <div>
                                <div>
                                    <img src='http://www.infoporcinos.com/plantasacrificio/Imagenes/Logo/logo_infoporcinos_peque.png'>
                                    <h1>Canales Despachadas por Certificados de Sacrificio y Transporte</h1>
                                    <h3>Numero Canales Despachadas: {Data.Count()} </h3>
                                    <h5>Fecha generación reporte:{DateTime.Now.ToShortDateString()} </h5>
                                </div>
                                <div>
                                    <table>
                                        <tbody>
                                            <tr>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>ID</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Fecha</th>                 
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Hora</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Nit Proveedor</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Pedido</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Granja</th>                                                                                      
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Material</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Sexo Canal</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Tipo Canal</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Brazalete</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Cant Un UMB</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Cant Kg UMP</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Lote Cerdo Gordo</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Fecha Sacrificio</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Placa</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Guia Mov.</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Remisión</th>
                                                <th style='padding: 10px; border: 2px solid black; border-image: none; text-align: center; font-family: verdana; font-size: 13px; '>Lote Infoporcinos</th>

                                            </tr>"
                );
                Data.ForEach(data =>
                {
                    string placa = data.Placa;

                    var hora = Convert.ToDateTime(data.HoraDespacho);
                    stringBuilder.AppendFormat($@"
                                <tr>    
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.ID}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.FechaDespacho.ToString(@"dd/MM/yyyy")}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{hora.ToString(@"HH:mm:ss")}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.NitProveedor}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.Pedido}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.Granja}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.Material}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.Sexo}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.TipoCanal}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.Brazalete}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.CantUnUMB}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{string.Format("{0:0.00}", data.CantKgUMP)}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.LoteCerdoGordo}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.FechaSacrificio.ToString(@"dd/MM/yyyy")}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{placa.Remove(3, 1)}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.GuiaMov}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.Remision}</td>
                                    <td style='border: 1px solid black; font-family: verdana; font-size: 13px; text-align: center; margin: 1px; '>{data.LoteInfoporcinos}</td>
                                </tr>"
                    );
                });
                stringBuilder.AppendFormat($@"
                                    </tbody>
                                </table>
                            </div>
                            <p>Esta información es recibida únicamente por las personas de su empresa y está acorde con la <a href='http://www.infoporcinos.com/PoliticaConfidencialidad.aspx'> Política de confidencialidad y reserva de la información</a> de Mercadeo Virtual S.A. <br><br> Atentamente, <br> Grupo de trabajo<br></p><br>
                            <h3>Mercadeo Virtual S.A.</h3>
                        </div>
                    </body>
                </html>"
                );
                return stringBuilder.ToString();
            }
            catch (Exception ex)
            {
                string err = ex.Message.ToString();
                _emailServices.ErrorMail(err);
                return "error";
            }
        }

    }
}
