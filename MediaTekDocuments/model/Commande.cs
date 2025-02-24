using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Commande
    /// </summary>
    public class Commande
    {
        /// <summary>
        /// Identifiant de la commande.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Date de la commande, peut donc aussi être la date de début d'un abonnement.
        /// </summary>
        public DateTime DateCommande { get; }
        /// <summary>
        /// Montant de la commande.
        /// </summary>
        public double Montant { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dateCommande"></param>
        /// <param name="montant"></param>
        public Commande(string id, DateTime dateCommande, double montant)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
        }

    }
}
