using BenchmarkDotNet.Attributes;

namespace HomeWork03;

[HideColumns("StdDev", "Median", "Gen0", "Gen1")]
[MemoryDiagnoser]
public class ParallelBenchmark
{
    private int[] _data;
    private const int MinValue = -10_000;
    private const int MaxValue = 10_001;

    [Params(100_000, 1_000_000, 10_000_000)]
    public int Size;

    [GlobalSetup]
    public void Setup()
    {
        var r = new Random(42);
        _data = new int[Size];
        Parallel.For(0, Size, i =>
            _data[i] = r.Next(MinValue, MaxValue));
    }

    [Benchmark]
    public long SimpleForSum()
    {
        long sum = 0;
        for (int i = 0; i < Size; i++)
        {
            sum += _data[i];
        }

        return sum;
    }

    [Benchmark]
    public long SimpleLinqSum()
    {
        return _data.Sum(e => (long)e);
    }

    [Benchmark]
    public long ParallelSum()
    {
        long sum = 0;
        var locker = new object();
        Parallel.For(0, Size,
            () => 0L,
            (i, loop, localSum) => localSum + _data[i],
            localSum =>
            {
                lock (locker) sum += localSum;
            });
        return sum;
    }
    
    [Benchmark]
    public long PLinqSum()
    {
        return _data
            .AsParallel()
            .Sum(e => (long)e);
    }
}