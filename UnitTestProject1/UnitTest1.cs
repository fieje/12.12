using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAddData()
        {
            List<Price> priceList = new List<Price>();

            AddData(priceList);

            Assert.AreEqual(2, priceList.Count); 
        }

        [TestMethod]
        public void TestSortByStoreName()
        {
            List<Price> priceList = new List<Price>
            {
                new Price { ProductName = "Product1", StoreName = "StoreB", Cost = 10.99 },
                new Price { ProductName = "Product2", StoreName = "StoreA", Cost = 20.99 }
            };

            priceList = SortByStoreName(priceList);

            Assert.AreEqual("StoreA", priceList[0].StoreName);
            Assert.AreEqual("StoreB", priceList[1].StoreName);
        }

        [TestMethod]
        public void TestDisplayProductInfo_ProductNotFound()
        {
            List<Price> priceList = new List<Price>
            {
                new Price { ProductName = "Product1", StoreName = "StoreA", Cost = 10.99 },
                new Price { ProductName = "Product2", StoreName = "StoreB", Cost = 20.99 }
            };
            string productName = "Product3";

            var consoleOutput = GetConsoleOutput(() => DisplayProductInfo(priceList, productName));

            Assert.IsTrue(consoleOutput.Contains("Product not found."));
        }

        private string GetConsoleOutput(Action action)
        {
            using (StringWriter consoleOutputWriter = new StringWriter())
            {
                Console.SetOut(consoleOutputWriter);
                action.Invoke();
                return consoleOutputWriter.ToString();
            }
        }

        private void AddData(List<Price> priceList)
        {
            Console.WriteLine("Adding test data...");
            priceList.Add(new Price { ProductName = "Product1", StoreName = "StoreA", Cost = 10.99 });
            priceList.Add(new Price { ProductName = "Product2", StoreName = "StoreB", Cost = 20.99 });
        }

        private List<Price> SortByStoreName(List<Price> priceList)
        {
            Console.WriteLine("Sorting by store name...");
            return priceList.OrderBy(x => x.StoreName).ToList();
        }

        private void DisplayProductInfo(List<Price> priceList, string productName)
        {
            Console.WriteLine($"Searching for product: {productName}...");
            var product = priceList.FirstOrDefault(p => p.ProductName == productName);
            if (product != null)
            {
                Console.WriteLine($"Product: {product.ProductName}, Store: {product.StoreName}, Cost: {product.Cost}");
            }
            else
            {
                Console.WriteLine("Product not found.");
            }
        }
    }
}
