using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Partie modèle de l'application.
    /// </summary>
    [System.Runtime.CompilerServices.CompilerGenerated]
    internal class NamespaceDoc
    {

    }

    /// <summary>
    /// Classe métier Abonnement, avec sa date de fin d'abonnement et son idRevue.
    /// </summary>
    public class Abonnement : Commande
    {
        /// <summary>
        /// Date de fin de l'abonnement.
        /// </summary>
        public DateTime DateFinAbonnement { get; }
        /// <summary>
        /// Identifiant de la revue de l'abonnement.
        /// </summary>
        public string IdRevue { get; }
        /// <summary>
        /// Titre de la revue de l'abonnement.
        /// </summary>
        public string TitreRevue { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateCommande"></param>
        /// <param name="montant"></param>
        /// <param name="dateFinAbonnement"></param>
        /// <param name="idRevue"></param>
        /// <param name="titreRevue"></param>
        public Abonnement(string id, DateTime dateCommande, double montant, DateTime dateFinAbonnement, string idRevue, string titreRevue) : base(id, dateCommande, montant)
        {
            this.DateFinAbonnement = dateFinAbonnement;
            this.IdRevue = idRevue;
            this.TitreRevue = titreRevue;
        }
    }
}
