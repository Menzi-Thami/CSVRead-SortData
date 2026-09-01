namespace CSVRead_SortData;

// Rendering of results to the user. Separated from the menu's input handling so
// each has a single responsibility, and so output can be swapped or asserted on.
internal interface IProductPrinter
{
    void PrintProducts(IReadOnlyList<Product> products);
    void PrintGroupedProducts(IReadOnlyDictionary<string, List<Product>> groupedProducts);
    void PrintInvalidLines(IReadOnlyList<string> invalidLines);
    void PrintError(string message);
}
