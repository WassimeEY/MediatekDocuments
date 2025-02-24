
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Service.
    /// </summary>
    public class Service
    {
        /// <summary>
        /// Identifiant du service.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Libellé du service.
        /// </summary>
        public string Libelle { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="libelle">Valeur utilisé pour valoriser LibelleService.</param>
        public Service(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

    }
}
