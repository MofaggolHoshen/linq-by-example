/// <summary>
/// Demonstrates LINQ miscellaneous operator: SequenceEqual.
///
/// Best Practices:
/// - SequenceEqual compares element by element in order; two sequences with
///   the same elements in a different order are NOT equal.
/// - Pass a custom IEqualityComparer&lt;T&gt; as a second argument for
///   case-insensitive or domain-specific equality comparisons.
/// - SequenceEqual short-circuits as soon as a mismatching pair is found,
///   so it can be efficient on long sequences that differ early.
/// How to run:
/// - dotnet run .\source\MiscellaneousExamples.cs
/// </summary>
public static class MiscellaneousExamples
{
    /// <summary>SequenceEqual – true when both sequences have the same elements in the same order.</summary>
    public static bool AreEqual(IEnumerable<string> first, IEnumerable<string> second) =>
        first.SequenceEqual(second);

    /// <summary>SequenceEqual with a custom comparer – case-insensitive comparison.</summary>
    public static bool AreEqualIgnoreCase(IEnumerable<string> first, IEnumerable<string> second) =>
        first.SequenceEqual(second, StringComparer.OrdinalIgnoreCase);

    /// <summary>SequenceEqual on integer sequences.</summary>
    public static bool AreEqualNumbers(IEnumerable<int> first, IEnumerable<int> second) =>
        first.SequenceEqual(second);
}

public class Program
{
    public static void Main()
    {
        var wordsA = new[] { "cherry", "apple", "blueberry" };
        var wordsB = new[] { "cherry", "apple", "blueberry" };
        var wordsC = new[] { "apple", "blueberry", "cherry" };
        var wordsD = new[] { "Cherry", "Apple", "Blueberry" };

        Console.WriteLine($"Same order match:       {MiscellaneousExamples.AreEqual(wordsA, wordsB)}");
        Console.WriteLine($"Different order match:  {MiscellaneousExamples.AreEqual(wordsA, wordsC)}");
        Console.WriteLine($"Case-insensitive match: {MiscellaneousExamples.AreEqualIgnoreCase(wordsA, wordsD)}");

        var nums1 = new[] { 1, 2, 3 };
        var nums2 = new[] { 1, 2, 3 };
        var nums3 = new[] { 1, 2, 4 };

        Console.WriteLine($"\nNumbers equal:     {MiscellaneousExamples.AreEqualNumbers(nums1, nums2)}");
        Console.WriteLine($"Numbers not equal: {MiscellaneousExamples.AreEqualNumbers(nums1, nums3)}");
    }
}
