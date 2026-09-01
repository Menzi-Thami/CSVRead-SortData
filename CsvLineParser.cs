using System.Globalization;

namespace CSVRead_SortData;

// Pure, side-effect-free parsing of a single CSV line into a Product.
// Kept separate from file I/O so the parsing rules can be unit-tested in isolation.
internal static class CsvLineParser
{
    // Expected line format: ProductName,Price,Quantity  (e.g. "Laptop,799.99,10").
    // Returns true and a Product when the line is valid; false otherwise.
    public static bool TryParse(string? line, out Product? product)
    {
        product = null;

        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        var values = line.Split(',');

        if (values.Length >= 3 &&
            decimal.TryParse(values[1], NumberStyles.Currency, CultureInfo.InvariantCulture, out var price) &&
            int.TryParse(values[2], out var quantity))
        {
            product = new Product(values[0].Trim(), price, quantity);
            return true;
        }

        return false;
    }
}
