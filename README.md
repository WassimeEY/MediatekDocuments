# Extension de l'app C# MediatekDocument et de son API REST
## Présentation
Cette application C# permet d'accéder aux livres, DVD et revue du réseau Mediatek86.<br> 
Elle communique avec une API REST : [https://github.com/WassimeEY/rest_mediatekdocuments](https://github.com/WassimeEY/rest_mediatekdocuments) <br>
Cet atelier a été réalisé pour ajouter la partie adapté au service administratif et quelques fonctionnalités supplémentaires. <br>
Voilà le dépôt GitHub d'origine sur lequel cet atelier est basé : [https://github.com/CNED-SLAM/mediatekformation](https://github.com/CNED-SLAM/MediaTekDocuments) <br> 
Vous y trouverez son readme, qui contient la présentation complète de l'application d'origine.

Elle contient désormais ces nouvelles fonctionnalités :<br>
![CasUtilisation 2-2](https://github.com/user-attachments/assets/49e08ca0-5c1c-4414-a207-720b2fdf49bb)


## Les nouveaux onglets
Voici les 3 nouveaux onglets et la page d'authentification qui sont liées aux différents cas d'utilisations:
### Onglet 1 : gestion des commandes de livre
Qui permet donc de : <br>
• Trouver un livre à partir de son numéro <br>
• Supprimer une commande de livre<br>
• Modifier l'étape de suivi de la commande sélectionnée<br>
• Créer une nouvelle commande de livre<br>
![CommandesLivre](https://github.com/user-attachments/assets/5d2b1a87-0b33-4545-a1e3-0357a327c1ee)

### Onglet 2 : gestion des commandes de DVD
Qui permet donc de :<br>
• Trouver un DVD à partir de son numéro<br>
• Supprimer une commande de DVD<br>
• Modifier l'étape de suivi de la commande sélectionnée<br>
• Créer une nouvelle commande de DVD<br>
![CommandesDVD](https://github.com/user-attachments/assets/b873b627-ff7b-4164-a743-885dc43c73b6)

### Onglet 3 : gestion des commandes de revue (abonnements)
Qui permet donc de :<br>
• Trouver une revue à partir de son numéro<br>
• Supprimer un abonnement à une revue seulement si aucun exemplaire est compris dans la période de l'abonnement<br>
• Créer une nouvelle commande de revue avec la date de début et fin d'abonnement<br>
![CommandesRevue](https://github.com/user-attachments/assets/9daa68c9-6d6e-4e3c-bd58-1ff267b9d429)

### Fenêtre d'authentification
Cette page permet d'entrer le login et le mot de passe d'un utilisateur spécifique. <br>
![Auth](https://github.com/user-attachments/assets/882d6ae4-b0ab-4400-8cdb-0ffe85a83e96) <br>
L'application s'adapte selon le service de l'utilisateur connecté. Par exemple, ceux du service Culture n'ont même pas accès à l'application. <br>

## La base de données
La base de données a désormais 3 nouvelles tables : suivi, service et utilisateur.  <br>
La table suivi permet d'avoir les différentes étapes de suivi d'une commande de document, alors que les tables service et utilisateur permettent de conserver les utilisateurs appartennant à un certain service :  <br>
![MCD ajout 2-1](https://github.com/user-attachments/assets/d64cf128-5456-46e1-81ba-f62c22631d2f)
![MCD ajout 4](https://github.com/user-attachments/assets/5af47627-c8af-4722-9df9-7f5348091dcb)


## Test de l'application
Ouver la solution en .sln, ensuite modifier le fichier App.config dans le dossier "MediaTekDocuments", il vous suffit d'adapter le fichier à un test local ou distant (serveur OVH) en copiant et en remplaçant les 6 lignes :
![Modif](https://github.com/user-attachments/assets/81d030c8-9429-42fe-bc8a-875dff10e698)
Si vous voulez faire un test local :
```
	<connectionStrings>
		<add name="MediaTekDocuments.Properties.Settings.MediaTekDocumentsAuthentificationStrings" connectionString="admin:adminpwd" />
	</connectionStrings>

	<appSettings>
		<add key="MediaTekDocuments.Properties.Settings.apiUriString" value="http://localhost/rest_mediatekdocuments/" />
	</appSettings>
```
Si vous voulez faire un test distant (serveur OVH) :
```
	<connectionStrings>
		<add name="MediaTekDocuments.Properties.Settings.MediaTekDocumentsAuthentificationStrings" connectionString="adminW:adminpwd123" />
	</connectionStrings>

	<appSettings>
		<add key="MediaTekDocuments.Properties.Settings.apiUriString" value="http://wassimeeymediatekdocuments.ovh/" />
	</appSettings>
```

## L'installateur en .msi (test distant)
Installer le logiciel avec l'installateur disponible en racine du projet du dépôt de l'application C# (ce dépôt). 
