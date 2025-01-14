namespace ComptabiliteService.Dtos
{
    public class EcritureComptableDto
    {
        public DateTime DateOperation { get; set; }
        public string Libelle { get; set; }
        public string Piece { get; set; }
        public List<LigneEcritureDto> Lignes { get; set; } = new List<LigneEcritureDto>();
    }
}
