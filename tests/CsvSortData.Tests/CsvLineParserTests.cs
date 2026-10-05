using CSVRead_SortData;
using Shouldly;
using Xunit;

namespace CsvSortData.Tests;

public class CsvLineParserTests
{
    [Fact]
    public void TryParse_ValidLine_ReturnsProduct()
    {
        var ok = CsvLineParser.TryParse("Laptop,799.99,10", out var product);

        ok.ShouldBeTrue();
        product.ShouldNotBeNull();
        product!.ProductName.ShouldBe("Laptop");
        product.Price.ShouldBe(799.99m);
        product.Quantity.ShouldBe(10);
    }

    [Fact]
    public void TryParse_TrimsSurroundingWhitespaceInName()
    {
        var ok = CsvLineParser.TryParse(" Wireless Mouse , 24.50, 3", out var product);

        ok.ShouldBeTrue();
        product!.ProductName.ShouldBe("Wireless Mouse");
        product.Price.ShouldBe(24.50m);
        product.Quantity.ShouldBe(3);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("OnlyName,10")]          // too few columns
    [InlineData("Widget,not-a-price,5")] // non-numeric price
    [InlineData("Widget,9.99,not-int")]  // non-numeric quantity
    [InlineData("\"Cable, USB-C,5.00,4")] // unmatched quote
    public void TryParse_InvalidLine_ReturnsFalseAndNullProduct(string? line)
    {
        var ok = CsvLineParser.TryParse(line, out var product);

        ok.ShouldBeFalse();
        product.ShouldBeNull();
    }

    [Theory]
    [InlineData("\"Cable, USB-C\",5.00,4", "Cable, USB-C", 5.00, 4)]    // comma inside quotes
    [InlineData("\"Keyboard\",45,2", "Keyboard", 45, 2)]                 // quotes are not part of the name
    [InlineData("\"12\"\" Ruler\",3.50,1", "12\" Ruler", 3.50, 1)]       // "" is an escaped quote
    [InlineData("\"Widget\",\"9.99\",\"5\"", "Widget", 9.99, 5)]         // every field quoted
    public void TryParse_QuotedFields_AreUnquoted(string line, string name, double price, int quantity)
    {
        var ok = CsvLineParser.TryParse(line, out var product);

        ok.ShouldBeTrue();
        product!.ProductName.ShouldBe(name);
        product.Price.ShouldBe((decimal)price);
        product.Quantity.ShouldBe(quantity);
    }

    [Fact]
    public void TryParse_ExtraColumns_UsesFirstThree()
    {
        var ok = CsvLineParser.TryParse("Cable,5.00,100,ignored,extra", out var product);

        ok.ShouldBeTrue();
        product!.ProductName.ShouldBe("Cable");
        product.Price.ShouldBe(5.00m);
        product.Quantity.ShouldBe(100);
    }
}
