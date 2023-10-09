using CSVRead_SortData;
using System.Globalization;

class CsvReader
{
    public static List<Product> ReadProducts(string filePath)
    {
        var products = new List<Product>();

        try
        {
            // Read products from CSV file, validate data, and add to the products list
            // Handle invalid data and file reading errors
            using (var reader = new StreamReader(filePath))
            {
                // Skip the header row if present
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values.Length >= 3 &&
                        decimal.TryParse(values[1], NumberStyles.Currency, CultureInfo.InvariantCulture, out decimal price) &&
                        int.TryParse(values[2], out int quantity))
                    {
                        var product = new Product
                        {
                            ProductName = values[0],
                            Price = price,
                            Quantity = quantity
                        };
                        products.Add(product);
                    }
                    else
                    {
                        Console.WriteLine($"Invalid data in CSV: {line}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Throw custom exception
            throw new InvalidDataException($"Error reading CSV file: {ex.Message}");
        }

        // Check if valid products were found, if not, throw an exception
        if (products.Count == 0)
        {
            throw new InvalidDataException("No valid products found in the CSV file.");
        }

        return products;
    }
}
