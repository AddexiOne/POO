namespace Offerle_Alexandre_Tp1;

class Dart : Spaceship
{
    public Dart(int maxStructure, int maxShield, Armory armory) : base(maxStructure, maxShield, armory)
    {
        MaxStructure = 10;
        MaxShield = 3;
        Weapons = new List<Weapon>{new ("Laser", 2, 3, EWeaponType.Direct, 2)};
    }

    public Dart(Armory armory) : base(armory)
    {
        MaxStructure = 10;
        MaxShield = 3;
        Weapons = new List<Weapon>{new ("Laser", 2, 3, EWeaponType.Direct, 2)};
    }

    override
        public
}