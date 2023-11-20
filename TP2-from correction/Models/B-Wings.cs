using SpaceInvadersArmory;

namespace Models;

public class B_Wings : Spaceship
{
    public B_Wings() : base("B-Wings")
    {
        MaxStructure = 30;
        Structure = 30;
        MaxShield = 0;
        Shield = 0;
        AddWeapon(new Weapon(new WeaponBlueprint
            { Name = "Hammer", Type = EWeaponType.Explosive, MinDamage = 1, MaxDamage = 8, ReloadTime = 1.5 }));
    }

    public override void ShootTarget(Spaceship target)
    {
        if (Weapons.Count <= 0) return;
        if (Weapons[0].IsReload)
        {
            Weapons[0].TimeBeforReload -= 1;
            if (Weapons[0].TimeBeforReload <= 0)
            {
                Weapons[0].TimeBeforReload = Weapons[0].ReloadTime;
            }
        }
        else
        {
            target.TakeDamages(Weapons[0].Shoot());
        }
    }

}