# LINQ Aggregation Operators

> Source code: [AggregationExamples.cs](../source/AggregationExamples.cs)

Aggregation operators reduce a sequence to a single value. They are found in the `System.Linq` namespace.

---

## Operators

### `Count` / `LongCount`

Returns the number of elements in a sequence, optionally filtered by a predicate.

```csharp
int[] numbers = [1, 2, 3, 4, 5];

int total     = numbers.Count();              // 5
int evenCount = numbers.Count(n => n % 2 == 0); // 2
```

Use `LongCount` when the sequence may contain more than `int.MaxValue` (~2.1 billion) elements.

---

### `Sum`

Returns the sum of all elements (or projected values).

```csharp
int sum = numbers.Sum(); // 15

// With selector – avoids an extra Select() pass
decimal total = orders.Sum(o => o.Price);
```

---

### `Min` / `Max`

Returns the smallest or largest value in the sequence.

```csharp
int min = numbers.Min(); // 1
int max = numbers.Max(); // 5
```

---

### `MinBy` / `MaxBy` (.NET 6+)

Returns the **element** whose projected value is smallest or largest — not the projected value itself.

```csharp
string[] words = ["apple", "banana", "cherry"];

string? shortest = words.MinBy(w => w.Length); // "apple"
string? longest  = words.MaxBy(w => w.Length); // "banana" or "cherry"
```

> **Note:** `Min(selector)` / `Max(selector)` return the *projected value*; `MinBy` / `MaxBy` return the *element*. Choose based on what you need.

---

### `Average`

Returns the arithmetic mean of the sequence.

```csharp
double avg = numbers.Average(); // 3.0
```

---

### `Aggregate`

The general-purpose fold operation. Applies an accumulator function over the sequence.

**Without seed** – throws `InvalidOperationException` on an empty sequence:

```csharp
int product = numbers.Aggregate((acc, n) => acc * n); // 120
```

**With seed** – safe on empty sequences:

```csharp
string csv = words.Aggregate(
    string.Empty,
    (acc, word) => acc.Length == 0 ? word : $"{acc}, {word}");
// "apple, banana, cherry"
```

**With seed and result selector** – apply a final transformation to the accumulated value:

```csharp
int runningProduct = numbers.Aggregate(
    1,
    (product, n) => product * n,
    result => result); // 120
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Prefer `Sum(x => x.Price)` over `Select(x => x.Price).Sum()` | Avoids an extra enumeration pass. |
| 2 | Always provide a **seed** to `Aggregate` when the sequence might be empty | Without a seed, `Aggregate` throws on an empty sequence. |
| 3 | Use `MinBy` / `MaxBy` (.NET 6+) to get the **element**; use `Min(selector)` / `Max(selector)` to get the **value** | Mixing them up is a common source of bugs. |
| 4 | Use `LongCount` instead of `Count` for very large sequences | `Count` returns `int`; it overflows above ~2.1 billion elements. |
| 5 | Avoid chaining multiple aggregations over the same lazy sequence | Each aggregation triggers a full iteration. Cache the result or use `foreach` when you need multiple values. |

---

## Quick Reference

```csharp
var nums  = new[] { 1, 2, 3, 4, 5 };
var words = new[] { "apple", "banana", "cherry" };

nums.Count()                          // 5
nums.Count(n => n % 2 == 0)          // 2
nums.Sum()                            // 15
nums.Min()                            // 1
nums.Max()                            // 5
nums.Average()                        // 3.0
words.MinBy(w => w.Length)           // "apple"
words.MaxBy(w => w.Length)           // "banana" (or "cherry")
nums.Aggregate(1, (p, n) => p * n)   // 120
```
