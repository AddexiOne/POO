namespace Offerle_Alexandre_Tp1;

public class Weapon
{
    public Weapon(string name, int minDamage, int maxDamage, EWeaponType type, float reloadTime)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
        Type = type;
        ReloadTime = reloadTime;
        TimeBeforeReload = ReloadTime;
    }

    private string Name { get; set; }
    private int MinDamage { get; set; }
    private int MaxDamage { get; set; }
    private EWeaponType Type { get; set; }
    private float ReloadTime { get; set; }
    private float TimeBeforeReload { get; set; }

    public override string ToString()
    {
        return $"{Name} => {Type} ({MinDamage} - {MaxDamage})";
    }

    public double AverageDamage()
    {
        return (MaxDamage + (double)MinDamage) / 2;
    }

    public int Shoot()
    {
        if (TimeBeforeReload != 0)
        {
            return 0;
        }
        else
        {
            switch (Type)
            {
                case EWeaponType.Direct:
                    return new Random().Next(0, 10) == 0 ? 0 : new Random().Next(MinDamage, MaxDamage + 1);
                case EWeaponType.Explosive:
                    TimeBeforeReload = ReloadTime * 2;
                    return new Random().Next(0, 4) == 0 ? 0 : new Random().Next(MinDamage * 2, MaxDamage * 2 + 1);
                case EWeaponType.Guided:
                    return MinDamage;
            }
            return 0;
        }
    }
}