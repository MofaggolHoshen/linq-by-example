namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ ordering operators: OrderBy, OrderByDescending,
/// ThenBy, ThenByDescending, and Reverse.
///
/// Best Practices:
/// - Chain ThenBy / ThenByDescending for multi-key sorting instead of calling
///   OrderBy multiple times (which resets the sort each time).
/// - Use StringComparer.OrdinalIgnoreCase when sorting strings for
///   culture-insensitive, deterministic ordering.
/// - Reverse works on any IEnumerable but makes a full copy; for large
///   collections consider OrderByDescending instead.
/// </summary>
public static class OrderingExamples
{
    /// <summary>
    /// OrderBy – ascending sort.
    /// </summary>
    public static IEnumerable<int> OrderAscending(IEnumerable<int> numbers) =>
        numbers.OrderBy(n => n);

    /// <summary>
    /// OrderByDescending – descending sort.
    /// </summary>
    public static IEnumerable<int> OrderDescending(IEnumerable<int> numbers) =>
        numbers.OrderByDescending(n => n);

    /// <summary>
    /// ThenBy – secondary ascending sort after a primary sort.
    /// </summary>
    public static IEnumerable<(string LastName, string FirstName)> OrderByLastThenFirst(
        IEnumerable<(string LastName, string FirstName)> people) =>
        people
            .OrderBy(p => p.LastName, StringComparer.OrdinalIgnoreCase)
            .ThenBy(p => p.FirstName, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// ThenByDescending – secondary descending sort.
    /// </summary>
    public static IEnumerable<(string Department, int Salary)> OrderByDeptThenSalaryDesc(
        IEnumerable<(string Department, int Salary)> employees) =>
        employees
            .OrderBy(e => e.Department, StringComparer.OrdinalIgnoreCase)
            .ThenByDescending(e => e.Salary);

    /// <summary>
    /// Reverse – reverses the current order of the sequence.
    /// </summary>
    public static IEnumerable<T> ReverseSequence<T>(IEnumerable<T> source) =>
        source.Reverse();
}
