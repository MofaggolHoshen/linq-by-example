# LINQ Joining Operators

> Source code: [JoiningExamples.cs](../source/JoiningExamples.cs)

Joining operators combine two sequences based on related keys or position.

---

## Operators

### `Join`

Performs an **inner join** — only elements with matching keys in both sequences are included.

```csharp
record Customer(int CustomerId, string Name);
record Order(int OrderId, int CustomerId, string Product);

var customers = new[] { new Customer(1, "Alice"), new Customer(2, "Bob"), new Customer(3, "Carol") };
var orders    = new[] { new Order(101, 1, "Widget"), new Order(102, 1, "Gadget"), new Order(103, 2, "Doohickey") };

var result = customers.Join(
    orders,
    customer => customer.CustomerId,   // outer key
    order    => order.CustomerId,      // inner key
    (customer, order) => (customer.Name, order.Product));

// ("Alice", "Widget"), ("Alice", "Gadget"), ("Bob", "Doohickey")
// Carol is NOT included — she has no orders
```

---

### `GroupJoin`

Performs a **left outer join** — every element from the left sequence appears in the result, paired with a (possibly empty) collection of matching elements from the right.

```csharp
var result = customers.GroupJoin(
    orders,
    customer => customer.CustomerId,
    order    => order.CustomerId,
    (customer, customerOrders) => (customer.Name, OrderCount: customerOrders.Count()));

// ("Alice", 2), ("Bob", 1), ("Carol", 0)  ← Carol included with 0 orders
```

---

### `Zip`

Combines two sequences **by position**, pairing the Nth element of each sequence together. If the sequences differ in length, the shorter one wins and extra elements are discarded.

```csharp
string[] names  = ["Alice", "Bob", "Carol"];
int[]    scores = [95, 87, 92];

var result = names.Zip(scores, (name, score) => $"{name}: {score}");
// ["Alice: 95", "Bob: 87", "Carol: 92"]
```

---

## Best Practices

| # | Practice | Reason |
|---|----------|--------|
| 1 | Use `Join` for inner joins, `GroupJoin` for left outer joins | Matches standard SQL semantics and intent is explicit. |
| 2 | Avoid Cartesian products (nested `SelectMany` without a filter) on large collections | Complexity grows as O(n×m). |
| 3 | Use `Zip` only when element-by-element pairing by position makes semantic sense | If sequences differ in length, extra elements are silently dropped. |
| 4 | Consider `Dictionary` or `ToLookup` for repeated join lookups | Avoids O(n×m) hash joins being re-evaluated on every iteration. |

---

## Quick Reference

```csharp
// Inner join
customers.Join(orders, c => c.Id, o => o.CustomerId, (c, o) => (c.Name, o.Product))

// Left outer join (all customers, even those with no orders)
customers.GroupJoin(orders, c => c.Id, o => o.CustomerId,
    (c, orders) => (c.Name, Count: orders.Count()))

// Zip by position
names.Zip(scores, (name, score) => $"{name}: {score}")
```
