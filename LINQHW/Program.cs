using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQHometask
{
    class Program
    {
        static void Main(string[] args)
        {
/*            var firstProduct = new Product
            {
                Category = "Smartphones",
                Name = "Samsung A50",
                Price = 85000,
                Quantity = 30,
                Rating = 8
            };

            var secondProduct = new Product
            {
                Category = "Smartphones",
                Name = "Iphone 10",
                Price = 250000,
                Quantity = 4,
                Rating = 9
            };

            var thirdProduct = new Product
            {
                Category = "Smartphones",
                Name = "Xiaomi MI9Lite",
                Price = 150000,
                Quantity = 12,
                Rating = 7
            };*/

            using (var context = new ShopContext())
            {
              /*  context.AddRange(firstProduct, secondProduct, thirdProduct);
                context.SaveChanges();*/

            Console.WriteLine("Choose type of sort:\n1 - By Price, \n2 - By Quantity, \n3 - By Rating, \n4 - By Name, \n5 - By Category ");
            var sort = int.Parse(Console.ReadLine());
            List<Product> sortedProducts = new List<Product>();
            switch (sort)
            {
                case 1:
                        sortedProducts = context.Products.OrderBy(products => products.Price).ToList();
                    break;
                case 2:
                        sortedProducts = context.Products.OrderBy(products => products.Quantity).ToList();
                        break;
                case 3:
                        sortedProducts = context.Products.OrderBy(products => products.Rating).ToList();
                        break;
                case 4:
                        sortedProducts = context.Products.OrderBy(products => products.Name).ToList();
                        break;
                case 5:
                        sortedProducts = context.Products.OrderBy(products => products.Category).ToList();
                        break;
            }
                int perPage = 10;
                int currentPage = 1;
                int countProduct = sortedProducts.Count();

                while (true)
                {
                    var productList = sortedProducts.Where(product => product.Category == "Smartphones")
                    .Skip((currentPage - 1) * perPage)
                    .Take(perPage)
                    .ToList();
                    Console.Clear();
                    Console.WriteLine("Список товаров: ");
                    foreach (var product in productList)
                    {
                        Console.WriteLine($"{product.Name} - Артикул: {product.Id}");
                    }
                    Console.WriteLine("\n<= пред. страница\t след.страница =>");
                    Console.WriteLine("Купить - ENTER");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.RightArrow:
                            if (countProduct / perPage >= currentPage)
                            {
                                currentPage++;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (currentPage > 1)
                            {
                                currentPage--;
                            }
                            break;
                        case ConsoleKey.Enter:
                            return;
                    }
                }
            }
        }
    }
}
