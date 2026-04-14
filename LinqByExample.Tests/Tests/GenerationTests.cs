using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class GenerationTests
{
    [Fact]
    public void Range_ProducesConsecutiveIntegers()
    {
        Assert.Equal([1, 2, 3, 4, 5], GenerationExamples.Range(1, 5).ToList());
    }

    [Fact]
    public void Squares_ProducesSquaresOfNaturalNumbers()
    {
        Assert.Equal([1, 4, 9, 16, 25], GenerationExamples.Squares(5).ToList());
    }

    [Fact]
    public void Repeat_ProducesRepeatedElements()
    {
        Assert.Equal(["x", "x", "x"], GenerationExamples.Repeat("x", 3).ToList());
    }

    [Fact]
    public void Empty_ProducesEmptySequence()
    {
        Assert.Empty(GenerationExamples.Empty<int>());
    }
}
