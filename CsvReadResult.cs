namespace CSVRead_SortData;

// Outcome of reading a CSV file: the products that parsed successfully and
// the raw text of any lines that did not. Returning the bad lines (rather than
// printing them) keeps the reader free of presentation concerns.
internal sealed record CsvReadResult(
    IReadOnlyList<Product> Products,
    IReadOnlyList<string> InvalidLines);
