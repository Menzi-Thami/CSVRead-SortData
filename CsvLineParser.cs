using System.Globalization;
using System.Text;

namespace CSVRead_SortData;

// Pure, side-effect-free parsing of a single CSV line into a Product.
// Kept separate from file I/O so the parsing rules can be unit-tested in isolation.
internal static class CsvLineParser
{
    // No sign, parentheses, thousands separators or currency symbols, so negatives are invalid
    // lines and the result never depends on the machine's culture.
    private const NumberStyles PriceStyle =
        NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowDecimalPoint;
    private const NumberStyles QuantityStyle =
        NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite;

    // Expected line format: ProductName,Price,Quantity  (e.g. "Laptop,799.99,10").
    // Fields may be quoted as Excel writes them: "Cable, USB-C",5.00,4 and "" for a literal quote.
    // Returns true and a Product when the line is valid; false otherwise.
    public static bool TryParse(string? line, out Product? product)
    {
        product = null;

        if (string.IsNullOrWhiteSpace(line))
        {
            return false;
        }

        var values = SplitFields(line);

        if (values is { Count: >= 3 } &&
            decimal.TryParse(values[1], PriceStyle, CultureInfo.InvariantCulture, out var price) &&
            int.TryParse(values[2], QuantityStyle, CultureInfo.InvariantCulture, out var quantity))
        {
            product = new Product(values[0].Trim(), price, quantity);
            return true;
        }

        return false;
    }

    // Splits on commas outside double quotes. Returns null when a quote is never closed.
    private static List<string>? SplitFields(string line)
    {
        var fields = new List<string>();
        var current = new StringBuilder();
        var inQuotes = false;

        for (var i = 0; i < line.Length; i++)
        {
            var c = line[i];

            if (inQuotes)
            {
                if (c != '"')
                {
                    current.Append(c);
                }
                else if (i + 1 < line.Length && line[i + 1] == '"')
                {
                    current.Append('"');
                    i++;
                }
                else
                {
                    inQuotes = false;
                }
            }
            else if (c == '"')
            {
                inQuotes = true;
            }
            else if (c == ',')
            {
                fields.Add(current.ToString());
                current.Clear();
            }
            else
            {
                current.Append(c);
            }
        }

        if (inQuotes)
        {
            return null;
        }

        fields.Add(current.ToString());
        return fields;
    }
}
