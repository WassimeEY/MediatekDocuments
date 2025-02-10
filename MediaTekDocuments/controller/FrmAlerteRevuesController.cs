using System.Collections.Generic;
using MediaTekDocuments.dal;
using MediaTekDocuments.model;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FramAlerteRevues
    /// </summary>
    class FrmAlerteRevuesController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmAlerteRevuesController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des abonnements les plus récent de chaque revue, qui s'apprête à expirer.
        /// </summary>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAllAbonnementBientotExpire()
        {
            return access.GetAllAbonnementBientotExpire();
        }
    }
}
