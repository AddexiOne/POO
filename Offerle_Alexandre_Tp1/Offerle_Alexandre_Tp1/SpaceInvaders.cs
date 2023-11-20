namespace Offerle_Alexandre_Tp1;

public class SpaceInvaders
{
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
         _players[0].AddSpaceship(new B_Wings(armory));
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