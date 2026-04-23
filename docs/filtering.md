# LINQ Filtering Operators

> Source code: [FilteringExamples.cs](../source/FilteringExamples.cs)

Filtering operators select elements from a sequence that satisfy a condition.

---

## Operators

### `Where`

Returns only the elements that match a predicate.

```csharp
int[] numbers = [1, 2, 3, 4, 5, 6];

IEnumerable<int> evens = numbers.Where(n => n % 2 == 0); // [2, 4, 6]
```

**With index overload** — the predicate also receives the zero-based position of each element:

```csharp
// Keep elements at even positions (0, 2, 4, …)
IEnumerable<int> evenIndex = numbers.Where((_, i) => i % 2 == 0); // [1, 3, 5]
```

---

### `OfType<T>`

Filters a mixed-type sequence, returning only elements that are of type `T`. Elements of other types are silently skipped.

```csharp
object[] items = ["hello", 1, "world", 2.5, "!"];

IEnumerable<string> strings = items.OfType<string>(); // ["hello", "world", "!"]
```

> Compare with `Cast<T>`: `OfType<T>` skips incompatible elements, while `Cast<T>` throws `InvalidCastException` on the first incompatible element.

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Prefer `Where` over manual `foreach` + `if` | More readable, composable, and consistent with the rest of a LINQ pipeline. |
| 2 | Keep predicates short and focused | Long lambdas are hard to read; extract complex logic into a named method. |
| 3 | Prefer `OfType<T>` over `Cast<T>` for mixed-type sequences | `OfType<T>` is safe; `Cast<T>` throws on the first bad element. |
| 4 | Apply `Where` early in a pipeline | Reduces the number of elements flowing through later, more expensive operators. |

---

## Quick Reference

```csharp
var numbers = new[] { 1, 2, 3, 4, 5, 6 };
var items   = new object[] { "hello", 1, "world", 2.5 };

numbers.Where(n => n % 2 == 0)          // [2, 4, 6]
numbers.Where((_, i) => i % 2 == 0)     // [1, 3, 5]  (even-index elements)
items.OfType<string>()                   // ["hello", "world"]
```
