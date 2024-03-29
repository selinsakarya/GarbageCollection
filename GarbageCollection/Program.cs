﻿public class Program
{
    public static long FinalizedObjects = 0;

    public static long TotalTime = 0;

    public static void Main(string[] args)
    {
        // ObjectLifeTimeExample();

        // ClassVsStruct();

        Console.WriteLine("asd");
    }

    private static void ClassVsStruct()
    {
        PersonClass personClass = new PersonClass
        {
            Name = "Selin 2"
        };

        PersonStruct personStruct = new PersonStruct
        {
            Name = "Selin"
        };

        Console.WriteLine("asd");
    }

    private static void ObjectLifeTimeExample()
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

        Console.WriteLine($"Number of finalized objects: {FinalizedObjects / 1000}K");

        double averageObjectLifeTime = 1.0 * TotalTime / FinalizedObjects;

        Console.WriteLine($"Average resource lifetime: {averageObjectLifeTime} ms");
    }
}