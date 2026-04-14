namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ set-operation operators: Distinct, DistinctBy, Union,
/// UnionBy, Intersect, IntersectBy, Except, and ExceptBy.
///
/// Best Practices:
/// - All set operators use equality by default; pass a custom IEqualityComparer
///   when you need case-insensitive or domain-specific equality.
/// - The *By variants (.NET 6+) let you compare by a key selector without
///   implementing a full comparer.
/// - Set operators use hash-based lookups internally (O(n+m)) – they are far
///   more efficient than nested loops for membership tests.
/// </summary>
public static class SetOperationExamples
{
    /// <summary>Distinct – removes duplicate elements.</summary>
    public static IEnumerable<int> Distinct(IEnumerable<int> numbers) =>
        numbers.Distinct();

    /// <summary>DistinctBy – removes elements with duplicate keys (.NET 6+).</summary>
    public static IEnumerable<string> DistinctByLength(IEnumerable<string> words) =>
        words.DistinctBy(w => w.Length);

    /// <summary>Union – all elements from both sequences, duplicates removed.</summary>
    public static IEnumerable<int> Union(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Union(second);

    /// <summary>Intersect – elements present in both sequences.</summary>
    public static IEnumerable<int> Intersect(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Intersect(second);

    /// <summary>Except – elements in the first sequence not in the second.</summary>
    public static IEnumerable<int> Except(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Except(second);
}
