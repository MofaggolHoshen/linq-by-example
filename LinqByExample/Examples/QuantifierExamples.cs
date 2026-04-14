namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ quantifier operators: Any, All, and Contains.
///
/// Best Practices:
/// - Prefer Any() over Count() > 0 for existence checks – Any short-circuits
///   as soon as one matching element is found, while Count enumerates all.
/// - All returns true for an empty sequence (vacuous truth); check that
///   explicitly if your business logic requires a non-empty sequence.
/// - Contains uses the default EqualityComparer; pass a custom comparer when
///   the default equality is not appropriate (e.g., case-insensitive strings).
/// </summary>
public static class QuantifierExamples
{
    /// <summary>Any – returns true if at least one element satisfies the condition.</summary>
    public static bool HasEvenNumber(IEnumerable<int> numbers) =>
        numbers.Any(n => n % 2 == 0);

    /// <summary>Any without predicate – returns true if the sequence is non-empty.</summary>
    public static bool IsNonEmpty<T>(IEnumerable<T> source) =>
        source.Any();

    /// <summary>All – returns true only if every element satisfies the condition.</summary>
    public static bool AllPositive(IEnumerable<int> numbers) =>
        numbers.All(n => n > 0);

    /// <summary>Contains – returns true if the sequence contains a specific element.</summary>
    public static bool ContainsValue(IEnumerable<int> numbers, int value) =>
        numbers.Contains(value);

    /// <summary>Contains with custom comparer (case-insensitive strings).</summary>
    public static bool ContainsIgnoreCase(IEnumerable<string> words, string target) =>
        words.Contains(target, StringComparer.OrdinalIgnoreCase);
}
