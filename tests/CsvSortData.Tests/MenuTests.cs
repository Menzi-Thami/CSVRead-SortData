using CSVRead_SortData;
using Shouldly;
using Xunit;

namespace CsvSortData.Tests;

public class MenuTests
{
    // ShowMenu used to spin forever at end of input; fail fast instead of hanging the run.
    private static readonly TimeSpan Timeout = TimeSpan.FromSeconds(5);

    [Fact]
    public async Task ShowMenu_ReturnsWhenInputEnds()
    {
        var printer = new RecordingPrinter();
        var menu = new Menu(new ProductSorter([new Product("Laptop", 799.99m, 10)]), printer, new StringReader(""));

        await Task.Run(menu.ShowMenu).WaitAsync(Timeout);

        printer.PrintProductsCalls.ShouldBe(0);
    }

    [Fact]
    public async Task ShowMenu_ReturnsWhenInputEndsAfterAChoice()
    {
        var printer = new RecordingPrinter();
        var menu = new Menu(new ProductSorter([new Product("Laptop", 799.99m, 10)]), printer, new StringReader("1\n"));

        await Task.Run(menu.ShowMenu).WaitAsync(Timeout);

        printer.PrintProductsCalls.ShouldBe(1);
    }

    [Fact]
    public async Task ShowMenu_RunsChoiceThenExits()
    {
        var printer = new RecordingPrinter();
        var menu = new Menu(new ProductSorter([new Product("Laptop", 799.99m, 10)]), printer, new StringReader("1\n5\n"));

        await Task.Run(menu.ShowMenu).WaitAsync(Timeout);

        printer.PrintProductsCalls.ShouldBe(1);
        printer.Errors.ShouldBeEmpty();
    }

    private sealed class RecordingPrinter : IProductPrinter
    {
        public int PrintProductsCalls { get; private set; }
        public List<string> Errors { get; } = [];

        public void PrintProducts(IReadOnlyList<Product> products) => PrintProductsCalls++;
        public void PrintGroupedProducts(IReadOnlyList<ProductGroup> groupedProducts) { }
        public void PrintInvalidLines(IReadOnlyList<string> invalidLines) { }
        public void PrintError(string message) => Errors.Add(message);
    }
}
