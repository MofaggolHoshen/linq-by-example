# LINQ by Example — Documentation

A quick-reference guide for every LINQ operator, each with examples, explanations, and best practices.

---

## Table of Contents

- [Aggregation](#aggregation)
  - `Count` · `LongCount` · `Sum` · `Min` · `Max` · `MinBy` · `MaxBy` · `Average` · `Aggregate`
- [Conversion](#conversion)
  - `ToArray` · `ToList` · `ToDictionary` · `ToHashSet` · `Cast` · `OfType` · `AsEnumerable`
- [Element Operations](#element-operations)
  - `First` · `FirstOrDefault` · `Last` · `LastOrDefault` · `Single` · `SingleOrDefault` · `ElementAt` · `ElementAtOrDefault`
- [Filtering](#filtering)
  - `Where` · `OfType`
- [Generation](#generation)
  - `Range` · `Repeat` · `Empty`
- [Grouping](#grouping)
  - `GroupBy` · `ToLookup`
- [Joining](#joining)
  - `Join` · `GroupJoin` · `Zip`
- [Ordering](#ordering)
  - `OrderBy` · `OrderByDescending` · `ThenBy` · `ThenByDescending` · `Reverse`
- [Partitioning](#partitioning)
  - `Take` · `TakeWhile` · `Skip` · `SkipWhile` · `Chunk`
- [Projection](#projection)
  - `Select` · `SelectMany`
- [Quantifiers](#quantifiers)
  - `Any` · `All` · `Contains`
- [Set Operations](#set-operations)
  - `Distinct` · `DistinctBy` · `Union` · `Intersect` · `Except`

---

## Aggregation

[📄 Doc](aggregation.md) · [💻 Source](../source/AggregationExamples.cs)

| Operator | Description |
|----------|-------------|
| `Count` | Number of elements, optionally filtered by a predicate |
| `LongCount` | Like `Count` but returns `long` — use for very large sequences |
| `Sum` | Sum of all elements or projected values |
| `Min` | Smallest value in the sequence |
| `Max` | Largest value in the sequence |
| `MinBy` | Element whose projected value is smallest (.NET 6+) |
| `MaxBy` | Element whose projected value is largest (.NET 6+) |
| `Average` | Arithmetic mean |
| `Aggregate` | General-purpose fold — accumulates a result over every element |

---

## Conversion

[📄 Doc](conversion.md) · [💻 Source](../source/ConversionExamples.cs)

| Operator | Description |
|----------|-------------|
| `ToArray` | Materialises the sequence as a `T[]` |
| `ToList` | Materialises the sequence as a `List<T>` |
| `ToDictionary` | Creates a `Dictionary<TKey, TValue>` keyed by a selector |
| `ToHashSet` | Creates a `HashSet<T>`, removing duplicates |
| `Cast<T>` | Casts every element to `T`; throws on a bad cast |
| `OfType<T>` | Filters to elements that are of type `T`; skips others |
| `AsEnumerable` | Returns the sequence typed as `IEnumerable<T>` |

---

## Element Operations

[📄 Doc](element-operations.md) · [💻 Source](../source/ElementOperationExamples.cs)

| Operator | Description |
|----------|-------------|
| `First` | First element; throws if empty |
| `FirstOrDefault` | First element or `default` if empty |
| `Last` | Last element; throws if empty |
| `LastOrDefault` | Last element or `default` if empty |
| `Single` | The only element; throws if 0 or more than 1 |
| `SingleOrDefault` | The only element or `default`; throws if more than 1 |
| `ElementAt` | Element at a zero-based index; throws if out of range |
| `ElementAtOrDefault` | Element at index or `default` if out of range |

---

## Filtering

[📄 Doc](filtering.md) · [💻 Source](../source/FilteringExamples.cs)

| Operator | Description |
|----------|-------------|
| `Where` | Returns elements that satisfy a predicate |
| `OfType<T>` | Filters to elements of a specific type |

---

## Generation

[📄 Doc](generation.md) · [💻 Source](../source/GenerationExamples.cs)

| Operator | Description |
|----------|-------------|
| `Range` | Generates a contiguous sequence of integers |
| `Repeat` | Generates a sequence repeating an element N times |
| `Empty<T>` | Returns a cached, allocation-free empty sequence |

---

## Grouping

[📄 Doc](grouping.md) · [💻 Source](../source/GroupingExamples.cs)

| Operator | Description |
|----------|-------------|
| `GroupBy` | Groups elements by a key selector (deferred) |
| `ToLookup` | Groups elements by a key selector (eager, cached) |

---

## Joining

[📄 Doc](joining.md) · [💻 Source](../source/JoiningExamples.cs)

| Operator | Description |
|----------|-------------|
| `Join` | Inner join on a matching key |
| `GroupJoin` | Left outer join — each left element paired with its matching right elements |
| `Zip` | Combines two sequences element-by-element by position |

---

## Ordering

[📄 Doc](ordering.md) · [💻 Source](../source/OrderingExamples.cs)

| Operator | Description |
|----------|-------------|
| `OrderBy` | Sorts ascending by a key |
| `OrderByDescending` | Sorts descending by a key |
| `ThenBy` | Secondary ascending sort |
| `ThenByDescending` | Secondary descending sort |
| `Reverse` | Reverses the current sequence order |

---

## Partitioning

[📄 Doc](partitioning.md) · [💻 Source](../source/PartitioningExamples.cs)

| Operator | Description |
|----------|-------------|
| `Take` | Returns the first N elements |
| `TakeWhile` | Returns elements while a predicate holds |
| `Skip` | Bypasses the first N elements |
| `SkipWhile` | Bypasses elements while a predicate holds |
| `Chunk` | Splits into fixed-size arrays (.NET 6+) |

---

## Projection

[📄 Doc](projection.md) · [💻 Source](../source/ProjectionExamples.cs)

| Operator | Description |
|----------|-------------|
| `Select` | Transforms each element into a new form |
| `SelectMany` | Flattens nested collections into a single sequence |

---

## Quantifiers

[📄 Doc](quantifiers.md) · [💻 Source](../source/QuantifierExamples.cs)

| Operator | Description |
|----------|-------------|
| `Any` | `true` if at least one element satisfies the condition |
| `All` | `true` only if every element satisfies the condition |
| `Contains` | `true` if the sequence contains a specific element |

---

## Set Operations

[📄 Doc](set-operations.md) · [💻 Source](../source/SetOperationExamples.cs)

| Operator | Description |
|----------|-------------|
| `Distinct` | Removes duplicate elements |
| `DistinctBy` | Keeps the first element per distinct key (.NET 6+) |
| `Union` | All elements from both sequences, duplicates removed |
| `Intersect` | Elements present in both sequences |
| `Except` | Elements in the first sequence not in the second |
