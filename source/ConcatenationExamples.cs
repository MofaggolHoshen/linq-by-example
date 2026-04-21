/// <summary>
/// Demonstrates LINQ concatenation operator: Concat.
///
/// Best Practices:
/// - Concat uses deferred execution; neither sequence is evaluated until
///   you enumerate the result.
/// - Concat preserves duplicates – use Union when you want distinct elements
///   across both sequences.
/// - Prefer Concat over manual loops or list.AddRange when you need a
///   single lazy pass over two sequences without allocating a new collection.
/// How to run:
/// - dotnet run .\source\ConcatenationExamples.cs
/// </summary>
public static class ConcatenationExamples
{
    /// <summary>Concat – joins two sequences end-to-end.</summary>
    public static IEnumerable<int> ConcatNumbers(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Concat(second);

    /// <summary>Concat – joins two string sequences, preserving duplicates.</summary>
    public static IEnumerable<string> ConcatWords(IEnumerable<string> first, IEnumerable<string> second) =>
        first.Concat(second);

    /// <summary>
    /// Concat followed by Distinct – equivalent to Union.
    /// Useful when you want to make the intent of "merge then deduplicate" explicit.
    /// </summary>
    public static IEnumerable<int> ConcatDistinct(IEnumerable<int> first, IEnumerable<int> second) =>
        first.Concat(second).Distinct();
}

public class Program
{
    public static void Main()
    {
        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        Console.WriteLine("Concat numbers:");
        foreach (var n in ConcatenationExamples.ConcatNumbers(numbersA, numbersB))
            Console.Write($"{n} ");
        Console.WriteLine();

        string[] wordsA = { "apple", "banana" };
        string[] wordsB = { "cherry", "banana" };

        Console.WriteLine("\nConcat words (with duplicates):");
        Console.WriteLine(string.Join(", ", ConcatenationExamples.ConcatWords(wordsA, wordsB)));

        Console.WriteLine("\nConcat + Distinct (no duplicates):");
        Console.WriteLine(string.Join(", ", ConcatenationExamples.ConcatDistinct(numbersA, numbersB)));
    }
}
