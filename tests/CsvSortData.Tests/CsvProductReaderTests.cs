using CSVRead_SortData;
using Shouldly;
using Xunit;

namespace CsvSortData.Tests;

public sealed class CsvProductReaderTests : IDisposable
{
    private readonly string _path = Path.Combine(Path.GetTempPath(), $"csvreader-{Guid.NewGuid():N}.csv");

    public void Dispose() => File.Delete(_path);

    [Fact]
    public void ReadProducts_WithHeader_ReadsEveryProduct()
    {
        File.WriteAllLines(_path, ["ProductName,Price,Quantity", "Laptop,799.99,10", "Mouse,24.50,3"]);

        var result = new CsvProductReader().ReadProducts(_path);

        result.Products.Select(p => p.ProductName).ShouldBe(["Laptop", "Mouse"]);
        result.InvalidLines.ShouldBeEmpty();
    }

    [Fact]
    public void ReadProducts_WithoutHeader_DoesNotDropTheFirstProduct()
    {
        File.WriteAllLines(_path, ["Laptop,799.99,10", "Mouse,24.50,3"]);

        var result = new CsvProductReader().ReadProducts(_path);

        result.Products.Select(p => p.ProductName).ShouldBe(["Laptop", "Mouse"]);
        result.InvalidLines.ShouldBeEmpty();
    }
}
