using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class QuantifierTests
{
    [Fact]
    public void HasEvenNumber_ReturnsTrueWhenEvenPresent()
    {
        Assert.True(QuantifierExamples.HasEvenNumber([1, 3, 4]));
    }

    [Fact]
    public void HasEvenNumber_ReturnsFalseWhenNoEven()
    {
        Assert.False(QuantifierExamples.HasEvenNumber([1, 3, 5]));
    }

    [Fact]
    public void IsNonEmpty_ReturnsTrueForNonEmptySequence()
    {
        Assert.True(QuantifierExamples.IsNonEmpty([1]));
    }

    [Fact]
    public void IsNonEmpty_ReturnsFalseForEmptySequence()
    {
        Assert.False(QuantifierExamples.IsNonEmpty(Array.Empty<int>()));
    }

    [Fact]
    public void AllPositive_ReturnsTrueWhenAllPositive()
    {
        Assert.True(QuantifierExamples.AllPositive([1, 2, 3]));
    }

    [Fact]
    public void AllPositive_ReturnsFalseWhenAnyNonPositive()
    {
        Assert.False(QuantifierExamples.AllPositive([1, -2, 3]));
    }

    [Fact]
    public void ContainsValue_ReturnsTrueWhenPresent()
    {
        Assert.True(QuantifierExamples.ContainsValue([1, 2, 3], 3));
    }

    [Fact]
    public void ContainsValue_ReturnsFalseWhenAbsent()
    {
        Assert.False(QuantifierExamples.ContainsValue([1, 2, 3], 99));
    }

    [Fact]
    public void ContainsIgnoreCase_ReturnsTrueCaseInsensitively()
    {
        Assert.True(QuantifierExamples.ContainsIgnoreCase(["hello", "world"], "Hello"));
    }
}
