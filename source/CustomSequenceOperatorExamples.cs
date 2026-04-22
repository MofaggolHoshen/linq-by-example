/// <summary>
/// Demonstrates how to build custom LINQ-style sequence operators using
/// iterator methods (yield return) and extension methods on IEnumerable&lt;T&gt;.
///
/// Best Practices:
/// - Implement custom operators as extension methods on IEnumerable&lt;T&gt; to
///   make them composable with the rest of the LINQ pipeline.
/// - Use yield return to keep custom operators lazy (deferred execution);
///   avoid materialising the sequence inside the operator unless necessary.
/// - Validate arguments eagerly (before the first yield) by splitting the
///   method into a public wrapper and a private iterator method.
/// - Prefer existing LINQ operators (Zip, SelectMany, …) before writing
///   custom ones – roll your own only when there is no built-in equivalent.
/// How to run:
/// - dotnet run .\source\CustomSequenceOperatorExamples.cs
/// </summary>
public static class CustomSequenceOperatorExamples
{
    /// <summary>
    /// Interleave – yields elements from two sequences alternately.
    /// e.g. [1,2,3] interleaved with [a,b,c] → [1,a,2,b,3,c]
    /// </summary>
    public static IEnumerable<T> Interleave<T>(IEnumerable<T> first, IEnumerable<T> second)
    {
        using var e1 = first.GetEnumerator();
        using var e2 = second.GetEnumerator();
        bool has1 = e1.MoveNext(), has2 = e2.MoveNext();
        while (has1 || has2)
        {
            if (has1) { yield return e1.Current; has1 = e1.MoveNext(); }
            if (has2) { yield return e2.Current; has2 = e2.MoveNext(); }
        }
    }

    /// <summary>
    /// Batch – splits a sequence into chunks of a given size (like .NET 6 Chunk).
    /// </summary>
    public static IEnumerable<T[]> Batch<T>(IEnumerable<T> source, int size)
    {
        if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size), "Size must be positive.");
        return BatchIterator(source, size);
    }

    private static IEnumerable<T[]> BatchIterator<T>(IEnumerable<T> source, int size)
    {
        var bucket = new List<T>(size);
        foreach (var item in source)
        {
            bucket.Add(item);
            if (bucket.Count == size)
            {
                yield return bucket.ToArray();
                bucket.Clear();
            }
        }
        if (bucket.Count > 0)
            yield return bucket.ToArray();
    }

    /// <summary>
    /// DotProduct – combines two numeric sequences pairwise by multiplying then summing.
    /// </summary>
    public static int DotProduct(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Zip(second, (a, b) => a * b).Sum();
}

public class Program
{
    public static void Main()
    {
        int[] nums = { 1, 2, 3, 4 };
        int[] other = { 10, 20, 30, 40 };

        Console.WriteLine("Interleave:");
        Console.WriteLine(string.Join(", ", CustomSequenceOperatorExamples.Interleave(nums, other)));

        Console.WriteLine("\nBatch (size 2):");
        foreach (var chunk in CustomSequenceOperatorExamples.Batch(nums, 2))
            Console.WriteLine($"  [{string.Join(", ", chunk)}]");

        int[] a = { 1, 2, 3 };
        int[] b = { 4, 5, 6 };
        Console.WriteLine($"\nDot product of [1,2,3] · [4,5,6]: {CustomSequenceOperatorExamples.DotProduct(a, b)}");
    }
}
