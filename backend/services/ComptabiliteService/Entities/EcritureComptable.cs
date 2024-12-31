using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ComptabiliteService.Entities
{

    public class EcritureComptable
    {
        [BsonId]
        public ObjectId Id { get; set; } // MongoDB ObjectId
        public DateTime DateOperation { get; set; } // Date of the operation

        public string Libelle { get; set; }

        public string Piece { get; set; } // Reference of the operation   [BsonElement("lignes")]
        public List<LigneEcriture> Lignes { get; set; } = new List<LigneEcriture>(); // List of the operation's lines
    }
}
