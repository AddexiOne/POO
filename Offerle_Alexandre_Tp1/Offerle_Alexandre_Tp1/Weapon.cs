namespace Offerle_Alexandre_Tp1;

public class Weapon
{
    public Weapon(string name, int minDamage, int maxDamage, EWeaponType type)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Type = type;
    }

    private string Name { get; set; }
    private int MinDamage { get; set; }
    private int MaxDamage { get; set; }
    private EWeaponType Type { get; set; }

    public override string ToString()
    {
        return $"{Name} => {Type} ({MinDamage} - {MaxDamage})";
    }

    public double AverageDamage()
    {
        return (MaxDamage + (double)MinDamage) / 2;
    }
}