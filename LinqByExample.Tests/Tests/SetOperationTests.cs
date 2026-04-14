using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class SetOperationTests
{
    [Fact]
    public void Distinct_RemovesDuplicates()
    {
        var result = SetOperationExamples.Distinct([1, 1, 2, 2, 3]).ToList();
        Assert.Equal([1, 2, 3], result);
    }

    [Fact]
    public void DistinctByLength_KeepsFirstWordPerLength()
    {
        var result = SetOperationExamples.DistinctByLength(["cat", "dog", "elephant", "ox"]).ToList();
        // "cat"(3), "elephant"(8), "ox"(2) – "dog"(3) is dropped
        Assert.Equal(3, result.Count);
        Assert.Contains("cat", result);
        Assert.Contains("elephant", result);
        Assert.Contains("ox", result);
    }

    [Fact]
    public void Union_CombinesDistinctElements()
    {
        var result = SetOperationExamples.Union([1, 2, 3], [3, 4, 5]).ToList();
        Assert.Equal([1, 2, 3, 4, 5], result);
    }

    [Fact]
    public void Intersect_ReturnsCommonElements()
    {
        var result = SetOperationExamples.Intersect([1, 2, 3, 4], [3, 4, 5]).ToList();
        Assert.Equal([3, 4], result);
    }

    [Fact]
    public void Except_ReturnsFirstNotInSecond()
    {
        var result = SetOperationExamples.Except([1, 2, 3, 4, 5], [3, 4, 5]).ToList();
        Assert.Equal([1, 2], result);
    }
}
