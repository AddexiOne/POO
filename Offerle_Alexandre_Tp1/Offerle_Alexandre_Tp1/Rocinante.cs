namespace Offerle_Alexandre_Tp1;

public class Rocinante : Spaceship
{

    public Rocinante(int maxStructure, int maxShield, Armory armory) : base(maxStructure, maxShield, armory)
    {
    }

    public Rocinante(Armory armory) : base(armory)
    {
    }
}