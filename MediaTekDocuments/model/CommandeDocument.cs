using System;
using Newtonsoft.Json;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeDocument, avec l'étape de suivi.
    /// </summary>
    public class CommandeDocument : Commande
    {
        public int NbExemplaire { get; }
        public string IdLivreDvd { get; }
        public string IdEtapeSuivi { get; }
        [JsonIgnore]
        public string EtapeSuiviLibelle { get; set; }

        public CommandeDocument(string id, DateTime dateCommande, double montant, int nbExemplaire, string idLivreDvd, string idEtapeSuivi, string etapeSuiviLibelle) : base(id, dateCommande, montant)
        {
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            this.IdEtapeSuivi = idEtapeSuivi;
            this.EtapeSuiviLibelle = etapeSuiviLibelle;
        }
    }
}
