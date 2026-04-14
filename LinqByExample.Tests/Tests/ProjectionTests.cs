using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class ProjectionTests
{
    [Fact]
    public void SelectNames_ReturnsUppercaseNames()
    {
        var result = ProjectionExamples.SelectNames(["alice", "bob"]).ToList();
        Assert.Equal(["ALICE", "BOB"], result);
    }

    [Fact]
    public void SelectWithIndex_PrefixesOneBased()
    {
        var result = ProjectionExamples.SelectWithIndex(["x", "y"]).ToList();
        Assert.Equal(["1. x", "2. y"], result);
    }

    [Fact]
    public void SelectManyNumbers_FlattensNestedCollections()
    {
        int[][] groups = [[1, 2], [3, 4], [5]];
        var result = ProjectionExamples.SelectManyNumbers(groups).ToList();
        Assert.Equal([1, 2, 3, 4, 5], result);
    }

    [Fact]
    public void SelectManyWithResult_ProducesQualifiedItems()
    {
        var catalog = new[]
        {
            ("Fruit",  (IEnumerable<string>)new[] { "Apple" }),
            ("Veggie", (IEnumerable<string>)new[] { "Carrot" })
        };
        var result = ProjectionExamples.SelectManyWithResult(catalog).ToList();
        Assert.Equal(["Fruit: Apple", "Veggie: Carrot"], result);
    }
}
