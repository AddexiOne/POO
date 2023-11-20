namespace Models;

public class F_18: Spaceship, IAbility
{

    public F_18() : base("F-18")
    {
        Structure = 15;
        Shield = 0;
        MaxStructure = 15;
        MaxShield = 0;
    }


    public void UseAbility(List<Spaceship> spaceships)
    {
        if (spaceships.Count <= 0) return;
        int index = spaceships.IndexOf(this);
        if (index >= 0 && index < spaceships.Count -1)
        {
            spaceships[index +1].TakeDamages(10);
            spaceships[index -1].TakeDamages(10);
        }
    }
}