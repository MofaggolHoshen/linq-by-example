# LINQ Ordering Operators

> Source code: [OrderingExamples.cs](../source/OrderingExamples.cs)

Ordering operators sort a sequence by one or more keys.

---

## Operators

### `OrderBy` / `OrderByDescending`

Sorts the sequence in ascending or descending order by a key selector.

```csharp
int[] numbers = [3, 1, 4, 1, 5, 9, 2, 6];

IEnumerable<int> asc  = numbers.OrderBy(n => n);           // [1, 1, 2, 3, 4, 5, 6, 9]
IEnumerable<int> desc = numbers.OrderByDescending(n => n); // [9, 6, 5, 4, 3, 2, 1, 1]
```

---

### `ThenBy` / `ThenByDescending`

Adds a **secondary** sort key to an already-ordered sequence. Chain as many `ThenBy` calls as needed.

```csharp
var people = new[]
{
    ("Smith", "John"),
    ("Adams", "John"),
    ("Smith", "Alice"),
};

var sorted = people
    .OrderBy(p => p.Item1, StringComparer.OrdinalIgnoreCase)   // primary: last name
    .ThenBy(p => p.Item2, StringComparer.OrdinalIgnoreCase);   // secondary: first name

// ("Adams", "John"), ("Smith", "Alice"), ("Smith", "John")
```

---

### `Reverse`

Reverses the current order of the sequence.

```csharp
IEnumerable<int> reversed = numbers.Reverse(); // [6, 2, 9, 5, 1, 4, 1, 3]
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Use `ThenBy` for multi-key sorting — never call `OrderBy` twice | A second `OrderBy` discards the first sort entirely. |
| 2 | Pass `StringComparer.OrdinalIgnoreCase` when sorting strings | Ensures culture-insensitive, deterministic ordering. |
| 3 | Prefer `OrderByDescending` over `OrderBy` + `Reverse` | `Reverse` makes a full copy of the sequence; `OrderByDescending` is more efficient. |
| 4 | Sort as late as possible in the pipeline | Sorting is O(n log n); reducing elements with `Where` first lowers the cost. |

---

## Quick Reference

```csharp
numbers.OrderBy(n => n)                                  // [1, 1, 2, 3, 4, 5, 6, 9]
numbers.OrderByDescending(n => n)                        // [9, 6, 5, 4, 3, 2, 1, 1]
people.OrderBy(p => p.Last).ThenBy(p => p.First)        // multi-key sort
numbers.Reverse()                                        // reverses current order
```
