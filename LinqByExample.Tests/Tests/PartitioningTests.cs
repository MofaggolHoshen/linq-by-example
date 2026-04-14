using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class PartitioningTests
{
    private static readonly int[] Seq = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

    [Fact]
    public void TakeFirst_ReturnsFirstNElements()
    {
        Assert.Equal([1, 2, 3], PartitioningExamples.TakeFirst(Seq, 3).ToList());
    }

    [Fact]
    public void SkipFirst_BypassesFirstNElements()
    {
        Assert.Equal([8, 9, 10], PartitioningExamples.SkipFirst(Seq, 7).ToList());
    }

    [Fact]
    public void Page_ReturnsCorrectPage()
    {
        // Page 2 with page size 3 → elements at positions 4,5,6 → values 4,5,6
        Assert.Equal([4, 5, 6], PartitioningExamples.Page(Seq, 2, 3).ToList());
    }

    [Fact]
    public void TakeWhilePositive_StopsAtFirstNonPositive()
    {
        Assert.Equal([3, 2, 1], PartitioningExamples.TakeWhilePositive([3, 2, 1, -1, 2]).ToList());
    }

    [Fact]
    public void SkipWhileNegative_StartsAtFirstNonNegative()
    {
        Assert.Equal([0, 1, 2], PartitioningExamples.SkipWhileNegative([-3, -2, 0, 1, 2]).ToList());
    }

    [Fact]
    public void ChunkBy_SplitsIntoCorrectBatches()
    {
        var chunks = PartitioningExamples.ChunkBy([1, 2, 3, 4, 5], 2).ToList();
        Assert.Equal(3, chunks.Count);
        Assert.Equal([1, 2], chunks[0]);
        Assert.Equal([3, 4], chunks[1]);
        Assert.Equal([5],    chunks[2]);
    }
}
