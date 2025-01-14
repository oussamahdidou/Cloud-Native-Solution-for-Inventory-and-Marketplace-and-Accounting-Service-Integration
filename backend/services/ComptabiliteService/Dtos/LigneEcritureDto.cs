namespace ComptabiliteService.Dtos
{
    public class LigneEcritureDto
    {
        public string CompteId { get; set; }
        public string CompteIntitule { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }
}
