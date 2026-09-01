namespace CSVRead_SortData;

// Reads products from a CSV file. Responsible only for file access and turning
// lines into products (delegated to CsvLineParser) — never for displaying them.
internal sealed class CsvProductReader : IProductReader
{
    public CsvReadResult ReadProducts(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException(
                $"Error: The specified file was not found. File Path: {filePath}");
        }

        var products = new List<Product>();
        var invalidLines = new List<string>();

        try
        {
            using var reader = new StreamReader(filePath);

            // Skip the header row if present.
            reader.ReadLine();

            while (reader.ReadLine() is { } line)
            {
                if (CsvLineParser.TryParse(line, out var product))
                {
                    products.Add(product!);
                }
                else
                {
                    invalidLines.Add(line);
                }
            }
        }
        catch (IOException ex)
        {
            throw new InvalidDataException($"Error reading CSV file: {ex.Message}", ex);
        }

        if (products.Count == 0)
        {
            throw new InvalidDataException("No valid products found in the CSV file.");
        }

        return new CsvReadResult(products, invalidLines);
    }
}
