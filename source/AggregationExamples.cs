// dotnet run .\source\AggregationExamples.cs
/// <summary>
/// Demonstrates LINQ aggregation operators: Count, LongCount, Sum, Min, Max,
/// Average, and Aggregate.
///
/// Best Practices:
/// - Prefer the overloads with a selector (e.g., Sum(x => x.Price)) over
///   Select followed by Sum to avoid an extra iteration.
/// - Min/Max with a selector return the min/max of the projected values;
///   use MinBy/MaxBy (available in .NET 6+) to return the element itself.
/// - Aggregate is the general fold operation; always provide a seed when the
///   sequence might be empty to avoid InvalidOperationException.
/// - Use LongCount instead of Count when the sequence may exceed int.MaxValue.
/// </summary>
public static class AggregationExamples
{
    /// <summary>Count – number of elements, optionally filtered.</summary>
    public static int CountAll(IEnumerable<int> numbers) =>
        numbers.Count();

    /// <summary>Count with predicate.</summary>
    public static int CountEven(IEnumerable<int> numbers) =>
        numbers.Count(n => n % 2 == 0);

    /// <summary>Sum – total of all elements.</summary>
    public static int Sum(IEnumerable<int> numbers) =>
        numbers.Sum();

    /// <summary>Min – smallest element.</summary>
    public static int Min(IEnumerable<int> numbers) =>
        numbers.Min();

    /// <summary>Max – largest element.</summary>
    public static int Max(IEnumerable<int> numbers) =>
        numbers.Max();

    /// <summary>MinBy – element with the smallest projected value (.NET 6+).</summary>
    public static string? MinByLength(IEnumerable<string> words) =>
        words.MinBy(w => w.Length);

    /// <summary>MaxBy – element with the largest projected value (.NET 6+).</summary>
    public static string? MaxByLength(IEnumerable<string> words) =>
        words.MaxBy(w => w.Length);

    /// <summary>Average – arithmetic mean.</summary>
    public static double Average(IEnumerable<int> numbers) =>
        numbers.Average();

    /// <summary>
    /// Aggregate – general fold with a seed value.
    /// Here we build a comma-separated string.
    /// </summary>
    public static string AggregateToString(IEnumerable<string> words) =>
        words.Aggregate(string.Empty, (acc, word) =>
            acc.Length == 0 ? word : $"{acc}, {word}");

    /// <summary>
    /// Aggregate with a seed value.
    /// </summary>
    public static int RunningProduct(IEnumerable<int> numbers) =>
        numbers.Aggregate(1, (product, n) => product * n);
}

public class Program
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };
        var words = new[] { "apple", "banana", "cherry" };

        Console.WriteLine($"Count: {AggregationExamples.CountAll(numbers)}");
        Console.WriteLine($"Count Even: {AggregationExamples.CountEven(numbers)}");
        Console.WriteLine($"Sum: {AggregationExamples.Sum(numbers)}");
        Console.WriteLine($"Min: {AggregationExamples.Min(numbers)}");
        Console.WriteLine($"Max: {AggregationExamples.Max(numbers)}");
        Console.WriteLine($"MinBy Length: {AggregationExamples.MinByLength(words)}");
        Console.WriteLine($"MaxBy Length: {AggregationExamples.MaxByLength(words)}");
        Console.WriteLine($"Average: {AggregationExamples.Average(numbers)}");
        Console.WriteLine($"Aggregate to String: {AggregationExamples.AggregateToString(words)}");
        Console.WriteLine($"Running Product: {AggregationExamples.RunningProduct(numbers)}");
    }
}
