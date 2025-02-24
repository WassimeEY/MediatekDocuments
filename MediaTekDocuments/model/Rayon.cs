
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Rayon (rayon de classement du document) hérite de Categorie
    /// </summary>
    public class Rayon : Categorie
    {
        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="libelle">Valeur utilisé pour valoriser Libelle.</param>
        public Rayon(string id, string libelle) : base(id, libelle)
        {
        }

    }
}
