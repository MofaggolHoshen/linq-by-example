# LINQ Set Operation Operators

> Source code: [SetOperationExamples.cs](../source/SetOperationExamples.cs)

Set operation operators treat sequences as mathematical sets and compute memberships, unions, intersections, and differences.

---

## Operators

### `Distinct` / `DistinctBy`

Removes duplicate elements.

```csharp
int[] numbers = [1, 2, 2, 3, 3, 4];

IEnumerable<int> unique = numbers.Distinct(); // [1, 2, 3, 4]
```

**`DistinctBy`** (.NET 6+) — keeps the first element for each distinct key:

```csharp
string[] words = ["apple", "art", "banana", "band", "cherry"];

IEnumerable<string> byLength = words.DistinctBy(w => w.Length);
// ["apple", "banana", "cherry"]  (one word per distinct length)
```

---

### `Union` / `UnionBy`

Returns all elements from both sequences with duplicates removed (set union).

```csharp
int[] a = [1, 2, 3];
int[] b = [3, 4, 5];

IEnumerable<int> union = a.Union(b); // [1, 2, 3, 4, 5]
```

---

### `Intersect` / `IntersectBy`

Returns only elements present in **both** sequences (set intersection).

```csharp
IEnumerable<int> common = a.Intersect(b); // [3]
```

---

### `Except` / `ExceptBy`

Returns elements in the **first** sequence that are **not** in the second (set difference).

```csharp
IEnumerable<int> diff = a.Except(b); // [1, 2]
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Pass a custom `IEqualityComparer` when default equality is not appropriate | Example: case-insensitive string set operations. |
| 2 | Use the `*By` variants (.NET 6+) to compare by a key without implementing a full comparer | Cleaner than creating a one-off `IEqualityComparer`. |
| 3 | Prefer set operators over nested loops for membership tests | Set operators use hash-based lookups (O(n+m)); nested loops are O(n×m). |
| 4 | Remember `Distinct` preserves the first occurrence and its order | It is not equivalent to sorting then deduplicating. |

---

## Quick Reference

```csharp
var a = new[] { 1, 2, 2, 3, 4 };
var b = new[] { 3, 4, 4, 5, 6 };

a.Distinct()          // [1, 2, 3, 4]
a.Union(b)            // [1, 2, 3, 4, 5, 6]
a.Intersect(b)        // [3, 4]
a.Except(b)           // [1, 2]

words.DistinctBy(w => w.Length)   // one word per distinct length (.NET 6+)
```
