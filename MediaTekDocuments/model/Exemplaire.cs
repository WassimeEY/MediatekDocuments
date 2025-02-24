using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Exemplaire (exemplaire d'une revue)
    /// </summary>
    public class Exemplaire
    {
        /// <summary>
        /// Numéro de l'exemplaire, on peut voir ceci comme une sorte d'indentifiant.
        /// </summary>
        public int Numero { get; set; }
        /// <summary>
        /// Date d'achat de l'exemplaire.
        /// </summary>
        public DateTime DateAchat { get; set; }
        /// <summary>
        /// Chemin vers la photo de couverture l'exemplaire.
        /// </summary>
        public string Photo { get; set; }
        /// <summary>
        /// Identifiant de l'état actuelle de l'exemplaire.
        /// </summary>
        public string IdEtat { get; set; }
        /// <summary>
        /// Identifiant du document de l'exemplaire.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="numero">Valeur utilisé pour valoriser Numero.</param>
        /// <param name="dateAchat">Valeur utilisé pour valoriser DateAchat.</param>
        /// <param name="photo">Valeur utilisé pour valoriser Photo.</param>
        /// <param name="idEtat">Valeur utilisé pour valoriser IdEtat.</param>
        /// <param name="idDocument">Valeur utilisé pour valoriser IdDocument.</param>
        public Exemplaire(int numero, DateTime dateAchat, string photo, string idEtat, string idDocument)
        {
            this.Numero = numero;
            this.DateAchat = dateAchat;
            this.Photo = photo;
            this.IdEtat = idEtat;
            this.Id = idDocument;
        }

    }
}
