# MazeVR

## Arborescence du projet
- Dossier "**MazeVR-Client**" : projet Unity représentant le client du jeu, c'est-à-dire le joueur avec le casque VR ;
- Dossier "**MazeVR-Server**" : projet Unity représentant le serveur du jeu, c'est-à-dire le jouer sur PC ;
- Dossier "**MazeVR-Shared**" : projet Visual Studio qui permet de partager du code commun entre la version client et serveur.

## Pour l'équipe
Pour l'instant nous travaillons que sur la partie serveur, c'est-à-dire que tous nos assets (modèles 3D, scripts, etc.) se trouveront dans le projet Unity "MazeVR-Server".

Une fois que la partie réseau sera integrée, nous commencerons à faire la distinction entre les assets client et serveur. Les assets client iront dans le dossier "MazeVR-Client" et les assets serveur iront dans le dossier "MazeVR-Server".

## Rappels

- [x] Ajouter le dossier "ProjectSettings" au git.ignore pour tout membre de l'équipe, pour éviter d'avoir des conflits au niveau des paramètres du projet Unity.
- [x] Ajouter une exception au git.ignore pour le dossier MazeVR-Shared : ne pas ignorer le projet Visual Studio ([aide](https://stackoverflow.com/questions/3203228/git-ignore-exception)).
