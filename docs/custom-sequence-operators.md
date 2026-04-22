# LINQ Custom Sequence Operators

> Source code: [CustomSequenceOperatorExamples.cs](../source/CustomSequenceOperatorExamples.cs)

When no built-in LINQ operator fits your need, you can create your own by writing **extension methods** on `IEnumerable<T>` combined with **iterator methods** (`yield return`) for lazy evaluation.

---

## Pattern: Extension Method + `yield return`

A custom LINQ-style operator follows this structure:

```csharp
public static IEnumerable<TResult> MyOperator<T, TResult>(
    this IEnumerable<T> source,
    /* additional parameters */)
{
    foreach (var item in source)
    {
        // transform or filter item
        yield return /* result */;
    }
}
```

Using `yield return` ensures the operator is **lazily evaluated** — elements are produced one at a time as the caller iterates, matching the deferred execution behaviour of built-in LINQ operators.

---

## Examples

### `Interleave`

Yields elements from two sequences alternately. If one sequence is longer, remaining elements are appended at the end.

```csharp
int[] a = { 1, 2, 3, 4 };
int[] b = { 10, 20, 30, 40 };

a.Interleave(b); // 1, 10, 2, 20, 3, 30, 4, 40
```

---

### `Batch`

Splits a sequence into arrays of a fixed size. The last batch may be smaller if the source length is not evenly divisible.

```csharp
int[] numbers = { 1, 2, 3, 4, 5 };

numbers.Batch(2);
// [1, 2]
// [3, 4]
// [5]      ← partial last batch
```

> **Note:** .NET 6 introduced `Enumerable.Chunk(size)` which is equivalent. Prefer `Chunk` in .NET 6+ projects.

---

### `DotProduct`

Combines two numeric sequences pairwise by multiplying corresponding elements, then sums the products. Uses the built-in `Zip` internally.

```csharp
int[] a = { 1, 2, 3 };
int[] b = { 4, 5, 6 };

DotProduct(a, b); // (1×4) + (2×5) + (3×6) = 32
```

---

## Eager Argument Validation

Iterators cannot validate arguments before the first `MoveNext()` call. Split the method into a public wrapper and a private iterator to validate eagerly:

```csharp
// Public wrapper – validates immediately when called.
public static IEnumerable<T[]> Batch<T>(IEnumerable<T> source, int size)
{
    if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
    return BatchIterator(source, size); // lazy
}

private static IEnumerable<T[]> BatchIterator<T>(IEnumerable<T> source, int size)
{
    // yield return logic here
}
```

---

## Best Practices

- **Check for built-ins first** – `Zip`, `SelectMany`, `Chunk` (≥ .NET 6), `Aggregate` cover many custom operator needs.
- **Keep operators lazy** with `yield return`; only materialise (`ToList`, arrays) inside the operator when the algorithm genuinely requires it (e.g., sorting).
- **Validate arguments eagerly** using the wrapper + iterator pattern to give callers an immediate `ArgumentException` rather than a deferred one.
- **Make operators composable** by accepting and returning `IEnumerable<T>` so they chain naturally with other LINQ operators.

---

## See Also

- [Projection](projection.md) – `Select`, `SelectMany`
- [Query Execution](query-execution.md) – deferred vs immediate execution
- [Partitioning](partitioning.md) – `Chunk` (.NET 6+)
