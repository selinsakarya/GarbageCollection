using System.Diagnostics;

public class WithDispose : IDisposable
{
    private Stopwatch _stopwatch;

    private bool _isDisposed;

    public WithDispose()
    {
        _stopwatch = new Stopwatch();

        _stopwatch.Start();
    }

    ~WithDispose()
    {
        Dispose(true);
    }
    
    public void DoWork()
    {
        double j = 0;
        for (int i = 0; i < 1000; i++)
        {
            j = i * i;
        }
    }

    public void Dispose()
    {
        Dispose(false);
        
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool isCalledFromFinalizer)
    {
        if (!_isDisposed)
        {
            _stopwatch.Stop();

            Interlocked.Increment(ref Program.FinalizedObjects);

            Interlocked.Add(ref Program.TotalTime, _stopwatch.ElapsedMilliseconds);

            _isDisposed = true;
        }

        Console.WriteLine($"Is called from finalizer: {isCalledFromFinalizer}");
    }
}