
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Utilisateur (avec login et mdp)
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// Identifiant de l'utilisateur.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Login, nom d'utilisateur.
        /// </summary>
        public string Login { get; }
        /// <summary>
        /// Mot de passe.
        /// </summary>
        public string Mdp { get; }
        /// <summary>
        /// Identifiant du service de l'utilisateur.
        /// </summary>
        public string IdService { get; }
        /// <summary>
        /// Libellé du service de l'utilisateur.
        /// </summary>
        public string LibelleService { get; }

        /// <summary>
        /// Constructeur de la classe métier, valorise ses propriétés avec les paramètres.
        /// </summary>
        /// <param name="id">Valeur utilisé pour valoriser Id.</param>
        /// <param name="login">Valeur utilisé pour valoriser Login.</param>
        /// <param name="mdp">Valeur utilisé pour valoriser Mdp.</param>
        /// <param name="idService">Valeur utilisé pour valoriser IdService.</param>
        /// <param name="libelleService">Valeur utilisé pour valoriser LibelleService.</param>
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
