# LINQ Generation Operators

> Source code: [GenerationExamples.cs](../source/GenerationExamples.cs)

Generation operators create new sequences without requiring an existing input collection.

---

## Operators

### `Enumerable.Range`

Generates a contiguous sequence of integers starting at `start` for `count` elements.

```csharp
IEnumerable<int> nums = Enumerable.Range(1, 5); // [1, 2, 3, 4, 5]

// Combine with Select for any arithmetic series
IEnumerable<int> squares = Enumerable.Range(1, 5).Select(n => n * n);
// [1, 4, 9, 16, 25]
```

---

### `Enumerable.Repeat`

Generates a sequence that repeats a single element a given number of times.

```csharp
IEnumerable<string> hellos = Enumerable.Repeat("hi", 3); // ["hi", "hi", "hi"]

// Useful for initialising test data
IEnumerable<int> zeros = Enumerable.Repeat(0, 5); // [0, 0, 0, 0, 0]
```

---

### `Enumerable.Empty<T>`

Returns a cached, allocation-free empty sequence of type `T`.

```csharp
IEnumerable<int> nothing = Enumerable.Empty<int>(); // []

// Cleaner than: new int[0], new List<int>(), or Enumerable.Range(0, 0)
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Combine `Range` with `Select` instead of allocating an array | Generates the series lazily with no up-front allocation. |
| 2 | Use `Empty<T>()` over `new T[0]` or `new List<T>()` | Returns a shared cached instance — no allocation at all. |
| 3 | Be careful with large `Repeat` counts | For very large `n`, a lazy `Select` on `Range` uses less memory than materialising the repeated elements. |

---

## Quick Reference

```csharp
Enumerable.Range(1, 5)                        // [1, 2, 3, 4, 5]
Enumerable.Range(1, 5).Select(n => n * n)     // [1, 4, 9, 16, 25]
Enumerable.Repeat("hi", 3)                    // ["hi", "hi", "hi"]
Enumerable.Empty<int>()                       // []
```
