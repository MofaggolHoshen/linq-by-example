using LinqByExample.Examples;

// ─────────────────────────────────────────────────────────────────────────────
//  LINQ By Example – Console Demo
//  Run this application to see every category of LINQ operator in action.
// ─────────────────────────────────────────────────────────────────────────────

static void PrintHeader(string title)
{
    Console.WriteLine();
    Console.WriteLine(new string('─', 60));
    Console.WriteLine($"  {title}");
    Console.WriteLine(new string('─', 60));
}

static void Print<T>(string label, IEnumerable<T> items) =>
    Console.WriteLine($"  {label}: [{string.Join(", ", items)}]");

static void PrintScalar<T>(string label, T value) =>
    Console.WriteLine($"  {label}: {value}");

// ── 1. Filtering ─────────────────────────────────────────────────────────────
PrintHeader("1. Filtering");
int[] numbers = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
Print("Even numbers (Where)", FilteringExamples.WhereEvenNumbers(numbers));
Print("Even-index elements (Where + index)", FilteringExamples.WhereEvenIndex(numbers));

object[] mixed = [1, "hello", 2.5, "world", 42];
Print("Strings only (OfType)", FilteringExamples.OfTypeString(mixed));

// ── 2. Projection ────────────────────────────────────────────────────────────
PrintHeader("2. Projection");
string[] names = ["alice", "bob", "carol"];
Print("Names uppercased (Select)", ProjectionExamples.SelectNames(names));
Print("Numbered names (Select + index)", ProjectionExamples.SelectWithIndex(names));

int[][] groups = [[1, 2], [3, 4], [5]];
Print("Flattened groups (SelectMany)", ProjectionExamples.SelectManyNumbers(groups));

var catalog = new[]
{
    ("Fruit",  (IEnumerable<string>)new[] { "Apple", "Banana" }),
    ("Veggie", (IEnumerable<string>)new[] { "Carrot" })
};
Print("Category items (SelectMany + result)", ProjectionExamples.SelectManyWithResult(catalog));

// ── 3. Ordering ──────────────────────────────────────────────────────────────
PrintHeader("3. Ordering");
int[] unsorted = [3, 1, 4, 1, 5, 9, 2, 6];
Print("Ascending  (OrderBy)", OrderingExamples.OrderAscending(unsorted));
Print("Descending (OrderByDescending)", OrderingExamples.OrderDescending(unsorted));

var people = new[]
{
    ("Smith", "John"), ("Adams", "Sam"), ("Smith", "Anna"), ("Adams", "John")
};
Print("By last then first name (ThenBy)",
    OrderingExamples.OrderByLastThenFirst(people).Select(p => $"{p.LastName},{p.FirstName}"));

Print("Reversed (Reverse)", OrderingExamples.ReverseSequence(new[] { 1, 2, 3, 4, 5 }));

// ── 4. Grouping ──────────────────────────────────────────────────────────────
PrintHeader("4. Grouping");
string[] fruits = ["apple", "avocado", "banana", "blueberry", "cherry"];

foreach (var g in GroupingExamples.GroupByFirstLetter(fruits))
    Console.WriteLine($"  '{g.Key}' → [{string.Join(", ", g)}]");

var employees = new[]
{
    ("Engineering", 90_000), ("Marketing", 70_000),
    ("Engineering", 85_000), ("Marketing", 75_000)
};
foreach (var (dept, total) in GroupingExamples.SumSalaryByDepartment(employees))
    Console.WriteLine($"  {dept} total salary: {total:C0}");

// ── 5. Joining ───────────────────────────────────────────────────────────────
PrintHeader("5. Joining");
var customers = new[]
{
    new JoiningExamples.Customer(1, "Alice"),
    new JoiningExamples.Customer(2, "Bob"),
    new JoiningExamples.Customer(3, "Carol")   // no orders
};
var orders = new[]
{
    new JoiningExamples.Order(101, 1, "Widget"),
    new JoiningExamples.Order(102, 1, "Gadget"),
    new JoiningExamples.Order(103, 2, "Doohickey")
};
Print("Inner join (Join)", JoiningExamples.InnerJoin(customers, orders)
    .Select(r => $"{r.CustomerName}→{r.Product}"));
Print("Left outer join (GroupJoin)", JoiningExamples.LeftOuterJoin(customers, orders)
    .Select(r => $"{r.CustomerName}({r.OrderCount} orders)"));
Print("Zip names+scores", JoiningExamples.ZipNamesAndScores(
    ["Alice", "Bob", "Carol"], [95, 87, 92]));

// ── 6. Aggregation ───────────────────────────────────────────────────────────
PrintHeader("6. Aggregation");
int[] values = [1, 2, 3, 4, 5];
PrintScalar("Count", AggregationExamples.CountAll(values));
PrintScalar("Count even", AggregationExamples.CountEven(values));
PrintScalar("Sum", AggregationExamples.Sum(values));
PrintScalar("Min", AggregationExamples.Min(values));
PrintScalar("Max", AggregationExamples.Max(values));
PrintScalar("Average", AggregationExamples.Average(values));
PrintScalar("Aggregate (comma-join)", AggregationExamples.AggregateToString(["a", "b", "c"]));
PrintScalar("Running product", AggregationExamples.RunningProduct(values));

string[] wordList = ["fig", "elderberry", "date", "kiwi"];
PrintScalar("MinBy length", AggregationExamples.MinByLength(wordList));
PrintScalar("MaxBy length", AggregationExamples.MaxByLength(wordList));

// ── 7. Set Operations ────────────────────────────────────────────────────────
PrintHeader("7. Set Operations");
int[] setA = [1, 2, 3, 4, 5];
int[] setB = [3, 4, 5, 6, 7];
Print("Distinct [1,1,2,2,3]", SetOperationExamples.Distinct([1, 1, 2, 2, 3]));
Print("Union", SetOperationExamples.Union(setA, setB));
Print("Intersect", SetOperationExamples.Intersect(setA, setB));
Print("Except (A − B)", SetOperationExamples.Except(setA, setB));
Print("DistinctBy length", SetOperationExamples.DistinctByLength(["cat", "dog", "elephant", "ox"]));

// ── 8. Quantifiers ───────────────────────────────────────────────────────────
PrintHeader("8. Quantifiers");
PrintScalar("Any even in [1,3,4]", QuantifierExamples.HasEvenNumber([1, 3, 4]));
PrintScalar("All positive in [1,2,3]", QuantifierExamples.AllPositive([1, 2, 3]));
PrintScalar("All positive in [1,-2,3]", QuantifierExamples.AllPositive([1, -2, 3]));
PrintScalar("Contains 3 in [1,2,3]", QuantifierExamples.ContainsValue([1, 2, 3], 3));
PrintScalar("Contains 'Hello' (case-insensitive)", QuantifierExamples.ContainsIgnoreCase(["hello", "world"], "Hello"));

// ── 9. Partitioning ──────────────────────────────────────────────────────────
PrintHeader("9. Partitioning");
int[] seq = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
Print("Take(3)", PartitioningExamples.TakeFirst(seq, 3));
Print("Skip(7)", PartitioningExamples.SkipFirst(seq, 7));
Print("Page 2 (size 3)", PartitioningExamples.Page(seq, 2, 3));
Print("TakeWhile positive [3,2,1,-1,2]",
    PartitioningExamples.TakeWhilePositive([3, 2, 1, -1, 2]));
Print("SkipWhile negative [-3,-2,0,1,2]",
    PartitioningExamples.SkipWhileNegative([-3, -2, 0, 1, 2]));

Console.WriteLine("  Chunk(3):");
foreach (var chunk in PartitioningExamples.ChunkBy(seq, 3))
    Console.WriteLine($"    [{string.Join(", ", chunk)}]");

// ── 10. Element Operations ───────────────────────────────────────────────────
PrintHeader("10. Element Operations");
PrintScalar("First", ElementOperationExamples.First([10, 20, 30]));
PrintScalar("Last", ElementOperationExamples.Last([10, 20, 30]));
PrintScalar("FirstEven", ElementOperationExamples.FirstEven([1, 3, 4, 6]));
PrintScalar("Single (one element)", ElementOperationExamples.Single([42]));
PrintScalar("ElementAt(1)", ElementOperationExamples.ElementAt([10, 20, 30], 1));
PrintScalar("ElementAtOrDefault(99)", ElementOperationExamples.ElementAtOrDefault([10, 20, 30], 99));

// ── 11. Generation ───────────────────────────────────────────────────────────
PrintHeader("11. Generation");
Print("Range(1, 5)", GenerationExamples.Range(1, 5));
Print("Squares(5)", GenerationExamples.Squares(5));
Print("Repeat('x', 4)", GenerationExamples.Repeat("x", 4));
Print("Empty<int>()", GenerationExamples.Empty<int>());

// ── 12. Conversion ───────────────────────────────────────────────────────────
PrintHeader("12. Conversion");
PrintScalar("ToArray type", ConversionExamples.ToArray([1, 2, 3]).GetType().Name);
PrintScalar("ToList  type", ConversionExamples.ToList([1, 2, 3]).GetType().Name);
PrintScalar("ToHashSet duplicates removed",
    ConversionExamples.ToHashSet([1, 1, 2, 3, 3]).Count);
Print("CastToInt", ConversionExamples.CastToInt(new object[] { 1, 2, 3 }));

Console.WriteLine();
Console.WriteLine("Done – all LINQ examples executed successfully.");
