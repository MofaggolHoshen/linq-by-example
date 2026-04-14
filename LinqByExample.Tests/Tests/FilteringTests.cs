using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class FilteringTests
{
    [Fact]
    public void WhereEvenNumbers_ReturnsOnlyEvenElements()
    {
        var result = FilteringExamples.WhereEvenNumbers([1, 2, 3, 4, 5, 6]).ToList();
        Assert.Equal([2, 4, 6], result);
    }

    [Fact]
    public void WhereEvenNumbers_EmptyInput_ReturnsEmpty()
    {
        var result = FilteringExamples.WhereEvenNumbers([]);
        Assert.Empty(result);
    }

    [Fact]
    public void WhereEvenIndex_ReturnsElementsAtEvenPositions()
    {
        var result = FilteringExamples.WhereEvenIndex(["a", "b", "c", "d", "e"]).ToList();
        Assert.Equal(["a", "c", "e"], result);
    }

    [Fact]
    public void OfTypeString_FiltersToStringsOnly()
    {
        object[] mixed = [1, "hello", 2.5, "world", 42];
        var result = FilteringExamples.OfTypeString(mixed).ToList();
        Assert.Equal(["hello", "world"], result);
    }
}
