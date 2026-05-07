/// <summary>
/// Demonstrates LINQ query execution modes: deferred and immediate.
///
/// Best Practices:
/// - Most LINQ operators (Where, Select, OrderBy, …) use deferred execution –
///   the query is not run until you enumerate it (foreach / ToList / ToArray).
/// - Operators that return a scalar or materialise the result (Count, ToList,
///   ToArray, First, Max, …) trigger immediate execution.
/// - Deferred execution means the query reflects the data source at the time
///   of enumeration, not at the time of definition – be aware of this when
///   the source is mutated between definition and enumeration.
/// - Call ToList() / ToArray() to snapshot a deferred query and prevent
///   multiple enumerations of expensive sources.
/// How to run:
/// - dotnet run .\source\QueryExecutionExamples.cs
/// </summary>
public static class QueryExecutionExamples
{
    /// <summary>
    /// Deferred execution – the query body runs only when enumerated.
    /// Returns the query object; execution happens at the call site.
    /// </summary>
    public static IEnumerable<int> DeferredQuery(int[] numbers) =>
        numbers.Where(n => n <= 3);

    /// <summary>
    /// Immediate execution – ToList() forces evaluation right now and
    /// snapshots the results into a new List&lt;int&gt;.
    /// </summary>
    public static List<int> ImmediateQuery(int[] numbers) =>
        numbers.Where(n => n <= 3).ToList();

    /// <summary>
    /// Demonstrates that a deferred query re-evaluates against the current
    /// state of the source each time it is enumerated.
    /// </summary>
    public static (List<int> before, List<int> after) QueryReEvaluatesOnChange()
    {
        int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        var lowNumbers = numbers.Where(n => n <= 3);
        var before = lowNumbers.ToList();

        // Mutate the source.
        for (int i = 0; i < numbers.Length; i++)
            numbers[i] = -numbers[i];  // all values now negative, all <= 3

        var after = lowNumbers.ToList();
        return (before, after);
    }
}

public class Program
{
    public static void Main()
    {
        int[] source = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

        Console.WriteLine("Deferred query (numbers <= 3):");
        foreach (var n in QueryExecutionExamples.DeferredQuery(source))
            Console.Write($"{n} ");
        Console.WriteLine();

        Console.WriteLine("\nImmediate query (numbers <= 3, snapshotted to List):");
        Console.WriteLine(string.Join(", ", QueryExecutionExamples.ImmediateQuery(source)));

        var (before, after) = QueryExecutionExamples.QueryReEvaluatesOnChange();
        Console.WriteLine("\nDeferred query before source mutation:");
        Console.WriteLine(string.Join(", ", before));
        Console.WriteLine("Deferred query after source mutation (all negated):");
        Console.WriteLine(string.Join(", ", after));
    }
}
