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
/// How to run:
/// - dotnet run .\source\SetOperationExamples.cs
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

public class Program
{
    public static void Main()
    {
        var nums1 = new[] { 1, 2, 2, 3, 4 };
        var nums2 = new[] { 3, 4, 4, 5, 6 };
        var words = new[] { "apple", "art", "banana", "band", "cherry" };

        Console.WriteLine($"Distinct:      [{string.Join(", ", SetOperationExamples.Distinct(nums1))}]");
        Console.WriteLine($"DistinctByLen: [{string.Join(", ", SetOperationExamples.DistinctByLength(words))}]");
        Console.WriteLine($"Union:         [{string.Join(", ", SetOperationExamples.Union(nums1, nums2))}]");
        Console.WriteLine($"Intersect:     [{string.Join(", ", SetOperationExamples.Intersect(nums1, nums2))}]");
        Console.WriteLine($"Except:        [{string.Join(", ", SetOperationExamples.Except(nums1, nums2))}]");
    }
}
