namespace CSVRead_SortData;

// Abstraction over the source of products so callers (and tests) do not depend
// on a concrete CSV/file implementation.
internal interface IProductReader
{
    CsvReadResult ReadProducts(string filePath);
}
