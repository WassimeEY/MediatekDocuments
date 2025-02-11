using System.Collections.Generic;
using MediaTekDocuments.dal;
using MediaTekDocuments.model;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FramAlerteRevues
    /// </summary>
    class FrmAuthentificationController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmAuthentificationController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// Récupère l'utilisateur si l'authentification s'est faite, sinon on reçoit null. 
        /// </summary>
        public Utilisateur GetUtilisateurSiValide(Utilisateur utilisateur)
        {
            return access.GetUtilisateurSiValide(utilisateur);
        }
    }
}
