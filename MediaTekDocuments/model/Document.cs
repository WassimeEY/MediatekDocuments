
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Document (réunit les infomations communes à tous les documents : Livre, Revue, Dvd)
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Identifiant du document.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Titre du document.
        /// </summary>
        public string Titre { get; }
        /// <summary>
        /// Chemin vers l'image du document.
        /// </summary>
        public string Image { get; }
        /// <summary>
        /// Identifiant du genre du document.
        /// </summary>
        public string IdGenre { get; }
        /// <summary>
        /// Libellé du genre du document.
        /// </summary>
        public string Genre { get; }
        /// <summary>
        /// Identifiant du public visé par le document.
        /// </summary>
        public string IdPublic { get; }
        /// <summary>
        /// Libellé du public visé par le document.
        /// </summary>
        public string Public { get; }
        /// <summary>
        /// Identifiant du rayon du document.
        /// </summary>
        public string IdRayon { get; }
        /// <summary>
        /// Libellé du rayon du document.
        /// </summary>
        public string Rayon { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="titre"></param>
        /// <param name="image"></param>
        /// <param name="idGenre"></param>
        /// <param name="genre"></param>
        /// <param name="idPublic"></param>
        /// <param name="lePublic"></param>
        /// <param name="idRayon"></param>
        /// <param name="rayon"></param>
        public Document(string id, string titre, string image, string idGenre, string genre, string idPublic, string lePublic, string idRayon, string rayon)
        {
            Id = id;
            Titre = titre;
            Image = image;
            IdGenre = idGenre;
            Genre = genre;
            IdPublic = idPublic;
            Public = lePublic;
            IdRayon = idRayon;
            Rayon = rayon;
        }
    }
}
