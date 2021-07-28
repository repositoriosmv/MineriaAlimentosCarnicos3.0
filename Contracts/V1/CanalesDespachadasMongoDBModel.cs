using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineriaAlimentosCarnicos.Contracts.V1
{
    public class CanalesDespachadasMongoDBModel
    {
        [BsonId]
        [BsonElement("_id")]
        public int IdCertificadoSyT { get; set; }

        [BsonElement("Canales")]
        public List<CanalAC> Canales { get; set; }

        public class CanalAC
        {
            [BsonElement("NroCertificado")]
            public int NroCertificado { get; set; }

            [BsonElement("ID")]
            public int ID { get; set; }

            [BsonElement("IdCanal")]
            public int IdCanal { get; set; }

            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            [BsonElement("FechaDespacho")]
            public DateTime FechaDespacho { get; set; }

            [BsonElement("HoraDespacho")]
            public string HoraDespacho { get; set; }

            [BsonElement("NitProveedor")]
            public string NitProveedor { get; set; }

            [BsonElement("Pedido")]
            public string Pedido { get; set; }

            [BsonElement("Granja")]
            public string Granja { get; set; }

            [BsonElement("NombreGranja")]
            public string NombreGranja { get; set; }

            [BsonElement("Material")]
            public string Material { get; set; }

            [BsonElement("TipoCanal")]
            public string TipoCanal { get; set; }

            [BsonElement("Sexo")]
            public string Sexo { get; set; }

            [BsonElement("Brazalete")]
            public string Brazalete { get; set; }

            [BsonElement("CantUnUMB")]
            public string CantUnUMB { get; set; }

            [BsonElement("CantKgUMP")]
            public float CantKgUMP { get; set; }

            [BsonElement("LoteCerdoGordo")]
            public string LoteCerdoGordo { get; set; }

            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            [BsonElement("FechaSacrificio")]
            public DateTime FechaSacrificio { get; set; }

            [BsonElement("Placa")]
            public string Placa { get; set; }

            [BsonElement("GuiaMov")]
            public string GuiaMov { get; set; }

            [BsonElement("Remision")]
            public string Remision { get; set; }

            [BsonElement("LoteInfoporcinos")]
            public string LoteInfoporcinos { get; set; }
        }

        public class Certs
        {
            [BsonIgnore]
            public int IdCertificadoSyT { get; set; }
        }
    }
}
