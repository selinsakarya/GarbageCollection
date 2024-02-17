public class Program
{
    public static long FinalisedObjects = 0;
    
    public static long TotalTime = 0;
    
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        for (int i = 0; i < 500000; i++)
        {
            WithoutDispose obj = new WithoutDispose();
            
            obj.DoWork();
        }

        Console.WriteLine($"Number of finalised objects: {FinalisedObjects/1000}K");
        
        double averageObjectLifeTime = 1.0 * TotalTime / FinalisedObjects;
        
        Console.WriteLine($"Average resource lifetime: {averageObjectLifeTime}");
    }
}