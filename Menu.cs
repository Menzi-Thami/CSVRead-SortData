namespace CSVRead_SortData;

// Drives the interactive loop: shows options, reads the user's choice, and
// delegates sorting to IProductSorter and rendering to IProductPrinter.
internal sealed class Menu
{
    private readonly IProductSorter _sorter;
    private readonly IProductPrinter _printer;

    public Menu(IProductSorter sorter, IProductPrinter printer)
    {
        _sorter = sorter ?? throw new ArgumentNullException(nameof(sorter));
        _printer = printer ?? throw new ArgumentNullException(nameof(printer));
    }

    public void ShowMenu()
    {
        while (true)
        {
            PrintOptions();

            if (!int.TryParse(Console.ReadLine(), out var choice))
            {
                _printer.PrintError("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    _printer.PrintProducts(_sorter.SortByPriceAscending());
                    break;
                case 2:
                    _printer.PrintProducts(_sorter.SortByQuantityAscending());
                    break;
                case 3:
                    _printer.PrintProducts(_sorter.SortByNameAscending());
                    break;
                case 4:
                    _printer.PrintGroupedProducts(_sorter.GroupByNameAndSort());
                    break;
                case 5:
                    return;
                default:
                    _printer.PrintError("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void PrintOptions()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Sort by Price (ascending)");
        Console.WriteLine("2. Sort by Quantity (ascending)");
        Console.WriteLine("3. Sort alphabetically by Product Name (ascending)");
        Console.WriteLine("4. Group by Product Name and sort each group by Price (ascending)");
        Console.WriteLine("5. Exit");
        Console.ResetColor();
        Console.Write("Enter your choice: ");
    }
}
