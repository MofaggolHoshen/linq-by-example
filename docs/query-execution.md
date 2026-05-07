# LINQ Query Execution

> Source code: [QueryExecutionExamples.cs](../source/QueryExecutionExamples.cs)

Understanding when a LINQ query actually runs is essential for writing correct and performant code. LINQ operators fall into two categories: **deferred** (lazy) and **immediate** (eager).

---

## Deferred Execution

Most LINQ operators — `Where`, `Select`, `OrderBy`, `GroupBy`, `Skip`, `Take`, and others — use **deferred execution**. The query is defined as a description of work, but no elements are processed until you enumerate the result.

```csharp
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

// Nothing is evaluated here – lowNumbers is just a query object.
IEnumerable<int> lowNumbers = numbers.Where(n => n <= 3);

// Execution happens here, as the foreach iterates.
foreach (int n in lowNumbers)
    Console.WriteLine(n); // 1, 3, 2, 0
```

---

## Immediate Execution

Operators that return a **scalar value** or a **materialised collection** force the query to run immediately:

| Operator | Returns |
|---|---|
| `ToList()` / `ToArray()` | `List<T>` / `T[]` |
| `Count()` / `LongCount()` | `int` / `long` |
| `First()` / `Last()` / `Single()` | `T` |
| `Min()` / `Max()` / `Sum()` / `Average()` | scalar |
| `ToDictionary()` / `ToHashSet()` | collection |

```csharp
// ToList() executes the query right now and stores results in memory.
List<int> snapshot = numbers.Where(n => n <= 3).ToList();
// snapshot: [1, 3, 2, 0]
```

---

## Deferred Queries Re-evaluate on Each Enumeration

Because deferred queries read from the source at enumeration time, mutations to the source between enumerations are reflected in the result.

```csharp
int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
var lowNumbers = numbers.Where(n => n <= 3);

var before = lowNumbers.ToList(); // [1, 3, 2, 0]

// Negate all values in the source array.
for (int i = 0; i < numbers.Length; i++)
    numbers[i] = -numbers[i];

var after = lowNumbers.ToList(); // [-5, -4, -1, -3, -9, -8, -6, -7, -2, 0]
// All negated values are <= 3, so the entire array matches now.
```

> **Tip:** Call `ToList()` or `ToArray()` to snapshot a query result and decouple it from future source changes.

---

## Best Practices

- **Avoid multiple enumerations** of a deferred query over an expensive source (e.g., a database query or a file stream). Materialise with `ToList()` / `ToArray()` when you need to iterate more than once.
- **Be aware of captured variables** – deferred queries close over variables by reference. Mutating a captured variable before enumeration changes the query's behaviour.
- **Prefer deferred execution** in pipeline compositions; only materialise at the boundary where you actually need the data.
- **Immediate operators short-circuit where possible** – `First()`, `Any()`, and `Count(predicate)` stop early once the answer is known.

---

## See Also

- [Filtering](filtering.md) – `Where`, `OfType`
- [Partitioning](partitioning.md) – `Take`, `Skip`
- [Conversion](conversion.md) – `ToList`, `ToArray`, `ToDictionary`
