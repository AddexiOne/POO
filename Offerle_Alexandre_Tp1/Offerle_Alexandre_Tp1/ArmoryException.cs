namespace Offerle_Alexandre_Tp1;

public class ArmoryException : Exception
{
    public ArmoryException(string cetteArmeNEstPasDisponible)
    {
        throw new Exception(cetteArmeNEstPasDisponible);
    }
}