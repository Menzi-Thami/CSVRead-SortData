namespace CSVRead_SortData;

// Composition root: wires the reader, sorter, printer and menu together and
// handles top-level error reporting. All real work lives in the focused classes.
internal static class Program
{
    private static void Main()
    {
        IProductPrinter printer = new ConsoleProductPrinter();

        try
        {
            Console.Write("Enter the file path of the CSV file: ");
            var filePath = Console.ReadLine()?.Trim().Trim('"');

            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new InvalidDataException("Error: No file path was provided.");
            }

            IProductReader reader = new CsvProductReader();
            var result = reader.ReadProducts(filePath);

            printer.PrintInvalidLines(result.InvalidLines);

            var sorter = new ProductSorter(result.Products);
            var menu = new Menu(sorter, printer);
            menu.ShowMenu();
        }
        catch (Exception ex) when (ex is FileNotFoundException or InvalidDataException)
        {
            printer.PrintError($"An error occurred: {ex.Message}");
        }
    }
}
