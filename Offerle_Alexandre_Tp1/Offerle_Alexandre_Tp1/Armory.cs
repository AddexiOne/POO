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
            new("Laser", 2, 3, EWeaponType.Direct, 2),
            new("Hammer", 1, 8, EWeaponType.Explosive, 1.5f),
            new("Torpille", 3, 3, EWeaponType.Guided, 2),
            new("Mitrailleuse", 6, 8, EWeaponType.Direct, 1),
            new("EMG", 1, 7, EWeaponType.Explosive, 1.5f),
            new("Missile", 4, 100, EWeaponType.Guided, 4)
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