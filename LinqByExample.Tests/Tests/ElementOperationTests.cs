using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class ElementOperationTests
{
    [Fact]
    public void First_ReturnsFirstElement()
    {
        Assert.Equal(10, ElementOperationExamples.First([10, 20, 30]));
    }

    [Fact]
    public void First_ThrowsOnEmptySequence()
    {
        Assert.Throws<InvalidOperationException>(() =>
            ElementOperationExamples.First(Array.Empty<int>()));
    }

    [Fact]
    public void FirstOrDefault_ReturnsDefaultOnEmpty()
    {
        Assert.Equal(0, ElementOperationExamples.FirstOrDefault(Array.Empty<int>()));
    }

    [Fact]
    public void FirstEven_ReturnsFirstEvenElement()
    {
        Assert.Equal(4, ElementOperationExamples.FirstEven([1, 3, 4, 6]));
    }

    [Fact]
    public void Last_ReturnsLastElement()
    {
        Assert.Equal(30, ElementOperationExamples.Last([10, 20, 30]));
    }

    [Fact]
    public void LastOrDefault_ReturnsDefaultOnEmpty()
    {
        Assert.Equal(0, ElementOperationExamples.LastOrDefault(Array.Empty<int>()));
    }

    [Fact]
    public void Single_ReturnsSingleElement()
    {
        Assert.Equal(42, ElementOperationExamples.Single([42]));
    }

    [Fact]
    public void Single_ThrowsOnMultipleElements()
    {
        Assert.Throws<InvalidOperationException>(() =>
            ElementOperationExamples.Single([1, 2]));
    }

    [Fact]
    public void SingleOrDefault_ReturnsDefaultOnEmpty()
    {
        Assert.Equal(0, ElementOperationExamples.SingleOrDefault(Array.Empty<int>()));
    }

    [Fact]
    public void ElementAt_ReturnsElementAtIndex()
    {
        Assert.Equal(20, ElementOperationExamples.ElementAt([10, 20, 30], 1));
    }

    [Fact]
    public void ElementAtOrDefault_ReturnsDefaultWhenOutOfRange()
    {
        Assert.Equal(0, ElementOperationExamples.ElementAtOrDefault([10, 20, 30], 99));
    }
}
