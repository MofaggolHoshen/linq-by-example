# LINQ Projection Operators

> Source code: [ProjectionExamples.cs](../source/ProjectionExamples.cs)

Projection operators transform each element of a sequence into a new form.

---

## Operators

### `Select`

Transforms each element using a selector function.

```csharp
string[] names = ["alice", "bob", "carol"];

IEnumerable<string> upper = names.Select(n => n.ToUpperInvariant());
// ["ALICE", "BOB", "CAROL"]
```

**With index overload** — the selector also receives the zero-based element position:

```csharp
IEnumerable<string> numbered = names.Select((name, i) => $"{i + 1}. {name}");
// ["1. alice", "2. bob", "3. carol"]
```

---

### `SelectMany`

Flattens a collection of collections into a single sequence.

```csharp
int[][] groups = [[1, 2], [3, 4], [5]];

IEnumerable<int> flat = groups.SelectMany(g => g); // [1, 2, 3, 4, 5]
```

**With result selector** — pairs each parent element with each of its children:

```csharp
var catalog = new[]
{
    ("Fruit",  new[] { "apple", "banana" }),
    ("Veggie", new[] { "carrot" }),
};

var result = catalog.SelectMany(
    entry => entry.Item2,
    (entry, item) => $"{entry.Item1}: {item}");
// ["Fruit: apple", "Fruit: banana", "Veggie: carrot"]
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Use `Select` for one-to-one transformations | Keeps each pipeline step single-responsibility and readable. |
| 2 | Use `SelectMany` to flatten nested collections | Avoids manual double `foreach` loops. |
| 3 | Prefer anonymous types or records for intermediate projections | Avoids creating a full class just to hold query results. |
| 4 | Avoid side effects inside `Select` | `Select` is meant to be a pure projection; side effects make the pipeline hard to reason about. |

---

## Quick Reference

```csharp
names.Select(n => n.ToUpperInvariant())               // transform each element
names.Select((n, i) => $"{i + 1}. {n}")              // with position
groups.SelectMany(g => g)                              // flatten nested → single sequence
catalog.SelectMany(e => e.Items, (e, item) => ...)    // flatten + pair with parent
```
