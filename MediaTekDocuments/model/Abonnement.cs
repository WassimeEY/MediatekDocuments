using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Abonnement, avec sa date de fin d'abonnement et son idRevue.
    /// </summary>
    public class Abonnement : Commande
    {
        public DateTime DateFinAbonnement { get; }
        public string IdRevue { get; }
        public string TitreRevue { get; }

        public Abonnement(string id, DateTime dateCommande, double montant, DateTime dateFinAbonnement, string idRevue, string titreRevue) : base(id, dateCommande, montant)
        {
            this.DateFinAbonnement = dateFinAbonnement;
            this.IdRevue = idRevue;
            this.TitreRevue = titreRevue;
        }
    }
}
