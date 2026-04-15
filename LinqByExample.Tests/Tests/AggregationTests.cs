using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class AggregationTests
{
    [Fact]
    public void CountAll_ReturnsElementCount()
    {
        Assert.Equal(5, AggregationExamples.CountAll([1, 2, 3, 4, 5]));
    }

    [Fact]
    public void CountEven_CountsOnlyEvenElements()
    {
        Assert.Equal(2, AggregationExamples.CountEven([1, 2, 3, 4, 5]));
    }

    [Fact]
    public void Sum_ReturnsTotalSum()
    {
        Assert.Equal(15, AggregationExamples.Sum([1, 2, 3, 4, 5]));
    }

    [Fact]
    public void Min_ReturnsSmallestElement()
    {
        Assert.Equal(1, AggregationExamples.Min([3, 1, 4, 1, 5]));
    }

    [Fact]
    public void Max_ReturnsLargestElement()
    {
        Assert.Equal(5, AggregationExamples.Max([3, 1, 4, 1, 5]));
    }

    [Fact]
    public void MinByLength_ReturnsShortestWord()
    {
        Assert.Equal("fig", AggregationExamples.MinByLength(["fig", "elderberry", "date"]));
    }

    [Fact]
    public void MaxByLength_ReturnsLongestWord()
    {
        Assert.Equal("elderberry", AggregationExamples.MaxByLength(["fig", "elderberry", "date"]));
    }

    [Fact]
    public void Average_ReturnsArithmeticMean()
    {
        Assert.Equal(3.0, AggregationExamples.Average([1, 2, 3, 4, 5]));
    }

    [Fact]
    public void AggregateToString_JoinsWithCommaSpace()
    {
        Assert.Equal("a, b, c", AggregationExamples.AggregateToString(["a", "b", "c"]));
    }

    [Fact]
    public void RunningProduct_MultipliesAllElements()
    {
        Assert.Equal(120, AggregationExamples.RunningProduct([1, 2, 3, 4, 5]));
    }
}
