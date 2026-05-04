/// <summary>
/// Demonstrates LINQ projection operators: Select and SelectMany.
///
/// Best Practices:
/// - Use Select to transform each element into a new shape (projection).
/// - Use SelectMany to flatten nested collections into a single sequence.
/// - Prefer anonymous types or records for intermediate projections instead of
///   creating full classes just for a query result.
/// How to run:
/// - dotnet run .\source\ProjectionExamples.cs
/// </summary>
public static class ProjectionExamples
{
    /// <summary>
    /// Select – transforms each element.
    /// </summary>
    public static IEnumerable<string> SelectNames(IEnumerable<string> names) =>
        names.Select(name => name.ToUpperInvariant());

    /// <summary>
    /// Select with index – also exposes the element's zero-based position.
    /// </summary>
    public static IEnumerable<string> SelectWithIndex(IEnumerable<string> names) =>
        names.Select((name, index) => $"{index + 1}. {name}");

    /// <summary>
    /// SelectMany – flattens a collection of collections into one sequence.
    /// </summary>
    public static IEnumerable<int> SelectManyNumbers(IEnumerable<IEnumerable<int>> groups) =>
        groups.SelectMany(group => group);

    /// <summary>
    /// SelectMany with result selector – joins parent and child element.
    /// </summary>
    public static IEnumerable<string> SelectManyWithResult(
        IEnumerable<(string Category, IEnumerable<string> Items)> catalog) =>
        catalog.SelectMany(
            entry => entry.Items,
            (entry, item) => $"{entry.Category}: {item}");
}

public class Program
{
    public static void Main()
    {
        var names = new[] { "alice", "bob", "carol" };
        var groups = new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5 } };
        var catalog = new (string Category, IEnumerable<string> Items)[]
        {
            ("Fruit",  new[] { "apple", "banana" }),
            ("Veggie", new[] { "carrot" }),
        };

        Console.WriteLine($"SelectNames:     [{string.Join(", ", ProjectionExamples.SelectNames(names))}]");
        Console.WriteLine($"SelectWithIndex: [{string.Join(", ", ProjectionExamples.SelectWithIndex(names))}]");
        Console.WriteLine($"SelectMany:      [{string.Join(", ", ProjectionExamples.SelectManyNumbers(groups))}]");
        Console.WriteLine("SelectManyWithResult:");
        foreach (var item in ProjectionExamples.SelectManyWithResult(catalog))
            Console.WriteLine($"  {item}");
    }
}
