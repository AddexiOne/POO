namespace Models;

public class Tardis: Spaceship, IAbility
{

    public Tardis() : base("Tardis")
    {
        Structure = 1;
        Shield = 0;
        MaxStructure = 1;
        MaxShield = 0;
    }

    public void UseAbility(List<Spaceship> spaceships)
    {
        // swap one random ship with another random ship
        if (spaceships.Count <= 0) return;
        int index1 = new Random().Next(0, spaceships.Count);
        int index2 = new Random().Next(0, spaceships.Count);
        (spaceships[index1], spaceships[index2]) = (spaceships[index2], spaceships[index1]);
    }
}