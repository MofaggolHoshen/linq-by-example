using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class ConversionTests
{
    [Fact]
    public void ToArray_ReturnsArrayType()
    {
        var result = ConversionExamples.ToArray([1, 2, 3]);
        Assert.IsType<int[]>(result);
        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void ToList_ReturnsListType()
    {
        var result = ConversionExamples.ToList([1, 2, 3]);
        Assert.IsType<List<int>>(result);
        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void ToDictionary_ThrowsOnDuplicateKeys()
    {
        // Two words of the same length → duplicate key
        Assert.Throws<ArgumentException>(() =>
            ConversionExamples.ToDictionary(["cat", "dog"]));
    }

    [Fact]
    public void ToDictionary_CreatesCorrectMapping()
    {
        var dict = ConversionExamples.ToDictionary(["hi", "hello"]);
        Assert.Equal("hi", dict[2]);
        Assert.Equal("hello", dict[5]);
    }

    [Fact]
    public void ToHashSet_RemovesDuplicates()
    {
        var result = ConversionExamples.ToHashSet([1, 1, 2, 3, 3]);
        Assert.Equal(3, result.Count);
        Assert.Contains(1, result);
        Assert.Contains(2, result);
        Assert.Contains(3, result);
    }

    [Fact]
    public void CastToInt_ConvertsObjectsToInts()
    {
        var result = ConversionExamples.CastToInt(new object[] { 1, 2, 3 }).ToList();
        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void AsEnumerable_ReturnsIEnumerableTyped()
    {
        IEnumerable<int> result = ConversionExamples.AsEnumerable([1, 2, 3]);
        Assert.Equal([1, 2, 3], result.ToList());
    }
}
