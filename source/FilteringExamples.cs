/// <summary>
/// Demonstrates LINQ filtering operators: Where and OfType.
///
/// Best Practices:
/// - Prefer Where over manual loops for clarity and composability.
/// - Keep predicates short; extract complex predicates into named methods.
/// - OfType&lt;T&gt; is safer than Cast&lt;T&gt; when the collection may contain mixed types.
/// How to run:
/// - dotnet run .\source\FilteringExamples.cs
/// </summary>
public static class FilteringExamples
{
    /// <summary>
    /// Where – returns elements that satisfy a condition.
    /// </summary>
    public static IEnumerable<int> WhereEvenNumbers(IEnumerable<int> numbers) =>
        numbers.Where(n => n % 2 == 0);

    /// <summary>
    /// Where with index – the overload that also receives the element's position.
    /// </summary>
    public static IEnumerable<T> WhereEvenIndex<T>(IEnumerable<T> source) =>
        source.Where((_, index) => index % 2 == 0);

    /// <summary>
    /// OfType – filters elements to only those of the specified type.
    /// </summary>
    public static IEnumerable<string> OfTypeString(IEnumerable<object> items) =>
        items.OfType<string>();
}

public class Program
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 3, 4, 5, 6 };
        var items = new object[] { "hello", 1, "world", 2.5, "!" };

        Console.WriteLine($"WhereEven:      [{string.Join(", ", FilteringExamples.WhereEvenNumbers(numbers))}]");
        Console.WriteLine($"WhereEvenIndex: [{string.Join(", ", FilteringExamples.WhereEvenIndex(numbers))}]");
        Console.WriteLine($"OfTypeString:   [{string.Join(", ", FilteringExamples.OfTypeString(items))}]");
    }
}
