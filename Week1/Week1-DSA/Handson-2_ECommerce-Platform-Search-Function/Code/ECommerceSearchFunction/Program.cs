using System;
using System.Collections.Generic;

namespace ECommerceSearch
{
    class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int id, string name, string category)
        {
            ProductId = id;
            ProductName = name;
            Category = category;
        }

        public int CompareTo(Product other)
        {
            return ProductId.CompareTo(other.ProductId);
        }

        public override string ToString()
        {
            return $"ID: {ProductId}, Name: {ProductName}, Category: {Category}";
        }
    }

    class Program
    {
        // Linear Search - O(n)
        static Product LinearSearch(Product[] products, int targetId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == targetId)
                    return product;
            }
            return null;
        }

        // Binary Search - O(log n)
        static Product BinarySearch(Product[] sortedProducts, int targetId)
        {
            int left = 0, right = sortedProducts.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedProducts[mid].ProductId == targetId)
                    return sortedProducts[mid];
                else if (sortedProducts[mid].ProductId < targetId)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }

        static void Main(string[] args)
        {
            // Step 2: Setup product list
            Product[] products = {
                new Product(101, "Mouse", "Electronics"),
                new Product(205, "Keyboard", "Electronics"),
                new Product(150, "Notebook", "Stationery"),
                new Product(310, "Backpack", "Accessories"),
                new Product(275, "Monitor", "Electronics")
            };

            // Copy and sort products for binary search
            Product[] sortedProducts = (Product[])products.Clone();
            Array.Sort(sortedProducts);

            int targetId = 150;

            // Linear Search
            Console.WriteLine("Linear Search Result:");
            Product result1 = LinearSearch(products, targetId);
            Console.WriteLine(result1 != null ? result1.ToString() : "Product not found");

            // Binary Search
            Console.WriteLine("\nBinary Search Result:");
            Product result2 = BinarySearch(sortedProducts, targetId);
            Console.WriteLine(result2 != null ? result2.ToString() : "Product not found");

            // Step 4: Analysis
            Console.WriteLine("\n--- Analysis ---");
            Console.WriteLine("Linear Search Time Complexity: O(n)");
            Console.WriteLine("Binary Search Time Complexity: O(log n)");
            Console.WriteLine("Binary Search is more efficient for large, sorted datasets.");
            Console.WriteLine("Linear Search is suitable for unsorted data or small arrays.");
        }
    }
}
