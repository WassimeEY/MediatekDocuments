
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Suivi.
    /// </summary>
    public class Suivi
    {
        /// <summary>
        /// Identifiant de l'étape de suivi.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Libellé de l'étape de suivi actuelle.
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="libelle">Valeur utilisé pour valoriser Libelle.</param>
        public Suivi(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Récupération du libellé pour l'affichage dans les cellules de dataGridView
        /// </summary>
        /// <returns>Libelle</returns>
        public override string ToString()
        {
            return this.Libelle;
        }
    }
}
