using System.Diagnostics;

public class WithoutDispose
{
    private Stopwatch _stopwatch;
    
    public WithoutDispose()
    {
        _stopwatch = new Stopwatch();
    }

    ~WithoutDispose()
    {
        _stopwatch.Stop();
        
        Interlocked.Increment(ref Program.FinalisedObjects);
        
        Interlocked.Add(ref Program.TotalTime, _stopwatch.ElapsedMilliseconds);
    }
    
    public void DoWork()
    {
        double j = 0;
        for (int i = 0; i < 1000; i++)
        {
            j = i * i;
        }
    }
}