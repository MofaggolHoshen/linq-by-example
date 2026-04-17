# LINQ Conversion Operators

> Source code: [ConversionExamples.cs](../source/ConversionExamples.cs)

Conversion operators materialise a deferred LINQ query or change the static type of a sequence.

---

## Operators

### `ToArray`

Materialises the sequence as a fixed-size `T[]`.

```csharp
int[] numbers = [1, 2, 3, 4, 5];
int[] arr = numbers.Where(n => n > 2).ToArray(); // [3, 4, 5]
```

---

### `ToList`

Materialises the sequence as a `List<T>`.

```csharp
List<int> list = numbers.Where(n => n > 2).ToList(); // [3, 4, 5]
```

---

### `ToDictionary`

Creates a `Dictionary<TKey, TValue>` from a sequence using a key selector (and optionally a value selector).

```csharp
string[] words = ["hi", "hey", "hello"];
// key = word length, value = word  (keys must be unique)
Dictionary<int, string> dict = words.ToDictionary(w => w.Length, w => w);
// { 2: "hi", 3: "hey", 5: "hello" }
```

> **Note:** Throws `ArgumentException` on duplicate keys. Use `ToLookup` or `GroupBy` when uniqueness is not guaranteed.

---

### `ToHashSet`

Creates a `HashSet<T>`, removing duplicates and enabling O(1) membership tests.

```csharp
int[] nums = [1, 2, 2, 3, 3, 4];
HashSet<int> set = nums.ToHashSet(); // {1, 2, 3, 4}
```

---

### `Cast<T>`

Casts every element to `T`. Throws `InvalidCastException` if any element cannot be cast.

```csharp
object[] objects = [1, 2, 3];
IEnumerable<int> ints = objects.Cast<int>(); // [1, 2, 3]
```

---

### `OfType<T>`

Filters and casts — only elements that are actually of type `T` are returned; others are silently skipped.

```csharp
object[] mixed = ["hello", 1, "world", 2.5, "!"];
IEnumerable<string> strings = mixed.OfType<string>(); // ["hello", "world", "!"]
```

---

### `AsEnumerable`

Returns the sequence typed as `IEnumerable<T>`, hiding any provider-specific operators (e.g., EF Core's `IQueryable<T>`).

```csharp
// Forces the rest of the query to run in-memory instead of being translated to SQL
var results = dbContext.Products
    .Where(p => p.IsActive)   // translated to SQL
    .AsEnumerable()
    .Where(p => MyLocalFunc(p)); // runs in-memory
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Call `ToList` / `ToArray` to materialise deferred queries | Prevents multiple enumerations of the same lazy pipeline. |
| 2 | Use `ToDictionary` only when keys are unique | Duplicate keys throw `ArgumentException`; use `ToLookup` otherwise. |
| 3 | Prefer `ToHashSet` for duplicate removal and membership tests | O(1) lookup vs O(n) for a list. |
| 4 | Prefer `OfType<T>` over `Cast<T>` for mixed-type collections | `Cast<T>` throws on a bad element; `OfType<T>` skips it safely. |
| 5 | Use `AsEnumerable` to switch from IQueryable to in-memory evaluation | Prevents unsupported query translation errors in EF Core. |

---

## Quick Reference

```csharp
var nums  = new[] { 1, 2, 2, 3, 3, 4, 5 };
var words = new[] { "hi", "hey", "hello" };

nums.ToArray()                                          // int[]
nums.ToList()                                           // List<int>
words.ToDictionary(w => w.Length, w => w)               // Dictionary<int,string>
nums.ToHashSet()                                        // HashSet<int> {1,2,3,4,5}
new object[]{1,2,3}.Cast<int>()                         // [1, 2, 3]
new object[]{"a",1,"b"}.OfType<string>()                // ["a", "b"]
```
