using SpaceInvadersArmory;

namespace Models;

public class Dart: Spaceship
{
    public Dart() : base("Dart")
    {
        MaxStructure = 10;
        Structure = 10;
        Shield = 3;
        MaxShield = 3;
        AddWeapon(new Weapon(new WeaponBlueprint { Name = "Laser", Type = EWeaponType.Direct, MinDamage = 2, MaxDamage = 3, ReloadTime = 2 }));
    }

    public override void ShootTarget(Spaceship target)
    {
        if (Weapons.Count <= 0) return;
        if (Weapons[0].IsReload)
        {
            Weapons[0].TimeBeforReload -= 1;
            if (Weapons[0].TimeBeforReload <= 0)
            {
                Weapons[0].TimeBeforReload = 0;
            }
        }
        else
        {
            target.TakeDamages(Weapons[0].Shoot());
        }
    }

    public override void TakeDamages(double damages)
    {
        if (CurrentShield > 0)
        {
            CurrentShield -= damages;
            if (CurrentShield < 0)
            {
                CurrentStructure += CurrentShield;
                CurrentShield = 0;
            }
        }
        else
        {
            CurrentStructure -= damages;
        }
    }

    public override void RepairShield(double repair)
    {
        CurrentShield += repair;
        if (CurrentShield > MaxShield)
        {
            CurrentShield = MaxShield;
        }
    }
}