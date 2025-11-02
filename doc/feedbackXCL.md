## Feedback

### 10.9

- Livraison du 5.9:
  - Release: N'a pas été faite
  - Nommage des commits: Bien. Attention à l'atomicité! Il faudrait faire trois commits avec votre commit "doc(evaluation, maquette, jdt, readme) Ajout de l'évaluation et du readme en pdf, modification de la maquette et jdt"
  - Rapport: Très bien
  - User stories: manque de précision général. Les tests doivent etre mesurables. Voir commentaires dans les US
  - Journal: OK
  - Grille d'évaluation: ne gardez que votre page à vous. Je ne vois pas votre auto-évaluation dans le fichier

### 7.10

- Je trouve exagéré de noter 25 minutes de travail pour [cette modification](https://github.com/OkkesErdemKose/Shoot-em-UP/commit/e514922dbecb670bd2e3d9e2a29163a473b59a93) de maquette. Qu'en pensez-vous ?
- Il est temps de remplacer le thème "Drone" par le votre dans le code
- Je n'arrive pas à exécuter votre programme, le code ne compile pas. Une des raisons est les namespace: mettez tout dans le même namespace.
- Attention aux références à vos images. `Image.FromFile("./Resources/vaisseau.png")` marche certainement sur votre poste parce que vous avez copié des fichiers à la main. Mais ça ne marche pas chez moi
- Merci de créer le dossier `doc` à la racine de votre repo, comme demandé en début de projet

## 80%

Les valeurs possibles du résultat sont: LA (Largement Acquis), A (Acquis), I (Insuffisant), NA (non acquis)

| Critère                    | Résultat | Commentaire                                                                                                                                                                                                                                                               |
| -------------------------- | -------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Avancement Obstacles       | NA       | Il n'y en a pas                                                                                                                                                                                                                                                           |
| Avancement Joueur          | A        | je vous suggère fortement d'augmenter la hauteur de la fenêtre pour rendre le jeu un peu plus intéressant, car sinon les virus arrivent trop vite sur le joueur                                                                                                           |
| Avancement Tirs            | A        |                                                                                                                                                                                                                                                                           |
| Avancement ennemis         | A        |                                                                                                                                                                                                                                                                           |
| Avancement score           | NA       |                                                                                                                                                                                                                                                                           |
| Qualité Présentation       | A        |                                                                                                                                                                                                                                                                           |
| Qualité Commentaires       | I        | il reste plusieurs commentaires relatifs au Drone                                                                                                                                                                                                                         |
| Qualité Conventions        | A        |                                                                                                                                                                                                                                                                           |
| POO                        | A        |                                                                                                                                                                                                                                                                           |
| Processus Journal          | LA       | Très bien                                                                                                                                                                                                                                                                 |
| Processus Git              | I        | faites attention à l'atomicité des commits. Vous avez mis 26 changements qui concerne trois choses différentes dans un seul commit : feat(Munition) Ajout des munitions, changement de fichiers pour les doc, et changement de la manière dont les images sont importées. |
| Processus Livraison        | I        | il y a deux problèmes avec votre livraison: Elle est restée dans un état `Draft` et il manque la grille d'auto évaluation                                                                                                                                                 |
| Expression User Stories    | I        | je ne trouve ni dans votre repo ni dans votre rapport de formulation claire complète des US. Je vous rappelle que celles-ci doivent être présenté à proximité des maquettes correspondantes.                                                                              |
| Expression Rapport Forme   | A        | veuillez quand même SVP ajouter une image d'illustration en guise de page de garde du rapport                                                                                                                                                                             |
| Expression Rapport Contenu | I        | le contenu est, pour ainsi dire inexistant : pas d'analyse fonctionnelle, pas de diagramme de classes, pas d'objectifs clairement énoncés, aucune conclusion<br>Vous avez pas mal de travail à fournir là-dessus.                                                         |
| Ecologie (gitignore)       | A        |                                                                                                                                                                                                                                                                           |
| Comportement collectif     | A        |                                                                                                                                                                                                                                                                           |
| Comportement individuel    | A        |                                                                                                                                                                                                                                                                           |
## Final

la livraison est incomplète. Il manque les pièces jointes (journal et rapport)

vous n'avez pas tenu compte de mon feed-back à 80 % dans lequel je vous demandais une image illustrative en couverture du rapport

votre introduction contient les objectifs produits, mais il n'y a pas trace des objectifs pédagogiques

le rapport est largement insuffisant au final. L'analyse fonctionnelle ne répond pas aux format demandé (user stories avec tests d'acceptance), il n'y a pas de diagramme de classe, il manque la section décrivant l'usage que vous avez fait de l'IA durant votre projet (demandé)

j'ai bien vu que vous avez un diagramme U ML dans votre dossier doc, mais ce n'est pas suffisant. Il doit être inclus dans le rapport avec des explications complémentaires. D'autre part, j'ai bien insisté pour que le diagramme ne soit pas une capture d'écran mais une image proprement exportée.

le programme est fonctionnel et complet.

Je constate d'après votre journal de travail et vos commits Git que vous avez fourni un effort conséquent pour finaliser le projet. J'aimerais que ces efforts soient récompensés, mais je ne peux pas accepter le rapport dans l'état où il est actuellement. Par conséquent, je vous accorde un délai supplémentaire pour éliminer les gros défauts de votre rapport:

  - pas d'image, illustrative
  - pas d'objectif pédagogique
  - pas de diagramme UML
  - pas de section IA
 
 vous avez jusqu'au 8 novembre pour me refaire une livraison