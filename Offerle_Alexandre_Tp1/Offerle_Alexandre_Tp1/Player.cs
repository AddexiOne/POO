namespace Offerle_Alexandre_Tp1;

public class Player
{
   private readonly string FirstName;
   private readonly string LastName;
   private readonly string Alias;
   private Spaceship Spaceship { get; set; }
   private string Name => $"{FirstName} {LastName}";

   public Player(string firstName, string lastName, string alias)
   {
      FirstName = FormatName(firstName);
      LastName = FormatName(lastName);
      Alias = alias;
   }

   private static string FormatName(string property){
      return $"{property[0].ToString().ToUpper()}{property.Substring(1).ToLower()}";
   }

   public void AddSpaceship(Spaceship spaceship)
   {
      Spaceship = spaceship;
   }

   public void ViewSpaceship()
   {
      if (Spaceship != null)
      {
         Console.WriteLine(Spaceship);
      }
      else Console.WriteLine("Aucun vaisseau n'est équipé");
   }

   public void AddWeapon(Weapon weapon)
   {
      Spaceship.AddWeapon(weapon);
   }

   public override string ToString()
   {
      return $"{Alias} ({Name})";
   }

   public override bool Equals(object? obj)
   {
      if (obj is Player player)
      {
         return player.Alias == Alias;
      }
      return false;
   }
}