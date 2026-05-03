/// <summary>
/// Demonstrates LINQ partitioning operators: Take, TakeWhile, Skip,
/// SkipWhile, and Chunk.
///
/// Best Practices:
/// - Take and Skip are the building blocks for manual pagination; use them
///   together (e.g., Skip((page-1)*size).Take(size)).
/// - TakeWhile/SkipWhile act on a contiguous prefix of the sequence – they
///   stop inspecting elements once the predicate first fails.
/// - Chunk (.NET 6+) is cleaner than manual batching loops and avoids the
///   common off-by-one errors.
/// How to run:
/// - dotnet run .\source\PartitioningExamples.cs
/// </summary>
public static class PartitioningExamples
{
    /// <summary>Take – returns the first N elements.</summary>
    public static IEnumerable<T> TakeFirst<T>(IEnumerable<T> source, int count) =>
        source.Take(count);

    /// <summary>TakeWhile – returns elements while the condition holds.</summary>
    public static IEnumerable<int> TakeWhilePositive(IEnumerable<int> numbers) =>
        numbers.TakeWhile(n => n > 0);

    /// <summary>Skip – bypasses the first N elements.</summary>
    public static IEnumerable<T> SkipFirst<T>(IEnumerable<T> source, int count) =>
        source.Skip(count);

    /// <summary>SkipWhile – bypasses elements while the condition holds.</summary>
    public static IEnumerable<int> SkipWhileNegative(IEnumerable<int> numbers) =>
        numbers.SkipWhile(n => n < 0);

    /// <summary>
    /// Page – combines Skip and Take to implement cursor-based pagination.
    /// </summary>
    public static IEnumerable<T> Page<T>(IEnumerable<T> source, int pageNumber, int pageSize) =>
        source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

    /// <summary>Chunk – splits the sequence into fixed-size arrays (.NET 6+).</summary>
    public static IEnumerable<T[]> ChunkBy<T>(IEnumerable<T> source, int size) =>
        source.Chunk(size);
}

public class Program
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var mixed = new[] { 2, 4, 6, 1, 3, 5 };
        var withNegs = new[] { -3, -1, 0, 2, 4 };

        Console.WriteLine($"TakeFirst(3):      [{string.Join(", ", PartitioningExamples.TakeFirst(numbers, 3))}]");
        Console.WriteLine($"TakeWhilePositive: [{string.Join(", ", PartitioningExamples.TakeWhilePositive(mixed))}]");
        Console.WriteLine($"SkipFirst(3):      [{string.Join(", ", PartitioningExamples.SkipFirst(numbers, 3))}]");
        Console.WriteLine($"SkipWhileNeg:      [{string.Join(", ", PartitioningExamples.SkipWhileNegative(withNegs))}]");
        Console.WriteLine($"Page(2, size 3):   [{string.Join(", ", PartitioningExamples.Page(numbers, 2, 3))}]");
        Console.WriteLine("ChunkBy(3):");
        foreach (var chunk in PartitioningExamples.ChunkBy(numbers, 3))
            Console.WriteLine($"  [{string.Join(", ", chunk)}]");
    }
}
