using LinqByExample.Examples;

namespace LinqByExample.Tests.Tests;

public class GroupingTests
{
    [Fact]
    public void GroupByFirstLetter_GroupsCorrectly()
    {
        var groups = GroupingExamples.GroupByFirstLetter(["apple", "avocado", "banana"])
            .ToDictionary(g => g.Key, g => g.ToList());

        Assert.Equal(["apple", "avocado"], groups["A"]);
        Assert.Equal(["banana"], groups["B"]);
    }

    [Fact]
    public void SumSalaryByDepartment_SumsCorrectly()
    {
        var employees = new[]
        {
            ("Engineering", 90_000), ("Marketing", 70_000),
            ("Engineering", 85_000), ("Marketing", 75_000)
        };
        var result = GroupingExamples.SumSalaryByDepartment(employees)
            .ToDictionary(r => r.Department, r => r.TotalSalary);

        Assert.Equal(175_000, result["Engineering"]);
        Assert.Equal(145_000, result["Marketing"]);
    }

    [Fact]
    public void ToLookupByFirstLetter_AllowsMultiKeyLookup()
    {
        var lookup = GroupingExamples.ToLookupByFirstLetter(["apple", "avocado", "banana"]);
        Assert.Equal(["apple", "avocado"], lookup["A"].ToList());
        Assert.Equal(["banana"], lookup["B"].ToList());
    }
}
