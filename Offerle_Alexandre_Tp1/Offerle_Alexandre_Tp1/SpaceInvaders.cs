namespace Offerle_Alexandre_Tp1;

public class SpaceInvaders
{
/*
1)      Créer une classe SpaceInvaders possédant un constructeur vide.
2)      Ajouter la méthode Main() à la classe. Ce sera le point d’entrée de notre jeu.
3)      Créer une fonction privée Init() créant 3 joueurs.
4)      Appeler la fonction Init() depuis le constructeur de la classe, puis instancier un nouveau SpaceInvaders dans la méthode Main().
5)      Afficher la liste des joueurs à l’écran en utilisant un appel à la fonction ToString() de la classe Player.
*/

      private Player[]? _players;

      private SpaceInvaders()
      {
         Init();
      }
   
      private void Init()
      {
         Armory armory = new Armory();
         _players = new Player[3];
         _players[0] = new Player("Alexandre", "Offerle", "Alex");
         _players[0].AddSpaceship(new Spaceship(armory));
         _players[1] = new Player("John", "Doe", "John");
         _players[2] = new Player("Jane", "Doe", "Jane");

      }
   
      public static void Main()
      {
         SpaceInvaders spaceInvaders = new SpaceInvaders();
         if (spaceInvaders._players != null)
            foreach (Player player in spaceInvaders._players)
            {
               Console.WriteLine(player);
               player.ViewSpaceship();
            }
      }
   
      public override string ToString()
      {
         string players = "";
         foreach (Player player in _players)
         {
               players += $"{player}\n";
         }
   
         return players;
      }

}