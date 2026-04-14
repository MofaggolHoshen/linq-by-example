# linq-by-example

A practical, well-commented .NET 8 reference project that exercises every major LINQ operator with explanations of best practices.

## Goal

Work through **all** standard LINQ operators grouped by category, with:

- concise, runnable code examples
- inline best-practice guidance as XML-doc / summary comments
- an xUnit test suite that validates every example

## Project Structure

```
linq-by-example.sln
├── LinqByExample/                    # Console app – runnable demo
│   ├── Program.cs                    # Wires every category together
│   └── Examples/
│       ├── FilteringExamples.cs      # Where, OfType
│       ├── ProjectionExamples.cs     # Select, SelectMany
│       ├── OrderingExamples.cs       # OrderBy, ThenBy, Reverse, …
│       ├── GroupingExamples.cs       # GroupBy, ToLookup
│       ├── JoiningExamples.cs        # Join, GroupJoin, Zip
│       ├── AggregationExamples.cs    # Count, Sum, Min, Max, Average, Aggregate
│       ├── SetOperationExamples.cs   # Distinct, Union, Intersect, Except
│       ├── QuantifierExamples.cs     # Any, All, Contains
│       ├── PartitioningExamples.cs   # Take, Skip, TakeWhile, SkipWhile, Chunk
│       ├── ElementOperationExamples.cs # First, Last, Single, ElementAt, …
│       ├── GenerationExamples.cs     # Range, Repeat, Empty
│       └── ConversionExamples.cs     # ToArray, ToList, ToDictionary, Cast, …
└── LinqByExample.Tests/              # xUnit test project (71 tests)
    └── Tests/
        ├── FilteringTests.cs
        ├── ProjectionTests.cs
        ├── OrderingTests.cs
        ├── GroupingTests.cs
        ├── JoiningTests.cs
        ├── AggregationTests.cs
        ├── SetOperationTests.cs
        ├── QuantifierTests.cs
        ├── PartitioningTests.cs
        ├── ElementOperationTests.cs
        ├── GenerationTests.cs
        └── ConversionTests.cs
```

## LINQ Categories Covered

| # | Category | Operators |
|---|---|---|
| 1 | **Filtering** | `Where`, `OfType` |
| 2 | **Projection** | `Select`, `SelectMany` |
| 3 | **Ordering** | `OrderBy`, `OrderByDescending`, `ThenBy`, `ThenByDescending`, `Reverse` |
| 4 | **Grouping** | `GroupBy`, `ToLookup` |
| 5 | **Joining** | `Join`, `GroupJoin`, `Zip` |
| 6 | **Aggregation** | `Count`, `Sum`, `Min`, `Max`, `MinBy`, `MaxBy`, `Average`, `Aggregate` |
| 7 | **Set Operations** | `Distinct`, `DistinctBy`, `Union`, `Intersect`, `Except` |
| 8 | **Quantifiers** | `Any`, `All`, `Contains` |
| 9 | **Partitioning** | `Take`, `TakeWhile`, `Skip`, `SkipWhile`, `Chunk` |
| 10 | **Element Operations** | `First`, `FirstOrDefault`, `Last`, `LastOrDefault`, `Single`, `SingleOrDefault`, `ElementAt`, `ElementAtOrDefault` |
| 11 | **Generation** | `Enumerable.Range`, `Enumerable.Repeat`, `Enumerable.Empty` |
| 12 | **Conversion** | `ToArray`, `ToList`, `ToDictionary`, `ToHashSet`, `Cast`, `AsEnumerable` |

## Quick Start

```bash
# Run the interactive demo
dotnet run --project LinqByExample

# Run all tests
dotnet test

# Build in release mode
dotnet build --configuration Release
```

## Key Best Practices

- **Deferred vs. eager execution** – LINQ operators are lazy by default; call `ToList()` / `ToArray()` to materialise results and avoid multiple enumerations.
- **Short-circuit operators** – `Any()` and `First()` stop as soon as they find a match; prefer them over `Count() > 0` or `Where().First()`.
- **`*OrDefault` variants** – use `FirstOrDefault`, `SingleOrDefault`, etc. when a sequence may be empty to avoid `InvalidOperationException`.
- **`ToLookup` vs `GroupBy`** – `ToLookup` is eagerly evaluated and cached; use it when you need to query the same groups multiple times.
- **Set operators are O(n+m)** – they use hash-based lookups internally; they are far more efficient than nested-loop membership tests.
- **Culture-safe string sorting** – pass `StringComparer.OrdinalIgnoreCase` to `OrderBy` / `ThenBy` for deterministic, culture-independent ordering.
- **`OfType<T>` over `Cast<T>`** – use `OfType` when a collection may contain mixed types; `Cast` throws on a bad element.
