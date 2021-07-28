using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Contracts.V1
{

    /// <summary>
    /// Contract (Archivo que Nunca deberia Cambiar)
    /// Modelo De Extraccion De Datos de AnimalesEnPie
    /// </summary>
    public class AnimalesPieMongoDBModel
    {
        [BsonId]
        [BsonElement("IdLoteIP")]
        public int IdLoteIP { get; set; }

        [BsonElement("LoteInfoPorcinos")]
        public string LoteInfoPorcinos { get; set; }

        [BsonElement("TipoCerdo")]
        public string TipoCerdo { get; set; }

        [BsonElement("LoteCeba")]
        public string LoteCeba { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaLlegadaPlanta { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime HoraIngresoPlanta { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaSalidaPorteria { get; set; }

        [BsonElement("TiempoPorteria")]
        public string TiempoPorteria { get; set; }

        [BsonElement("NroRemision")]
        public string NroRemision { get; set; }

        [BsonElement("AnimalesRemisionados")]
        public int AnimalesRemisionados { get; set; }

        [BsonElement("CodigoGranja")]
        public string CodigoGranja { get; set; }

        [BsonElement("Granja")]
        public string Granja { get; set; }

        [BsonElement("Ciudad")]
        public string Ciudad { get; set; }

        [BsonElement("Vereda")]
        public string Vereda { get; set; }

        [BsonElement("Inmunocastrado")]
        public string Inmunocastrado { get; set; }

        [BsonElement("PlacaVehiculo")]
        public string PlacaVehiculo { get; set; }

        [BsonElement("NombreConductor")]
        public string NombreConductor { get; set; }

        [BsonElement("GuiaMovilizacion")]
        public string GuiaMovilizacion { get; set; }

        [BsonElement("HoraSalidaGranja")]
        public string HoraSalidaGranja { get; set; }

        [BsonElement("ResponsablePorteria")]
        public string ResponsablePorteria { get; set; }

        [BsonElement("AnimalesRecibidos")]
        public int AnimalesRecibidos { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime InicioDesembarque { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FinDesembarque { get; set; }

        [BsonElement("TiempoDesembarque")]
        public string TiempoDesembarque { get; set; }

        [BsonElement("AnimalesPesados")]
        public int AnimalesPesados { get; set; }

        [BsonElement("Sexo")]
        public string Sexo { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Fechatiquetepesaje { get; set; }

        [BsonElement("NroTiquete")]
        public int NroTiquete { get; set; }

        [BsonElement("PesoTotalLotePie")]
        public decimal PesoTotalLotePie { get; set; }

        [BsonElement("PesoPromedioLotePie")]
        public decimal PesoPromedioLotePie { get; set; }

        [BsonElement("ResponsableCorrales")]
        public string ResponsableCorrales { get; set; }

        [BsonElement("AnimalesObservados")]
        public int AnimalesObservados { get; set; }

        [BsonElement("AgitadosTransporte")]
        public int AgitadosTransporte { get; set; }

        [BsonElement("CaidosTransporte")]
        public int CaidosTransporte { get; set; }

        [BsonElement("MuertosTransporte")]
        public int MuertosTransporte { get; set; }

        [BsonElement("MuertosDesembarque")]
        public int MuertosDesembarque { get; set; }

        [BsonElement("CaidosCorrales")]
        public int CaidosCorrales { get; set; }

        [BsonElement("AgitadosCorrales")]
        public int AgitadosCorrales { get; set; }

        [BsonElement("MuertosCorrales")]
        public int MuertosCorrales { get; set; }

        [BsonElement("MuertosCorralObservacion")]
        public int MuertosCorralObservacion { get; set; }

        [BsonElement("ResponsableInspeccionAnteMortem")]
        public string ResponsableInspeccionAnteMortem { get; set; }

        [BsonElement("NitPlanta")]
        public string NitPlanta { get; set; }

        [BsonElement("NitTransportador")]
        public string NitTransportador { get; set; }
    }
}
