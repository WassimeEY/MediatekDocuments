
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier LivreDvd hérite de Document
    /// </summary>
    public abstract class LivreDvd : Document
    {
        /// <summary>
        /// Constructeur protégé de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="titre">Valeur utilisé pour valoriser Titre.</param>
        /// <param name="image">Valeur utilisé pour valoriser Image.</param>
        /// <param name="idGenre">Valeur utilisé pour valoriser IdGenre.</param>
        /// <param name="genre">Valeur utilisé pour valoriser Genre.</param>
        /// <param name="idPublic">Valeur utilisé pour valoriser IdPublic.</param>
        /// <param name="lePublic">Valeur utilisé pour valoriser LePublic.</param>
        /// <param name="idRayon">Valeur utilisé pour valoriser IdRayon.</param>
        /// <param name="rayon">Valeur utilisé pour valoriser Rayon.</param>
        protected LivreDvd(string id, string titre, string image, string idGenre, string genre,
            string idPublic, string lePublic, string idRayon, string rayon)
            : base(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon)
        {
        }

    }
}
