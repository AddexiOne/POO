namespace Offerle_Alexandre_Tp1;

public class Spaceship
{
    private int MaxStructure { get; set; }
    private int MaxShield { get; set; }
    private int CurrentShield { get; set; }
    private List<Weapon> Weapons { get; set; } = new();
    private int CurrentStructure { get; set; }
    private bool isDestroyed => CurrentStructure <= 0;
    private Armory Armory { get; set; }

    public Spaceship(int maxStructure, int maxShield, Armory armory)
    {
        MaxStructure = maxStructure;
        MaxShield = maxShield;
        CurrentShield = maxShield;
        CurrentStructure = maxStructure;
        Armory = armory;
    }

    public Spaceship(Armory armory) : this(100, 50, armory)
    {
    }


    public void AddWeapon(Weapon weapon)
    {
        if (Armory.Weapons != null && Armory.Weapons.Contains(weapon))
        {
            if (Weapons.Count < 3)
            {
                Weapons.Add(weapon);
            }
            else
            {
                throw new Exception("Vous ne pouvez pas ajouter plus de 3 armes");
            }
        }
        else
        {
            throw new ArmoryException("Cette arme n'est pas disponible");
        }
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if (Weapons.Contains(weapon))
        {
            Weapons.Remove(weapon);
        }
        else
        {
            throw new Exception("Cette arme n'est pas équipée");
        }
    }

    public void ClearWeapons() => Weapons.Clear();

    public void ViewWeapons()
    {
        Console.WriteLine("Armes équipées :");
        foreach (Weapon weapon in Weapons)
        {
            Console.WriteLine(weapon);
        }
    }

    public double AverageDamages()
    {
        return Weapons.Average(weapon => weapon.AverageDamage());
    }

    public void ViewShip()
    {
        Console.WriteLine(this);
    }

    public override string ToString()
    {
        return $"Structure : {CurrentStructure}/{MaxStructure} - Bouclier : {CurrentShield}/{MaxShield}" +
               $"{(isDestroyed ? " - Détruit" : "")}" +
               "\nArmes : " + string.Join(", ", Weapons);
    }
}