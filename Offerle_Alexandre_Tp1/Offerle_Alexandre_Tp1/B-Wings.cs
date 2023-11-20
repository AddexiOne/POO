namespace Offerle_Alexandre_Tp1;

public class B_Wings : Spaceship
{

    public B_Wings(int maxStructure, int maxShield, Armory armory) : base(maxStructure, maxShield, armory)
    {
        MaxStructure = 30;
        MaxShield = 0;
        Weapons = new List<Weapon>{new("Hammer", 1, 8, EWeaponType.Explosive, 1.5f)};
    }

    public B_Wings(Armory armory) : base(armory)
    {
        MaxStructure = 30;
        MaxShield = 0;
        Weapons = new List<Weapon>{new("Hammer", 1, 8, EWeaponType.Explosive, 1.5f)};
    }
}