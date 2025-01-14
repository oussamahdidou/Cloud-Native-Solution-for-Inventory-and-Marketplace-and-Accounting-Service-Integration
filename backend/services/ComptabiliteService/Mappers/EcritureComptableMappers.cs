using ComptabiliteService.Dtos;
using ComptabiliteService.Entities;
using EventsContracts.EventsContracts;

namespace ComptabiliteService.Mappers
{
    public static class EcritureComptableMappers
    {
        public static EcritureComptable FromEcritureComptableDtoToEcritureComptable(this EcritureComptableDto ecritureComptableDto)
        {
            return new EcritureComptable
            {
                DateOperation = ecritureComptableDto.DateOperation,
                Libelle = ecritureComptableDto.Libelle,
                Piece = ecritureComptableDto.Piece,
                Lignes = ecritureComptableDto.Lignes.Select(x => x.FromLigneEcritureDtoToLigneEcriture()).ToList()
            };
        }
        public static LigneEcriture FromLigneEcritureDtoToLigneEcriture(this LigneEcritureDto ligneEcritureDto)
        {
            return new LigneEcriture
            {
                CompteId = ligneEcritureDto.CompteId,
                CompteIntitule = ligneEcritureDto.CompteIntitule,
                Debit = ligneEcritureDto.Debit,
                Credit = ligneEcritureDto.Credit
            };
        }
        public static List<LigneEcriture> FromSortieItemToLigneEcriture(this List<ISortieItem> sortieItems)
        {
            List<LigneEcriture> lignes = new List<LigneEcriture>();
            LigneEcriture compteDebiteur = new LigneEcriture()
            {
                CompteId = "512",
                CompteIntitule = "Banque",
                Credit = 0,
                Debit = ((decimal)sortieItems.Sum(x => x.Price * x.Quantity))
            };
            LigneEcriture compteCrediteur = new LigneEcriture()
            {
                CompteId = "707",
                CompteIntitule = "Ventes de marchandises",
                Credit = ((decimal)sortieItems.Sum(x => x.Price * x.Quantity)),
                Debit = 0
            };
            lignes.AddRange(new List<LigneEcriture> { compteDebiteur, compteCrediteur });
            return lignes;

        }
        public static List<LigneEcriture> FromEntreeToLigneEcriture(this IEntreeRecordedEvent entreeRecordedEvent)
        {
            List<LigneEcriture> lignes = new List<LigneEcriture>();
            LigneEcriture compteDebiteur = new LigneEcriture()
            {
                CompteId = "607",
                CompteIntitule = "Achat de marchandises",
                Credit = 0,
                Debit = (decimal)(entreeRecordedEvent.Price * entreeRecordedEvent.Quantity)
            };
            LigneEcriture compteCrediteur = new LigneEcriture()
            {
                CompteId = "512",
                CompteIntitule = "Banque",
                Credit = (decimal)(entreeRecordedEvent.Price * entreeRecordedEvent.Quantity),
                Debit = 0
            };
            lignes.AddRange(new List<LigneEcriture> { compteDebiteur, compteCrediteur });
            return lignes;

        }
    }
}
