namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ element operators: First, FirstOrDefault, Last,
/// LastOrDefault, Single, SingleOrDefault, ElementAt, and ElementAtOrDefault.
///
/// Best Practices:
/// - Prefer the *OrDefault variants when the sequence may be empty to avoid
///   InvalidOperationException; check the return value for null / default.
/// - Single and SingleOrDefault assert that at most one element matches; they
///   are useful when your business rules guarantee uniqueness.
/// - ElementAt is O(1) for IList&lt;T&gt; but O(n) for arbitrary IEnumerable&lt;T&gt;;
///   prefer direct indexing on arrays/lists when performance matters.
/// - Pass a default value as the second argument to *OrDefault (.NET 6+) to
///   avoid null-checks on value types.
/// </summary>
public static class ElementOperationExamples
{
    /// <summary>First – returns the first element (throws if empty).</summary>
    public static T First<T>(IEnumerable<T> source) =>
        source.First();

    /// <summary>FirstOrDefault – returns the first element or default.</summary>
    public static T? FirstOrDefault<T>(IEnumerable<T> source) =>
        source.FirstOrDefault();

    /// <summary>First with predicate – first element matching the condition.</summary>
    public static int FirstEven(IEnumerable<int> numbers) =>
        numbers.First(n => n % 2 == 0);

    /// <summary>Last – returns the last element (throws if empty).</summary>
    public static T Last<T>(IEnumerable<T> source) =>
        source.Last();

    /// <summary>LastOrDefault – returns the last element or default.</summary>
    public static T? LastOrDefault<T>(IEnumerable<T> source) =>
        source.LastOrDefault();

    /// <summary>Single – returns the only element (throws if 0 or more than 1).</summary>
    public static T Single<T>(IEnumerable<T> source) =>
        source.Single();

    /// <summary>SingleOrDefault – single element or default (throws if more than 1).</summary>
    public static T? SingleOrDefault<T>(IEnumerable<T> source) =>
        source.SingleOrDefault();

    /// <summary>ElementAt – element at the given index (throws if out of range).</summary>
    public static T ElementAt<T>(IEnumerable<T> source, int index) =>
        source.ElementAt(index);

    /// <summary>ElementAtOrDefault – element at index or default if out of range.</summary>
    public static T? ElementAtOrDefault<T>(IEnumerable<T> source, int index) =>
        source.ElementAtOrDefault(index);
}
