namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ generation operators: Range, Repeat, and Empty.
///
/// Best Practices:
/// - Enumerable.Range generates a lazy sequence; combine it with Select to
///   produce any arithmetic series without allocating an array up front.
/// - Enumerable.Repeat is convenient for initialising test data or filling
///   gaps; for large counts prefer a lazy approach to avoid memory pressure.
/// - Enumerable.Empty&lt;T&gt;() returns a cached, allocation-free empty sequence;
///   use it instead of new T[0] or Enumerable.Range(0, 0) for clarity.
/// </summary>
public static class GenerationExamples
{
    /// <summary>Range – generates a sequence of integers from start, count elements.</summary>
    public static IEnumerable<int> Range(int start, int count) =>
        Enumerable.Range(start, count);

    /// <summary>
    /// Range with Select – squares of the first N natural numbers.
    /// </summary>
    public static IEnumerable<int> Squares(int count) =>
        Enumerable.Range(1, count).Select(n => n * n);

    /// <summary>Repeat – generates a sequence that repeats an element N times.</summary>
    public static IEnumerable<T> Repeat<T>(T element, int count) =>
        Enumerable.Repeat(element, count);

    /// <summary>Empty – returns a cached, empty sequence of the given type.</summary>
    public static IEnumerable<T> Empty<T>() =>
        Enumerable.Empty<T>();
}
