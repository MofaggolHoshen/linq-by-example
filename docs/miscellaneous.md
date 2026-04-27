# LINQ Miscellaneous Operators

> Source code: [MiscellaneousExamples.cs](../source/MiscellaneousExamples.cs)

Miscellaneous operators cover equality comparison between sequences. They are found in the `System.Linq` namespace.

---

## Operators

### `SequenceEqual`

Returns `true` when two sequences have the same number of elements and every corresponding pair of elements is equal.

```csharp
var wordsA = new[] { "cherry", "apple", "blueberry" };
var wordsB = new[] { "cherry", "apple", "blueberry" };
var wordsC = new[] { "apple", "blueberry", "cherry" };

wordsA.SequenceEqual(wordsB); // true  – same elements, same order
wordsA.SequenceEqual(wordsC); // false – same elements, different order
```

> **Important:** `SequenceEqual` is order-sensitive. It is not equivalent to a set equality check.

---

### `SequenceEqual` with a custom comparer

Pass an `IEqualityComparer<T>` as the second argument to control how elements are compared.

```csharp
var wordsD = new[] { "Cherry", "Apple", "Blueberry" };

wordsA.SequenceEqual(wordsD, StringComparer.OrdinalIgnoreCase); // true
```

Common comparer choices:

| Comparer | Use case |
|---|---|
| `StringComparer.OrdinalIgnoreCase` | Case-insensitive ASCII strings |
| `StringComparer.CurrentCultureIgnoreCase` | Culture-aware case-insensitive |
| Custom `IEqualityComparer<T>` | Domain-specific equality |

---

### Integer sequences

```csharp
var nums1 = new[] { 1, 2, 3 };
var nums2 = new[] { 1, 2, 3 };
var nums3 = new[] { 1, 2, 4 };

nums1.SequenceEqual(nums2); // true
nums1.SequenceEqual(nums3); // false
```

---

## Best Practices

- **Order matters** – sort both sequences first if you need order-independent equality.
- **Short-circuits** – `SequenceEqual` stops as soon as a mismatching pair is found, making it efficient on sequences that differ early.
- **Different lengths are immediately unequal** – no elements are compared if the sequences have different counts.
- **Use a custom comparer** instead of pre-transforming the data (e.g., `.Select(s => s.ToLower())`) to avoid allocating new sequences.

---

## See Also

- [Set Operations](set-operations.md) – `Distinct`, `Union`, `Intersect`, `Except`
- [Quantifiers](quantifiers.md) – `Any`, `All`, `Contains`
