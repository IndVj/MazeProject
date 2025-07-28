## Comment exécuter
1. Clonez ce dépôt.
2. Ouvrez la solution dans Visual Studio (ou exécutez `dotnet run` depuis la ligne de commande).
3. Entrez un nom de joueur lorsque vous y êtes invité.
4. Le programme naviguera automatiquement dans le labyrinthe jusqu’à ce qu’il gagne ou qu’aucun déplacement ne soit possible.

## Notes:
- La logique principale est implémentée dans `MazeSolver.cs`.
- Les interactions avec l’APIs sont gérées par `MazeApiService.cs`.
- Le programme évite les pièges et tente d’atteindre la sortie (`stop`) avec un minimum de mouvements.
- Des tests unitaires sont inclus pour la logique de prise de décision clé.
