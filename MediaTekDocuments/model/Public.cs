
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Public (public concerné par le document) hérite de Categorie
    /// </summary>
    public class Public : Categorie
    {
        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="libelle">Valeur utilisé pour valoriser Libelle.</param>
        public Public(string id, string libelle) : base(id, libelle)
        {
        }

    }
}
