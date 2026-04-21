# LINQ Concatenation Operator

> Source code: [ConcatenationExamples.cs](../source/ConcatenationExamples.cs)

The concatenation operator joins two sequences end-to-end into a single sequence. It is found in the `System.Linq` namespace.

---

## Operators

### `Concat`

Appends the elements of a second sequence after all elements of the first, preserving order and duplicates.

```csharp
int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
int[] numbersB = { 1, 3, 5, 7, 8 };

IEnumerable<int> all = numbersA.Concat(numbersB);
// 0, 2, 4, 5, 6, 8, 9, 1, 3, 5, 7, 8
```

Works with any element type:

```csharp
string[] wordsA = { "apple", "banana" };
string[] wordsB = { "cherry", "banana" };

IEnumerable<string> allWords = wordsA.Concat(wordsB);
// "apple", "banana", "cherry", "banana"  ← "banana" appears twice
```

---

### `Concat` + `Distinct` (equivalent to `Union`)

When you want to merge two sequences and remove duplicates, chain `Distinct()` after `Concat()`. This is semantically identical to `Union` but makes the intent explicit.

```csharp
IEnumerable<int> unique = numbersA.Concat(numbersB).Distinct();
// 0, 2, 4, 5, 6, 8, 9, 1, 3, 7  ← duplicates removed
```

> **Tip:** Prefer `Union` for brevity, but `Concat().Distinct()` when you want to separate the "combine" and "deduplicate" steps for clarity.

---

## Best Practices

- **Deferred execution** – `Concat` does not enumerate either source until you iterate the result. Avoid side effects inside the sequences that depend on evaluation order.
- **Duplicates are preserved** – use `Union` (or `Concat + Distinct`) if you need set semantics.
- **Prefer `Concat` over `AddRange`** when you only need a single lazy pass and do not want to allocate a new list.
- **Both sequences must share the same element type** (`IEnumerable<T>`). Use `Cast<T>` or `OfType<T>` to align types when needed.

---

## See Also

- [Set Operations](set-operations.md) – `Union`, `Intersect`, `Except`
- [Filtering](filtering.md) – `Where`, `OfType`
