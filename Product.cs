namespace CSVRead_SortData;

// Immutable model representing a single product row from the CSV.
// A record gives value-equality, which keeps sorting/parsing tests simple.
internal sealed record Product(string ProductName, decimal Price, int Quantity);
