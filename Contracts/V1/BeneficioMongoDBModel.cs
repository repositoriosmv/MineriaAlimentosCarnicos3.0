using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Contracts.V1
{
    public class BeneficioMongoDBModel
    {

        [BsonId]
        [BsonElement("IdLoteIP")]
        public int IdLoteIP { get; set; }

        [BsonElement("LoteInfoPorcinos")]
        public string LoteInfoPorcinos { get; set; }

        [BsonElement("CantidadLote")]
        public int CantidadLote { get; set; }

        [BsonElement("TipoCerdo")]
        public string TipoCerdo { get; set; }

        [BsonElement("LoteCeba")]
        public string LoteCeba { get; set; }

        [BsonElement("AnimalesRemisionados")]
        public int AnimalesRemisionados { get; set; }

        [BsonElement("Granja")]
        public string Granja { get; set; }

        [BsonElement("PesoTotalLotePie")]
        public float PesoTotalLotePie { get; set; }

        [BsonElement("PesoPromedioLotePie")]
        public float PesoPromedioLotePie { get; set; }

        [BsonElement("MuertosTransporte")]
        public int MuertosTransporte { get; set; }

        [BsonElement("MuertosDesembarque")]
        public int MuertosDesembarque { get; set; }

        [BsonElement("MuertosCorrales")]
        public int MuertosCorrales { get; set; }

        [BsonElement("MuertosCorralObservacion")]
        public int MuertosCorralObservacion { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaInicioInspeccionpostmortem { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaFinalinspeccionpostmortem { get; set; }

        [BsonElement("TiempoSacrificio")]
        public string TiempoSacrificio { get; set; }

        [BsonElement("CanalesDecomisadasCompletas")]
        public int CanalesDecomisadasCompletas { get; set; }

        [BsonElement("TotalRetenidas")]
        public int TotalRetenidas { get; set; }

        [BsonElement("RetenidasOlorSexual")]
        public int RetenidasOlorSexual { get; set; }

        [BsonElement("TotalInspeccionados")]
        public int TotalInspeccionados { get; set; }

        [BsonElement("KgCarneDecomisos")]
        public string KgCarneDecomisos { get; set; }

        [BsonElement("ResponsableInspeccionPostmortem")]
        public string ResponsableInspeccionPostmortem { get; set; }

        [BsonElement("TotalEvaluados")]
        public int TotalEvaluados { get; set; }

        [BsonElement("Sexo")]
        public string Sexo { get; set; }

        [BsonElement("TotalPCC")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float TotalPCC { get; set; }

        [BsonElement("PromPCC")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float PromPCC { get; set; }

        [BsonElement("RendimientoCC")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float RendimientoCC { get; set; }

        [BsonElement("PromGD")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float PromGD { get; set; }

        [BsonElement("PromMagro")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float PromMagro { get; set; }

        [BsonElement("TotalKgMagro")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float TotalKgMagro { get; set; }

        [BsonElement("PromLongitudLomo")]
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float PromLongitudLomo { get; set; }

        [BsonElement("ResponsableMedicion")]
        public string ResponsableMedicion { get; set; }

        [BsonElement("AnimalesEnSBE")]
        public int AnimalesEnSBE { get; set; }

        [BsonElement("ResponsableInspeccionSBE")]
        public string ResponsableInspeccionSBE { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaInicioInspeccionSBE { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime FechaFinalInspeccionSBE { get; set; }

        [BsonElement("NitPlanta")]
        public string NitPlanta { get; set; }

        [BsonElement("CodigoGranja")]
        public string CodigoGranja { get; set; }

        [BsonElement("CanalesT0")]
        public int CanalesT0 { get; set; }

        [BsonElement("CanalesT1")]
        public int CanalesT1 { get; set; }
        [BsonElement("CanalesT2")]
        public int CanalesT2 { get; set; }
        [BsonElement("CanalesT3")]
        public int CanalesT3 { get; set; }
        [BsonElement("CanalesT4")]
        public int CanalesT4 { get; set; }
        [BsonElement("CanalesT5")]
        public int CanalesT5 { get; set; }

        [BsonElement("Completo")]
        public int Completo { get; set; }

        [BsonElement("Enviado")]
        public int Enviado { get; set; }

    }
    public class Idlote
    {
        [BsonId]
        [BsonElement("IdLoteIP")]
        public int IdLoteIP { get; set; }
    }
}
