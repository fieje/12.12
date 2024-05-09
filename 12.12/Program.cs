using System;
using System.Collections.Generic;
using System.Linq;

public class Price
{
    public string ProductName { get; set; }
    public string StoreName { get; set; }
    public double Cost { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Price> priceList = new List<Price>();

        AddData(priceList);

        priceList = SortByStoreName(priceList);

        Console.WriteLine("Enter the product name to search:");
        string productName = Console.ReadLine();
        DisplayProductInfo(priceList, productName);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void AddData(List<Price> priceList)
    {
        Console.WriteLine("Enter the number of prices to add:");
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Price price = new Price();
            Console.WriteLine("Enter product name:");
            price.ProductName = Console.ReadLine();

            Console.WriteLine("Enter store name:");
            price.StoreName = Console.ReadLine();

            Console.WriteLine("Enter product cost:");
            price.Cost = Convert.ToDouble(Console.ReadLine());

            priceList.Add(price);
        }
    }

    static List<Price> SortByStoreName(List<Price> priceList)
    {
        return priceList.OrderBy(x => x.StoreName).ToList();
    }

    static void DisplayProductInfo(List<Price> priceList, string productName)
    {
        bool found = false;
        foreach (var price in priceList)
        {
            if (price.ProductName == productName)
            {
                Console.WriteLine($"Product: {price.ProductName}, Store: {price.StoreName}, Cost: {price.Cost} UAH");
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("Product not found.");
        }
    }
}
