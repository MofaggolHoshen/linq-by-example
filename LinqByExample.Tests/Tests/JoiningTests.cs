using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class JoiningTests
{
    private static readonly JoiningExamples.Customer[] Customers =
    [
        new(1, "Alice"),
        new(2, "Bob"),
        new(3, "Carol")
    ];

    private static readonly JoiningExamples.Order[] Orders =
    [
        new(101, 1, "Widget"),
        new(102, 1, "Gadget"),
        new(103, 2, "Doohickey")
    ];

    [Fact]
    public void InnerJoin_ReturnsOnlyMatchingPairs()
    {
        var result = JoiningExamples.InnerJoin(Customers, Orders).ToList();

        // Carol (id=3) has no orders, so only 3 rows expected
        Assert.Equal(3, result.Count);
        Assert.Contains(("Alice", "Widget"), result);
        Assert.Contains(("Alice", "Gadget"), result);
        Assert.Contains(("Bob", "Doohickey"), result);
    }

    [Fact]
    public void LeftOuterJoin_IncludesCustomersWithNoOrders()
    {
        var result = JoiningExamples.LeftOuterJoin(Customers, Orders)
            .ToDictionary(r => r.CustomerName, r => r.OrderCount);

        Assert.Equal(2, result["Alice"]);
        Assert.Equal(1, result["Bob"]);
        Assert.Equal(0, result["Carol"]);
    }

    [Fact]
    public void ZipNamesAndScores_PairsElementsByPosition()
    {
        var result = JoiningExamples.ZipNamesAndScores(
            ["Alice", "Bob"], [95, 87]).ToList();

        Assert.Equal(["Alice: 95", "Bob: 87"], result);
    }

    [Fact]
    public void ZipNamesAndScores_TruncatesToShorterSequence()
    {
        var result = JoiningExamples.ZipNamesAndScores(
            ["Alice", "Bob", "Carol"], [95]).ToList();

        Assert.Single(result);
    }
}
