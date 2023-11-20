using System.Security.Cryptography;
using SpaceInvadersArmory;

namespace Models;

public class ViperMKII : Spaceship

{

    public ViperMKII() : base("Viper MKII")
    {
        MaxStructure = 10;
        Structure = 10;
        MaxShield = 3;
        Shield = 3;
        AddWeapon(new Weapon(new WeaponBlueprint
            { Name = "Mitrailleuse", Type = EWeaponType.Direct, MinDamage = 6, MaxDamage = 8, ReloadTime = 1 }));
        AddWeapon(new Weapon(new WeaponBlueprint
            { Name = "EMG", Type = EWeaponType.Explosive, MinDamage = 1, MaxDamage = 7, ReloadTime = 1.5 }));
        AddWeapon(new Weapon(new WeaponBlueprint
            { Name = "Missile", Type = EWeaponType.Guided, MinDamage = 4, MaxDamage = 100, ReloadTime = 4 }));
    }

    public override void ShootTarget(Spaceship target)
    {
        if (Weapons.Count <= 0) return;
        var weapon = Weapons[RandomNumberGenerator.GetInt32(Weapons.Count)];
        if (weapon.IsReload)
        {
            weapon.TimeBeforReload -= 1;
            if (weapon.TimeBeforReload <= 0)
            {
                weapon.TimeBeforReload = weapon.ReloadTime;
            }
        }
        else
        {
            target.TakeDamages(weapon.Shoot());
        }
    }
}
