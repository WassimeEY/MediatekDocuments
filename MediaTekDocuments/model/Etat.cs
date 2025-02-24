
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Etat (état d'usure d'un document)
    /// </summary>
    public class Etat
    {
        /// <summary>
        /// Identifiant de l'état.
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Libellé de l'état. On parle ici d'état physique comme l'état "neuf".
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libelle"></param>
        public Etat(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

    }
}
