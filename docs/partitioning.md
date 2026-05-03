# LINQ Partitioning Operators

> Source code: [PartitioningExamples.cs](../source/PartitioningExamples.cs)

Partitioning operators divide a sequence into two parts and return one of them.

---

## Operators

### `Take`

Returns the first N elements.

```csharp
int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];

IEnumerable<int> first3 = numbers.Take(3); // [1, 2, 3]
```

---

### `TakeWhile`

Returns elements as long as the predicate holds. Stops at the first element that fails.

```csharp
int[] mixed = [2, 4, 6, 1, 3, 5];

IEnumerable<int> result = mixed.TakeWhile(n => n % 2 == 0); // [2, 4, 6]
// Stops at 1 — does NOT skip and continue
```

---

### `Skip`

Bypasses the first N elements and returns the rest.

```csharp
IEnumerable<int> rest = numbers.Skip(3); // [4, 5, 6, 7, 8, 9, 10]
```

---

### `SkipWhile`

Bypasses elements as long as the predicate holds, then returns all remaining elements (including the first one that failed).

```csharp
int[] withNegs = [-3, -1, 0, 2, 4];

IEnumerable<int> result = withNegs.SkipWhile(n => n < 0); // [0, 2, 4]
```

---

### `Page` (Skip + Take)

The canonical pagination pattern: skip the elements before the page, then take a page's worth.

```csharp
// Page 2, page size 3 → items 4–6
IEnumerable<int> page2 = numbers.Skip((2 - 1) * 3).Take(3); // [4, 5, 6]
```

---

### `Chunk` (.NET 6+)

Splits the sequence into fixed-size `T[]` chunks. The last chunk may be smaller.

```csharp
foreach (var chunk in numbers.Chunk(3))
    Console.WriteLine(string.Join(", ", chunk));
// 1, 2, 3
// 4, 5, 6
// 7, 8, 9
// 10
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Use `Skip((page-1)*size).Take(size)` for pagination | Standard, readable pattern that avoids off-by-one errors. |
| 2 | Prefer `Chunk` over manual batching loops (.NET 6+) | Cleaner code with no off-by-one risks on the final batch. |
| 3 | Remember `TakeWhile` / `SkipWhile` act on a contiguous prefix | They stop/start at the first failing element and do not skip-and-resume. |
| 4 | Apply `Where` before `Take` when filtering and paging | Filtering first reduces the set before paging, giving more predictable page sizes. |

---

## Quick Reference

```csharp
numbers.Take(3)                           // [1, 2, 3]
numbers.TakeWhile(n => n % 2 == 0)       // stops at first odd
numbers.Skip(3)                           // [4 … 10]
numbers.SkipWhile(n => n < 0)            // skip negatives then return rest
numbers.Skip((page - 1) * size).Take(size) // page N
numbers.Chunk(3)                          // [[1,2,3],[4,5,6],[7,8,9],[10]]
```
