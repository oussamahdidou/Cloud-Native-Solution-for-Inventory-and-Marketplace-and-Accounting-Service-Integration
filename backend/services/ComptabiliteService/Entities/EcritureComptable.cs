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
        [BsonRequired]
        public DateTime DateOperation { get; set; }

        [BsonElement("libelle")]
        [BsonRequired]
        public string Libelle { get; set; }

        [BsonElement("piece")]
        [BsonRequired]
        public string Piece { get; set; }

        [BsonElement("lignes")]
        [BsonRequired]
        public List<LigneEcriture> Lignes { get; set; } = new List<LigneEcriture>();

    }

}
