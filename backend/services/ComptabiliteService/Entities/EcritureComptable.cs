using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComptabiliteService.Entities
{
    public class EcritureComptable
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("dateOperation")]
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DateOperation { get; set; } // Date of the operation

        [BsonElement("reference")]
        public string Reference { get; set; } // Reference of the operation

        [BsonElement("libelle")]
        public string Libelle { get; set; } // Description of the operation

        [BsonElement("comptesMouvementes")]
        public string ComptesMouvementes { get; set; } // Accounting entry

        [BsonElement("montant")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Montant { get; set; } // Amount of the operation

        [BsonElement("sensFlux")]
        public string SensFlux { get; set; } // Flow direction: "debit" or "credit"
    }
}
