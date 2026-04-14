using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class OrderingTests
{
    [Fact]
    public void OrderAscending_SortsLowToHigh()
    {
        var result = OrderingExamples.OrderAscending([3, 1, 4, 1, 5]).ToList();
        Assert.Equal([1, 1, 3, 4, 5], result);
    }

    [Fact]
    public void OrderDescending_SortsHighToLow()
    {
        var result = OrderingExamples.OrderDescending([3, 1, 4, 1, 5]).ToList();
        Assert.Equal([5, 4, 3, 1, 1], result);
    }

    [Fact]
    public void OrderByLastThenFirst_SortsByLastNameThenFirstName()
    {
        var people = new[] { ("Smith", "John"), ("Adams", "Sam"), ("Smith", "Anna") };
        var result = OrderingExamples.OrderByLastThenFirst(people).ToList();
        Assert.Equal([("Adams", "Sam"), ("Smith", "Anna"), ("Smith", "John")], result);
    }

    [Fact]
    public void ReverseSequence_ReturnsElementsInReverseOrder()
    {
        var result = OrderingExamples.ReverseSequence([1, 2, 3]).ToList();
        Assert.Equal([3, 2, 1], result);
    }
}
