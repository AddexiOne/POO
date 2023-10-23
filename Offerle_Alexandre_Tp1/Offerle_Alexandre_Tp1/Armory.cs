namespace Offerle_Alexandre_Tp1;

public class Armory
{
    public List<Weapon>? Weapons { get; set; }

    public Armory()
    {
        Init();
    }

    private void Init()
    {
        Weapons = new List<Weapon>
        {
            new("Laser", 10, 20, EWeaponType.Direct),
            new("Missile", 30, 50, EWeaponType.Explosive),
            new("Plasma", 40, 60, EWeaponType.Guided)
        };
    }

    public void ViewArmory()
    {
        Console.WriteLine("Armes disponibles :");
        foreach (Weapon weapon in Weapons)
        {
            Console.WriteLine(weapon);
        }
    }

    public void AddWeapon(Weapon weapon)
    {
        if (Weapons != null && Weapons.Count < 3)
        {
            Weapons.Add(weapon);
        }
        else
        {
            throw new Exception("Vous ne pouvez pas ajouter plus de 3 armes");
        }
    }

    public void RemoveWeapon(Weapon weapon)
    {
        if(Weapons != null && Weapons.Contains(weapon))
        {
            Weapons.Remove(weapon);
        }
        else
        {
            throw new Exception("Cette arme n'est pas équipée");
        }
    }

    public void ClearWeapons()
    {
        if (Weapons != null)
        {
            Weapons.Clear();
        }
    }

    public double AverageDamages()
    {
        if (Weapons != null)
        {
            double average = 0;
            foreach (Weapon weapon in Weapons)
            {
                average += weapon.AverageDamage();
            }
            return average / Weapons.Count;
        }

        return 0;
    }

    public override string ToString()
    {
        return $"{Weapons?.Count} armes" + (Weapons?.Count > 0 ? " : \n\t" : "") + $"{string.Join("\n\t ", Weapons)}";
    }
}