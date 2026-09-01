namespace CSVRead_SortData;

// Sorting/grouping operations over a fixed set of products. An abstraction so the
// menu depends on the behaviour, not a concrete implementation (and can be tested).
internal interface IProductSorter
{
    IReadOnlyList<Product> SortByPriceAscending();
    IReadOnlyList<Product> SortByQuantityAscending();
    IReadOnlyList<Product> SortByNameAscending();
    IReadOnlyDictionary<string, List<Product>> GroupByNameAndSort();
}
