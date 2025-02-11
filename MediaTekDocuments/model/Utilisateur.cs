
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Utilisateur (avec login et mdp)
    /// </summary>
    public class Utilisateur
    {
        public string Id { get; }
        public string Login { get; }
        public string Mdp { get; }
        public string IdService { get; }
        public string LibelleService { get; }

        public Utilisateur(string id, string login, string mdp, string idService, string libelleService)
        {
            this.Id = id;
            this.Login = login;
            this.Mdp = mdp;
            this.IdService = idService;
            this.LibelleService = libelleService;
        }

    }
}
