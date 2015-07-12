namespace Orders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using Orders.Models;

    internal class OrdersMain
    {
        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var data = new DataMapper();
            var allCategories = data.GetAllCategories();
            var allProducts = data.GetAllProducts();
            var allOrders = data.GetAllOrders();

            PrintNamesOfTheFiveMostExpensiveProducts(allProducts);

            Console.WriteLine(new string('-', 10));

            PrintNumberOfProductsInEachCategory(allProducts, allCategories);

            Console.WriteLine(new string('-', 10));

            PrintFiveTopProducts(allOrders, allProducts);

            Console.WriteLine(new string('-', 10));

            PrintMostProfitableCategory(allOrders, allProducts, allCategories);
        }

        private static void PrintMostProfitableCategory(
            IEnumerable<Order> allOrders, 
            IEnumerable<Product> allProducts, 
            IEnumerable<Category> allCategories)
        {
            // The most profitable category
            var category =
                allOrders.GroupBy(o => o.ProductId)
                    .Select(
                        ordersGroup =>
                        new
                            {
                                ProductOrderedId = allProducts.First(p => p.Id == ordersGroup.Key).CategoryId, 
                                PriceOrdered = allProducts.First(p => p.Id == ordersGroup.Key).UnitPrice, 
                                Quantities = ordersGroup.Sum(productsOrdered => productsOrdered.Quantity)
                            })
                    .GroupBy(product => product.ProductOrderedId)
                    .Select(
                        productGroup =>
                        new
                            {
                                CategoryName = allCategories.First(c => c.Id == productGroup.Key).Name, 
                                TotalQuantity = productGroup.Sum(order => order.Quantities * order.PriceOrdered)
                            })
                    .OrderByDescending(c => c.TotalQuantity)
                    .First();
            Console.WriteLine("{0}: {1}", category.CategoryName, category.TotalQuantity);
        }

        private static void PrintFiveTopProducts(IEnumerable<Order> allOrders, IEnumerable<Product> allProducts)
        {
            // The 5 top products (by order quantity)
            var result =
                allOrders.GroupBy(o => o.ProductId)
                    .Select(
                        ordersGroup =>
                        new
                            {
                                Product = allProducts.First(p => p.Id == ordersGroup.Key).Name, 
                                Quantities = ordersGroup.Sum(productsOrdered => productsOrdered.Quantity)
                            })
                    .OrderByDescending(prductOrdered => prductOrdered.Quantities)
                    .Take(5);
            foreach (var item in result)
            {
                Console.WriteLine("{0}: {1}", item.Product, item.Quantities);
            }
        }

        private static void PrintNumberOfProductsInEachCategory(
            IEnumerable<Product> allProducts, 
            IEnumerable<Category> allCategories)
        {
            // Number of products in each category
            var result =
                allProducts.GroupBy(p => p.CategoryId)
                    .Select(
                        group =>
                        new
                            {
                                Category = allCategories.First(c => c.Id == group.Key).Name, 
                                Count = group.Count()
                            })
                    .ToList();
            foreach (var item in result)
            {
                Console.WriteLine("{0}: {1}", item.Category, item.Count);
            }
        }

        private static void PrintNamesOfTheFiveMostExpensiveProducts(IEnumerable<Product> allProducts)
        {
            // Names of the 5 most expensive products
            var result = allProducts.OrderByDescending(p => p.UnitPrice).Take(5).Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}