namespace CSVRead_SortData;

// Products that share a name (compared case-insensitively), shown under the first spelling seen.
internal sealed record ProductGroup(string Name, IReadOnlyList<Product> Products);
