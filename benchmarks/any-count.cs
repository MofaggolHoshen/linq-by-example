// ============================================================
// Benchmark: Any() vs Count() for List<T> and T[]
// ============================================================
// This benchmark compares the performance of the Any() method and the Count() method (both LINQ extension and direct property) for List<T> and T[] collections. It measures the time taken to check if the collection has any elements and to count the number of elements in the collection for different sizes (10, 1,000, and 100,000). The benchmark is configured to run in-process without emitting code to get accurate results.
// Note: The Count() method from LINQ will have overhead compared to the direct Count property for List<T> and Length property for T[], so the benchmark will show the performance difference between these approaches.
//
// Run in Release mode to get accurate results:
//   dotnet run --configuration Release benchmark/any-count.cs
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

BenchmarkRunner.Run<AnyCountBenchmark>(config);

[MemoryDiagnoser]
public class AnyCountBenchmark
{
    private List<int> _list = null!;
    private int[] _array = null!;

    [Params(10, 1_000, 100_000)]
    public int Size { get; set; }

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(1, Size).ToList();
        _array = Enumerable.Range(1, Size).ToArray();
    }

    // --- Any() ---

    [Benchmark]
    public bool List_Any() => _list.Any();

    [Benchmark]
    public bool Array_Any() => _array.Any();

    // --- Count() LINQ extension method ---

    [Benchmark]
    public int List_Count_Method() => _list.Count();

    [Benchmark]
    public int Array_Count_Method() => _array.Count();

    // --- Count property (direct, no LINQ overhead) ---

    [Benchmark]
    public int List_Count_Property() => _list.Count;

    [Benchmark]
    public int Array_Length_Property() => _array.Length;
}
