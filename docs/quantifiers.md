# LINQ Quantifier Operators

> Source code: [QuantifierExamples.cs](../source/QuantifierExamples.cs)

Quantifier operators return a `bool` that describes whether some or all elements of a sequence satisfy a condition.

---

## Operators

### `Any`

Returns `true` if **at least one** element satisfies the predicate.  
Without a predicate, returns `true` if the sequence is non-empty.

```csharp
int[] numbers = [1, 2, 3, 4, 5];

bool hasEven    = numbers.Any(n => n % 2 == 0); // true
bool isNonEmpty = numbers.Any();                // true
bool emptyCheck = Array.Empty<int>().Any();     // false
```

> Short-circuits as soon as a matching element is found — more efficient than `Count() > 0` for large sequences.

---

### `All`

Returns `true` only if **every** element satisfies the predicate.

```csharp
bool allPositive  = numbers.All(n => n > 0);  // true
bool allEven      = numbers.All(n => n % 2 == 0); // false
bool vacuousTrue  = Array.Empty<int>().All(n => n > 0); // true (empty sequence)
```

> Returns `true` for an empty sequence (vacuous truth). Validate sequence length separately if an empty sequence should be considered a failure.

---

### `Contains`

Returns `true` if the sequence contains a specific element, using equality comparison.

```csharp
bool hasThree = numbers.Contains(3); // true
bool hasTen   = numbers.Contains(10); // false

// Case-insensitive string search with a custom comparer
string[] words = ["apple", "banana", "cherry"];
bool found = words.Contains("APPLE", StringComparer.OrdinalIgnoreCase); // true
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Prefer `Any()` over `Count() > 0` for existence checks | `Any` short-circuits; `Count` enumerates the entire sequence. |
| 2 | Guard against vacuous truth with `All` | `All` returns `true` on an empty sequence, which may not match your business rules. |
| 3 | Pass a custom `IEqualityComparer` to `Contains` when default equality is inappropriate | Example: case-insensitive string matching. |

---

## Quick Reference

```csharp
numbers.Any(n => n % 2 == 0)                              // true — has even?
numbers.Any()                                              // true — non-empty?
numbers.All(n => n > 0)                                   // true — all positive?
numbers.Contains(3)                                        // true
words.Contains("APPLE", StringComparer.OrdinalIgnoreCase) // true
```
