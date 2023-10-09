using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVRead_SortData;
// Class responsible for sorting products
class ProductSorter
{
    private List<Product> _products;

    // Constructor to initialize the ProductSorter with a list of products
    public ProductSorter(List<Product> products)
    {
        _products = products;
    }

    //Sorting methods based on different criteria using LINQ OrderBy method
    public List<Product> SortByPriceAscending()
    {
        return _products.OrderBy(p => p.Price).ToList();
    }

    public List<Product> SortByQuantityAscending()
    {
        return _products.OrderBy(p => p.Quantity).ToList();
    }

    public List<Product> SortByNameAscending()
    {
        return _products.OrderBy(p => p.ProductName).ToList();
    }

    public Dictionary<string, List<Product>> GroupByNameAndSort()
    {
        var groupedProducts = _products.GroupBy(p => p.ProductName)
                                       .ToDictionary(g => g.Key, g => g.OrderBy(p => p.Price).ToList());
        return groupedProducts;
    }
}