# LINQ Grouping Operators

> Source code: [GroupingExamples.cs](../source/GroupingExamples.cs)

Grouping operators organise sequence elements into groups that share a common key.

---

## Operators

### `GroupBy`

Groups elements by a key selector. The result is a sequence of `IGrouping<TKey, TElement>`, where each group exposes its `Key` and implements `IEnumerable<TElement>`.

**Basic grouping:**

```csharp
string[] words = ["apple", "avocado", "banana", "blueberry", "cherry"];

var groups = words.GroupBy(w => w[..1].ToUpperInvariant());
// A → ["apple", "avocado"]
// B → ["banana", "blueberry"]
// C → ["cherry"]

foreach (var g in groups)
    Console.WriteLine($"{g.Key}: {string.Join(", ", g)}");
```

**With element selector** — project each element inside the group:

```csharp
var employees = new[]
{
    ("Engineering", 90000),
    ("Engineering", 80000),
    ("Marketing",   70000),
};

var salariesByDept = employees.GroupBy(e => e.Item1, e => e.Item2);
// Engineering → [90000, 80000]
// Marketing   → [70000]
```

**With result selector** — transform each group into a summary value immediately:

```csharp
var totals = employees.GroupBy(
    e => e.Item1,
    e => e.Item2,
    (dept, salaries) => (dept, salaries.Sum()));
// ("Engineering", 170000), ("Marketing", 70000)
```

---

### `ToLookup`

Works like `GroupBy` but is **eagerly evaluated** and cached as an `ILookup<TKey, TElement>`. Accessing a missing key returns an empty sequence (no exception).

```csharp
ILookup<string, string> lookup = words.ToLookup(w => w[..1].ToUpperInvariant());

var aWords = lookup["A"]; // ["apple", "avocado"]
var zWords = lookup["Z"]; // empty — no exception
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Use `ToLookup` when querying the same groups multiple times | `GroupBy` is deferred and re-enumerates the source each time; `ToLookup` caches the result. |
| 2 | Use the result selector overload to collapse groups immediately | Avoids iterating over groups again in a follow-up `Select`. |
| 3 | Remember `IGrouping<TKey, T>` is `IEnumerable<T>` | You can chain further LINQ operators (e.g., `.OrderBy`, `.Take`) directly on a group. |
| 4 | Accessing a missing key on `ILookup` is safe | Returns an empty sequence, unlike `Dictionary` which throws. |

---

## Quick Reference

```csharp
words.GroupBy(w => w[..1])
// deferred — IEnumerable<IGrouping<string, string>>

words.ToLookup(w => w[..1])
// eager — ILookup<string, string>, safe missing-key access

employees.GroupBy(e => e.Dept, e => e.Salary, (dept, salaries) => (dept, salaries.Sum()))
// projects each group into a summary tuple
```
