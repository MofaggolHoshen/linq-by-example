// ============================================================
// Benchmark: Aggregation LINQ methods (Count, Sum, Min, Max, Average, Aggregate)
// ============================================================
// This benchmark compares the performance of common LINQ aggregation operators
// against equivalent manual loops for List<int> and int[] collections across
// different sizes (10, 1,000, and 10,000 elements).
//
// Run in Release mode to get accurate results:
//   dotnet run --configuration Release benchmarks/aggregation.cs
// ============================================================
#:package BenchmarkDotNet@0.14.0

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

var config = DefaultConfig.Instance
    .AddJob(Job.Default
        .WithStrategy(RunStrategy.Throughput)
        .WithToolchain(InProcessNoEmitToolchain.Instance));

BenchmarkRunner.Run<AggregationBenchmark>(config);

[MemoryDiagnoser]
public class AggregationBenchmark
{
    private List<int> _list = null!;
    private int[] _array = null!;

    [Params(10, 1_000, 10_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(1, Size).ToList();
        _array = Enumerable.Range(1, Size).ToArray();
    }

    // --- Count ---

    [Benchmark]
    public int List_Count() => _list.Count();

    [Benchmark]
    public int Array_Count() => _array.Count();

    [Benchmark]
    public int List_Count_WithPredicate() => _list.Count(n => n % 2 == 0);

    [Benchmark]
    public int Array_Count_WithPredicate() => _array.Count(n => n % 2 == 0);

    // --- Sum ---

    [Benchmark]
    public long List_Sum() => _list.Sum();

    [Benchmark]
    public long Array_Sum() => _array.Sum();

    [Benchmark]
    public long List_Sum_ManualLoop()
    {
        long sum = 0;
        foreach (var n in _list) sum += n;
        return sum;
    }

    [Benchmark]
    public long Array_Sum_ManualLoop()
    {
        long sum = 0;
        foreach (var n in _array) sum += n;
        return sum;
    }

    // --- Min / Max ---

    [Benchmark]
    public int List_Min() => _list.Min();

    [Benchmark]
    public int Array_Min() => _array.Min();

    [Benchmark]
    public int List_Max() => _list.Max();

    [Benchmark]
    public int Array_Max() => _array.Max();

    // --- Average ---

    [Benchmark]
    public double List_Average() => _list.Average();

    [Benchmark]
    public double Array_Average() => _array.Average();

    // --- Aggregate (product with seed) ---

    [Benchmark]
    public long List_Aggregate_Product() => _list.Aggregate(1L, (acc, n) => acc * n);

    [Benchmark]
    public long Array_Aggregate_Product() => _array.Aggregate(1L, (acc, n) => acc * n);
}
