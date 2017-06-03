namespace ProductsShop.ConsoleAplication
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    using Data;
    using Newtonsoft.Json;
    using ProductShop.Models;

    public class Startup
    {
        public static void Main()
        {
            var context = new ProductsShopContext();

            LoadJsonObjects(context);
            GetAllProducts(context);

            context.SaveChanges();
        }

        private static void GetAllProducts(ProductsShopContext context)
        {
            var products = context.Products
                .Where(pr => pr.Price > 500.00m && pr.Price < 550.00m && pr.Buyer == null)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                });

            ExportToJson(products, "usersAndProducts.json");
        }

        private static void ExportToJson<TEntity>(TEntity entity, string path)
        {
            string jsonProducts = JsonConvert.SerializeObject(entity, Formatting.Indented);
            File.WriteAllText(path, jsonProducts);
        }

        private static void LoadJsonObjects(ProductsShopContext context)
        {
            LoadJsonUsers(context);
            LoadJsonProducts(context);
            LoadJsonCategories(context);
        }

        private static void LoadJsonCategories(ProductsShopContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            using (StreamReader readAll = new StreamReader("categories.json"))
            {
                string json = readAll.ReadToEnd();
                IEnumerable<Category> categories =
                    JsonConvert.DeserializeObject<IEnumerable<Category>>(json);
                int countOfProducts = context.Products.Count();
                Random rnd = new Random();

                foreach (Category category in categories)
                {
                    for (int i = 0; i < countOfProducts / 3; i++)
                    {
                        Product product = context.Products.Find(rnd.Next(1, countOfProducts + 1));
                        category.Products.Add(product);
                    }
                }

                context.Categories.AddRange(categories);
            }
        }

        private static void LoadJsonProducts(ProductsShopContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            using (StreamReader readAll = new StreamReader("products.json"))
            {
                string json = readAll.ReadToEnd();
                IEnumerable<Product> products =
                    JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

                Random rnd = new Random();
                foreach (Product product in products)
                {
                    double shouldHaveBuyer = rnd.NextDouble();
                    product.SelledId = rnd.Next(1, context.Users.Count() + 1);
                    if (shouldHaveBuyer <= 0.7)
                    {
                        product.BuyerId = rnd.Next(1, context.Users.Count() + 1);
                    }
                }

                context.Products.AddRange(products);
            }
        }

        static void LoadJsonUsers(ProductsShopContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            using (StreamReader readAll = new StreamReader("users.json"))
            {
                string json = readAll.ReadToEnd();
                IEnumerable<User> items = JsonConvert.DeserializeObject<IEnumerable<User>>(json);

                context.Users.AddRange(items);
            }
        }
    }
}
