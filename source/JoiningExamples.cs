/// <summary>
/// Demonstrates LINQ join operators: Join, GroupJoin, LeftJoin, RightJoin, and Zip.
///
/// Best Practices:
/// - Join performs an inner join – only matching keys from both sides appear.
/// - LeftJoin: GroupJoin + SelectMany + DefaultIfEmpty includes every left-side
///   element, pairing it with null when there is no matching right-side element.
/// - RightJoin: swap the sequences and apply the left-join pattern – every
///   right-side element appears, with null when there is no matching left element.
/// - Zip pairs elements by position; if sequences differ in length, the
///   shorter one wins (extra elements are discarded).
/// - Avoid Cartesian products (nested SelectMany without filtering) on large
///   collections – they grow as O(n×m).
/// How to run:
/// - dotnet run .\source\JoiningExamples.cs
/// </summary>
public static class JoiningExamples
{
    public record Order(int OrderId, int CustomerId, string Product);
    public record Customer(int CustomerId, string Name);

    /// <summary>
    /// Join – inner join matching on a shared key.
    /// Only customers that have at least one order appear in the result.
    /// </summary>
    public static IEnumerable<(string CustomerName, string Product)> InnerJoin(
        IEnumerable<Customer> customers,
        IEnumerable<Order> orders) =>
        customers.Join(
            orders,
            customer => customer.CustomerId,
            order => order.CustomerId,
            (customer, order) => (customer.Name, order.Product));

    /// <summary>
    /// Left join – every customer appears in the result; customers without
    /// orders are paired with "(no orders)" using DefaultIfEmpty.
    /// Pattern: GroupJoin + SelectMany + DefaultIfEmpty.
    /// </summary>
    public static IEnumerable<(string CustomerName, string Product)> LeftJoin(
        IEnumerable<Customer> customers,
        IEnumerable<Order> orders) =>
        customers
            .GroupJoin(
                orders,
                customer => customer.CustomerId,
                order => order.CustomerId,
                (customer, customerOrders) => (customer, customerOrders))
            .SelectMany(
                x => x.customerOrders.DefaultIfEmpty(),
                (x, order) => (x.customer.Name, order?.Product ?? "(no orders)"));

    /// <summary>
    /// Right join – every order appears in the result; orders whose CustomerId
    /// does not match any customer are paired with "(unknown customer)".
    /// Pattern: swap the sequences and apply the left-join pattern.
    /// </summary>
    public static IEnumerable<(string CustomerName, string Product)> RightJoin(
        IEnumerable<Customer> customers,
        IEnumerable<Order> orders) =>
        orders
            .GroupJoin(
                customers,
                order => order.CustomerId,
                customer => customer.CustomerId,
                (order, matchedCustomers) => (order, matchedCustomers))
            .SelectMany(
                x => x.matchedCustomers.DefaultIfEmpty(),
                (x, customer) => (customer?.Name ?? "(unknown customer)", x.order.Product));

    /// <summary>
    /// Zip – combines two sequences element-by-element.
    /// </summary>
    public static IEnumerable<string> ZipNamesAndScores(
        IEnumerable<string> names,
        IEnumerable<int> scores) =>
        names.Zip(scores, (name, score) => $"{name}: {score}");
}

public class Program
{
    public static void Main()
    {
        var customers = new JoiningExamples.Customer[]
        {
            new(1, "Alice"),
            new(2, "Bob"),
            new(3, "Carol"),   // Carol has no orders
        };
        var orders = new JoiningExamples.Order[]
        {
            new(101, 1, "Widget"),
            new(102, 1, "Gadget"),
            new(103, 2, "Doohickey"),
            new(104, 9, "Mystery"),  // CustomerId 9 does not exist
        };
        var names = new[] { "Alice", "Bob", "Carol" };
        var scores = new[] { 95, 87, 92 };

        Console.WriteLine("Inner Join (only matched rows):");
        foreach (var (name, product) in JoiningExamples.InnerJoin(customers, orders))
            Console.WriteLine($"  {name} -> {product}");

        Console.WriteLine("\nLeft Join (all customers, null order if none):");
        foreach (var (name, product) in JoiningExamples.LeftJoin(customers, orders))
            Console.WriteLine($"  {name} -> {product}");

        Console.WriteLine("\nRight Join (all orders, null customer if unknown):");
        foreach (var (name, product) in JoiningExamples.RightJoin(customers, orders))
            Console.WriteLine($"  {name} -> {product}");

        Console.WriteLine("\nZip:");
        foreach (var entry in JoiningExamples.ZipNamesAndScores(names, scores))
            Console.WriteLine($"  {entry}");
    }
}
