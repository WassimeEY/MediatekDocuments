
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Service.
    /// </summary>
    public class Service
    {
        public string Id { get; }
        public string Libelle { get; }

        public Service(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

    }
}
