using System;
using Newtonsoft.Json;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeDocument, hérite de Commande, avec l'étape de suivi.
    /// </summary>
    public class CommandeDocument : Commande
    {
        /// <summary>
        /// Nombre d'exemplaires dans la commande de document.
        /// </summary>
        public int NbExemplaire { get; }
        /// <summary>
        /// Identifiant du document de la commande.
        /// </summary>
        public string IdLivreDvd { get; }
        /// <summary>
        /// Identifiant de l'étape de suivi de la commande.
        /// </summary>
        public string IdEtapeSuivi { get; }
        /// <summary>
        /// Le libellé de l'étape de suivi actuelle de la commande.
        /// </summary>
        [JsonIgnore]
        public string EtapeSuiviLibelle { get; set; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateCommande"></param>
        /// <param name="montant"></param>
        /// <param name="nbExemplaire"></param>
        /// <param name="idLivreDvd"></param>
        /// <param name="idEtapeSuivi"></param>
        /// <param name="etapeSuiviLibelle"></param>
        public CommandeDocument(string id, DateTime dateCommande, double montant, int nbExemplaire, string idLivreDvd, string idEtapeSuivi, string etapeSuiviLibelle) : base(id, dateCommande, montant)
        {
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            this.IdEtapeSuivi = idEtapeSuivi;
            this.EtapeSuiviLibelle = etapeSuiviLibelle;
        }
    }
}
