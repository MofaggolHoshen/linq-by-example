namespace LinqByExample.Examples;

/// <summary>
/// Demonstrates LINQ join operators: Join, GroupJoin, and Zip.
///
/// Best Practices:
/// - Join performs an inner join – only matching keys from both sides appear.
/// - GroupJoin performs a left outer join when combined with SelectMany +
///   DefaultIfEmpty, which is the idiomatic LINQ pattern for outer joins.
/// - Zip pairs elements by position; if sequences differ in length, the
///   shorter one wins (extra elements are discarded).
/// - Avoid Cartesian products (nested SelectMany without filtering) on large
///   collections – they grow as O(n×m).
/// </summary>
public static class JoiningExamples
{
    public record Order(int OrderId, int CustomerId, string Product);
    public record Customer(int CustomerId, string Name);

    /// <summary>
    /// Join – inner join matching on a shared key.
    /// </summary>
    public static IEnumerable<(string CustomerName, string Product)> InnerJoin(
        IEnumerable<Customer> customers,
        IEnumerable<Order> orders) =>
        customers.Join(
            orders,
            customer => customer.CustomerId,
            order    => order.CustomerId,
            (customer, order) => (customer.Name, order.Product));

    /// <summary>
    /// GroupJoin – left outer join (customers without orders are included).
    /// </summary>
    public static IEnumerable<(string CustomerName, int OrderCount)> LeftOuterJoin(
        IEnumerable<Customer> customers,
        IEnumerable<Order> orders) =>
        customers.GroupJoin(
            orders,
            customer => customer.CustomerId,
            order    => order.CustomerId,
            (customer, customerOrders) => (customer.Name, customerOrders.Count()));

    /// <summary>
    /// Zip – combines two sequences element-by-element.
    /// </summary>
    public static IEnumerable<string> ZipNamesAndScores(
        IEnumerable<string> names,
        IEnumerable<int> scores) =>
        names.Zip(scores, (name, score) => $"{name}: {score}");
}
