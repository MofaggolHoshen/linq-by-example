// dotnet run .\source\ConversionExamples.cs
/// <summary>
/// Demonstrates LINQ conversion operators: ToArray, ToList, ToDictionary,
/// ToHashSet, Cast, AsEnumerable, and AsQueryable.
///
/// Best Practices:
/// - Call ToList / ToArray to materialise a deferred LINQ query and prevent
///   multiple enumerations.
/// - ToDictionary throws on duplicate keys; use GroupBy or ToLookup when keys
///   are not guaranteed to be unique.
/// - ToHashSet is the idiomatic way to remove duplicates and enable O(1)
///   membership tests.
/// - Cast&lt;T&gt; throws InvalidCastException on a bad element; use OfType&lt;T&gt;
///   when the collection may contain elements of mixed types.
/// - AsEnumerable hides IQueryable-specific methods, forcing the rest of a
///   LINQ query to run in-memory (useful when switching from LINQ to EF Core
///   to in-memory evaluation mid-query).
/// </summary>
public static class ConversionExamples
{
    /// <summary>ToArray – materialises the sequence as an array.</summary>
    public static int[] ToArray(IEnumerable<int> numbers) =>
        numbers.ToArray();

    /// <summary>ToList – materialises the sequence as a List&lt;T&gt;.</summary>
    public static List<int> ToList(IEnumerable<int> numbers) =>
        numbers.ToList();

    /// <summary>ToDictionary – creates a dictionary keyed by a selector.</summary>
    public static Dictionary<int, string> ToDictionary(IEnumerable<string> words) =>
        words.ToDictionary(w => w.Length, w => w);

    /// <summary>ToHashSet – creates a HashSet removing duplicates.</summary>
    public static HashSet<int> ToHashSet(IEnumerable<int> numbers) =>
        numbers.ToHashSet();

    /// <summary>Cast – casts each element to the specified type.</summary>
    public static IEnumerable<int> CastToInt(IEnumerable<object> objects) =>
        objects.Cast<int>();

    /// <summary>AsEnumerable – returns the sequence typed as IEnumerable&lt;T&gt;.</summary>
    public static IEnumerable<T> AsEnumerable<T>(IEnumerable<T> source) =>
        source.AsEnumerable();
}

public class Program
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 2, 3, 3, 4, 5 };
        var words = new[] { "hi", "hey", "hello" };
        var objects = new object[] { 1, 2, 3 };

        Console.WriteLine($"ToArray:      [{string.Join(", ", ConversionExamples.ToArray(numbers))}]");
        Console.WriteLine($"ToList:       [{string.Join(", ", ConversionExamples.ToList(numbers))}]");
        Console.WriteLine($"ToDictionary: [{string.Join(", ", ConversionExamples.ToDictionary(words).Select(kv => $"{kv.Key}={kv.Value}"))}]");
        Console.WriteLine($"ToHashSet:    [{string.Join(", ", ConversionExamples.ToHashSet(numbers))}]");
        Console.WriteLine($"CastToInt:    [{string.Join(", ", ConversionExamples.CastToInt(objects))}]");
        Console.WriteLine($"AsEnumerable: [{string.Join(", ", ConversionExamples.AsEnumerable(numbers))}]");
    }
}
