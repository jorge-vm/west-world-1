namespace Westworld.Library
{
    public class EntityNames
    {
        public static string GetNameOfEntity(int n)
        {
            switch ((EntityType)n)
            {
                case EntityType.Miner:

                    return "Miner Bob: ";
                case EntityType.Wife:

                    return "Elsa: ";
                default:

                    return "UNKNOWN!";
            }
        }
    }
}