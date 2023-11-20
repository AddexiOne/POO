using System.Security.Cryptography;
using SpaceInvadersArmory;

namespace Models;

public class Rocinante: Spaceship
{
    public Rocinante() : base("Rocinante")
    {
        MaxStructure = 3;
        Structure = 3;
        MaxShield = 5;
        Shield = 5;
        AddWeapon(new Weapon(new WeaponBlueprint { Name = "Torpille", Type = EWeaponType.Guided, MinDamage = 3, MaxDamage = 3, ReloadTime = 2 }));
    }

    public override void TakeDamages(double damages)
    {
        // 1 chance of out of 2 to dodge the attack
        if (RandomNumberGenerator.GetInt32(2) == 0)
        {
            return;
        }
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

}