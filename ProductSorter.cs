namespace CSVRead_SortData;

// Sorts and groups a supplied set of products. Pure logic (no I/O), so it is
// directly unit-testable.
internal sealed class ProductSorter : IProductSorter
{
    private readonly IReadOnlyList<Product> _products;

    public ProductSorter(IReadOnlyList<Product> products)
    {
        _products = products ?? throw new ArgumentNullException(nameof(products));
    }

    public IReadOnlyList<Product> SortByPriceAscending() =>
        _products.OrderBy(p => p.Price).ToList();

    public IReadOnlyList<Product> SortByQuantityAscending() =>
        _products.OrderBy(p => p.Quantity).ToList();

    public IReadOnlyList<Product> SortByNameAscending() =>
        _products.OrderBy(p => p.ProductName).ToList();

    // Grouping is a key match, so ordinal-ignore-case ("apple" and "Apple" are one product);
    // the group order is a user-facing alphabetical list, so it uses the user's culture.
    public IReadOnlyList<ProductGroup> GroupByNameAndSort() =>
        _products.GroupBy(p => p.ProductName, StringComparer.OrdinalIgnoreCase)
                 .OrderBy(g => g.Key, StringComparer.CurrentCulture)
                 .Select(g => new ProductGroup(g.Key, g.OrderBy(p => p.Price).ToList()))
                 .ToList();
}
