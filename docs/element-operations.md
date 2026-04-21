# LINQ Element Operators

> Source code: [ElementOperationExamples.cs](../source/ElementOperationExamples.cs)

Element operators retrieve a single element from a sequence by position or predicate.

---

## Operators

### `First` / `FirstOrDefault`

Returns the first element, optionally matching a predicate.  
`First` throws `InvalidOperationException` if the sequence is empty; `FirstOrDefault` returns `default`.

```csharp
int[] numbers = [1, 2, 3, 4, 5];

int first     = numbers.First();              // 1
int firstEven = numbers.First(n => n % 2 == 0); // 2

int? none = Array.Empty<int>().FirstOrDefault(); // 0 (default)
```

---

### `Last` / `LastOrDefault`

Returns the last element, optionally matching a predicate.

```csharp
int last = numbers.Last();               // 5
int lastEven = numbers.Last(n => n % 2 == 0); // 4
```

---

### `Single` / `SingleOrDefault`

Returns the **only** element in the sequence (or matching the predicate).  
Throws if there is more than one match. `Single` also throws if the sequence is empty.

```csharp
int[] one = [42];
int value = one.Single(); // 42

// Throws if numbers has more than one even element
// numbers.Single(n => n % 2 == 0); ← InvalidOperationException
```

---

### `ElementAt` / `ElementAtOrDefault`

Returns the element at a zero-based index.  
`ElementAt` throws `ArgumentOutOfRangeException` if the index is out of range; `ElementAtOrDefault` returns `default`.

```csharp
int third    = numbers.ElementAt(2);             // 3
int? missing = numbers.ElementAtOrDefault(99);   // 0 (default)
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Prefer `*OrDefault` when the sequence may be empty | Avoids `InvalidOperationException` at runtime. |
| 2 | Use `Single` / `SingleOrDefault` to assert uniqueness | Makes the invariant explicit; throws early if it is violated. |
| 3 | Check the return value of `*OrDefault` before use | It returns `null` / `default`, which can cause a NullReferenceException if used blindly. |
| 4 | Avoid `ElementAt` on large `IEnumerable<T>` | It is O(n) for sequences that are not `IList<T>`; use direct indexing on arrays/lists instead. |
| 5 | Pass a fallback value to `*OrDefault` (.NET 6+) | `source.FirstOrDefault(n => n > 0, -1)` avoids a separate null/zero-check. |

---

## Quick Reference

```csharp
var nums   = new[] { 1, 2, 3, 4, 5 };
var single = new[] { 42 };
var empty  = Array.Empty<int>();

nums.First()                    // 1
nums.First(n => n % 2 == 0)    // 2
empty.FirstOrDefault()          // 0
nums.Last()                     // 5
single.Single()                 // 42
nums.ElementAt(2)               // 3
nums.ElementAtOrDefault(99)     // 0
```
