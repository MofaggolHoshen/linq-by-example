/// <summary>
/// Demonstrates LINQ grouping operators: GroupBy and ToLookup.
///
/// Best Practices:
/// - GroupBy uses deferred execution; ToLookup is eagerly evaluated and cached –
///   prefer ToLookup when you need to query the same groups multiple times.
/// - Always provide a key selector; add an element selector when you only need
///   a subset of each element's properties in the group.
/// - IGrouping&lt;TKey, TElement&gt; implements IEnumerable&lt;TElement&gt;, so you can
///   further query groups with LINQ operators.
/// How to run:
/// - dotnet run .\source\GroupingExamples.cs
/// </summary>
public static class GroupingExamples
{
    /// <summary>
    /// GroupBy – groups elements by a key.
    /// </summary>
    public static IEnumerable<IGrouping<string, string>> GroupByFirstLetter(
        IEnumerable<string> words) =>
        words.GroupBy(word => word[..1].ToUpperInvariant());

    /// <summary>
    /// GroupBy with element selector – projects each element within the group.
    /// </summary>
    public static IEnumerable<IGrouping<string, int>> GroupByDepartmentSalary(
        IEnumerable<(string Department, int Salary)> employees) =>
        employees.GroupBy(e => e.Department, e => e.Salary);

    /// <summary>
    /// GroupBy with result selector – transforms each group into a summary.
    /// </summary>
    public static IEnumerable<(string Department, int TotalSalary)> SumSalaryByDepartment(
        IEnumerable<(string Department, int Salary)> employees) =>
        employees.GroupBy(
            e => e.Department,
            e => e.Salary,
            (department, salaries) => (department, salaries.Sum()));

    /// <summary>
    /// ToLookup – like GroupBy but eagerly evaluated; supports multi-key lookup.
    /// </summary>
    public static ILookup<string, string> ToLookupByFirstLetter(
        IEnumerable<string> words) =>
        words.ToLookup(word => word[..1].ToUpperInvariant());
}

public class Program
{
    public static void Main()
    {
        var words = new[] { "apple", "avocado", "banana", "blueberry", "cherry" };
        var employees = new (string Department, int Salary)[]
        {
            ("Engineering", 90000),
            ("Engineering", 80000),
            ("Marketing",   70000),
        };

        Console.WriteLine("GroupByFirstLetter:");
        foreach (var group in GroupingExamples.GroupByFirstLetter(words))
            Console.WriteLine($"  {group.Key}: [{string.Join(", ", group)}]");

        Console.WriteLine("GroupByDepartmentSalary:");
        foreach (var group in GroupingExamples.GroupByDepartmentSalary(employees))
            Console.WriteLine($"  {group.Key}: [{string.Join(", ", group)}]");

        Console.WriteLine("SumSalaryByDepartment:");
        foreach (var (dept, total) in GroupingExamples.SumSalaryByDepartment(employees))
            Console.WriteLine($"  {dept}: {total}");

        var lookup = GroupingExamples.ToLookupByFirstLetter(words);
        Console.WriteLine($"ToLookup[\"A\"]: [{string.Join(", ", lookup["A"])}]");
    }
}
