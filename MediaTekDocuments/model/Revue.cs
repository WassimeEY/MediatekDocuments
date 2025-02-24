
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Revue hérite de Document : contient des propriétés spécifiques aux revues
    /// </summary>
    public class Revue : Document
    {
        /// <summary>
        /// Type de périodicité de cette revue.
        /// </summary>
        public string Periodicite { get; set; }
        /// <summary>
        /// Délai de mise à disposition de la revue.
        /// </summary>
        public int DelaiMiseADispo { get; set; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
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
        /// <param name="periodicite">Valeur utilisé pour valoriser Periodicite.</param>
        /// <param name="delaiMiseADispo">Valeur utilisé pour valoriser DelaiMiseADispo.</param>
        public Revue(string id, string titre, string image, string idGenre, string genre,
            string idPublic, string lePublic, string idRayon, string rayon,
            string periodicite, int delaiMiseADispo)
             : base(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon)
        {
            Periodicite = periodicite;
            DelaiMiseADispo = delaiMiseADispo;
        }

    }
}
