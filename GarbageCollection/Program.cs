public class Program
{
    public static long FinalizedObjects = 0;
    
    public static long TotalTime = 0;
    
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        for (int i = 0; i < 500000; i++)
        {
            // WithoutDispose obj = new WithoutDispose();
            // obj.DoWork();

            using (WithDispose disposableObj = new WithDispose())
            {
                disposableObj.DoWork();
            }
        }

        Console.WriteLine($"Number of finalized objects: {FinalizedObjects/1000}K");
        
        double averageObjectLifeTime = 1.0 * TotalTime / FinalizedObjects;
        
        Console.WriteLine($"Average resource lifetime: {averageObjectLifeTime} ms");
    }
}