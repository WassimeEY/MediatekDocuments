
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Livre hérite de LivreDvd : contient des propriétés spécifiques aux livres
    /// </summary>
    public class Livre : LivreDvd
    {
        /// <summary>
        /// Le "numéro international normalisé d'identification" du livre.
        /// </summary>
        public string Isbn { get; }
        /// <summary>
        /// Auteur du livre.
        /// </summary>
        public string Auteur { get; }
        /// <summary>
        /// Collection où est le livre.
        /// </summary>
        public string Collection { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="titre">Valeur utilisé pour valoriser Titre.</param>
        /// <param name="image">Valeur utilisé pour valoriser Image.</param>
        /// <param name="isbn">Valeur utilisé pour valoriser Isbn.</param>
        /// <param name="auteur">Valeur utilisé pour valoriser Auteur.</param>
        /// <param name="collection">Valeur utilisé pour valoriser Collection.</param>
        /// <param name="idGenre">Valeur utilisé pour valoriser IdGenre.</param>
        /// <param name="genre">Valeur utilisé pour valoriser Genre.</param>
        /// <param name="idPublic">Valeur utilisé pour valoriser IdPublic.</param>
        /// <param name="lePublic">Valeur utilisé pour valoriser Public.</param>
        /// <param name="idRayon">Valeur utilisé pour valoriser IdRayon.</param>
        /// <param name="rayon">Valeur utilisé pour valoriser Rayon.</param>
        public Livre(string id, string titre, string image, string isbn, string auteur, string collection,
            string idGenre, string genre, string idPublic, string lePublic, string idRayon, string rayon)
            : base(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon)
        {
            this.Isbn = isbn;
            this.Auteur = auteur;
            this.Collection = collection;
        }



    }
}
