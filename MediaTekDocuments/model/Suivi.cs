
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Suivi.
    /// </summary>
    public class Suivi
    {
        public string Id { get; }
        public string Libelle { get; }

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
