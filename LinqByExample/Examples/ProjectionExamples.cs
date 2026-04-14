namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ projection operators: Select and SelectMany.
///
/// Best Practices:
/// - Use Select to transform each element into a new shape (projection).
/// - Use SelectMany to flatten nested collections into a single sequence.
/// - Prefer anonymous types or records for intermediate projections instead of
///   creating full classes just for a query result.
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
