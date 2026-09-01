namespace CSVRead_SortData;

// Console implementation of IProductPrinter. Owns all colour/formatting concerns.
internal sealed class ConsoleProductPrinter : IProductPrinter
{
    private const string TableHeader = "Product Name\tPrice (ZAR)\tQuantity";

    public void PrintProducts(IReadOnlyList<Product> products)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Sorted Products:");
        Console.ResetColor();
        Console.WriteLine(TableHeader);

        foreach (var product in products)
        {
            PrintRow(product);
        }
    }

    public void PrintGroupedProducts(IReadOnlyDictionary<string, List<Product>> groupedProducts)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Grouped and Sorted Products:");
        Console.ResetColor();
        Console.WriteLine(TableHeader);

        foreach (var group in groupedProducts)
        {
            Console.WriteLine($"--- {group.Key} ---");

            foreach (var product in group.Value)
            {
                PrintRow(product);
            }

            Console.WriteLine();
        }
    }

    public void PrintInvalidLines(IReadOnlyList<string> invalidLines)
    {
        foreach (var line in invalidLines)
        {
            Console.WriteLine($"Invalid data in CSV: {line}");
        }
    }

    public void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void PrintRow(Product product) =>
        Console.WriteLine($"{product.ProductName}\t\t{product.Price}\t\t{product.Quantity}");
}
