using CSVRead_SortData;
using Shouldly;
using Xunit;

namespace CsvSortData.Tests;

public class ProductSorterTests
{
    private static IReadOnlyList<Product> Sample() =>
    [
        new Product("Banana", 3.00m, 5),
        new Product("Apple", 1.50m, 20),
        new Product("Cherry", 2.25m, 2),
        new Product("Apple", 1.10m, 8),
    ];

    [Fact]
    public void SortByPriceAscending_OrdersByPrice()
    {
        var sorted = new ProductSorter(Sample()).SortByPriceAscending();

        sorted.Select(p => p.Price).ShouldBe([1.10m, 1.50m, 2.25m, 3.00m]);
    }

    [Fact]
    public void SortByQuantityAscending_OrdersByQuantity()
    {
        var sorted = new ProductSorter(Sample()).SortByQuantityAscending();

        sorted.Select(p => p.Quantity).ShouldBe([2, 5, 8, 20]);
    }

    [Fact]
    public void SortByNameAscending_OrdersAlphabetically()
    {
        var sorted = new ProductSorter(Sample()).SortByNameAscending();

        sorted.Select(p => p.ProductName).ShouldBe(["Apple", "Apple", "Banana", "Cherry"]);
    }

    [Fact]
    public void GroupByNameAndSort_GroupsByNameAndSortsEachGroupByPrice()
    {
        var grouped = new ProductSorter(Sample()).GroupByNameAndSort();

        var apple = grouped.Single(g => g.Name == "Apple");
        apple.Products.Count.ShouldBe(2);
        apple.Products.Select(p => p.Price).ShouldBe([1.10m, 1.50m]);
        grouped.Single(g => g.Name == "Cherry").Products.Single().Quantity.ShouldBe(2);
    }

    [Fact]
    public void GroupByNameAndSort_MergesNamesThatDifferOnlyByCase()
    {
        var grouped = new ProductSorter([new Product("apple", 2.00m, 1), new Product("Apple", 1.00m, 1)]).GroupByNameAndSort();

        grouped.Count.ShouldBe(1);
        grouped[0].Name.ShouldBe("apple"); // first spelling seen
        grouped[0].Products.Select(p => p.Price).ShouldBe([1.00m, 2.00m]);
    }

    [Fact]
    public void GroupByNameAndSort_OrdersGroupsByName()
    {
        // Sample() lists Banana first; groups must not come out in file order.
        var grouped = new ProductSorter(Sample()).GroupByNameAndSort();

        grouped.Select(g => g.Name).ShouldBe(["Apple", "Banana", "Cherry"]);
    }

    [Fact]
    public void Constructor_NullProducts_Throws()
    {
        Should.Throw<ArgumentNullException>(() => new ProductSorter(null!));
    }
}
