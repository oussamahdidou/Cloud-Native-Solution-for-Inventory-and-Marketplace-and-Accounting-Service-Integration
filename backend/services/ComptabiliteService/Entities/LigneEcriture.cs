using MongoDB.Bson.Serialization.Attributes;

namespace ComptabiliteService.Entities
{
    public class LigneEcriture
    {
        [BsonElement("compteId")]
        public string CompteId { get; set; }

        [BsonElement("compteIntitule")]
        public string CompteIntitule { get; set; }

        [BsonElement("debit")]
        public decimal Debit { get; set; }

        [BsonElement("credit")]
        public decimal Credit { get; set; }
    }
}
