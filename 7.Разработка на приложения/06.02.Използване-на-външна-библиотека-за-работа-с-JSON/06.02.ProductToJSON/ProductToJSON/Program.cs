using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductToJSON
{
    class Program
    {
        private class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
            public DateTime Expiry { get; set; }
        }
        static void Main(string[] args)
        {
            Product product = new Product();
            product.Id = 1;
            product.Name = "test";
            product.Price = 200.95M;
            product.Stock = 101;
            product.Expiry = new DateTime(2020, 6, 30);

            string json = JsonConvert.SerializeObject(product);
            
            Console.WriteLine(formatJson(json));

            Product newProduct = JsonConvert.DeserializeObject<Product>(formatJson(json));
            Console.WriteLine();
            Console.WriteLine(formatJson(JsonConvert.SerializeObject(newProduct)));
        }

        static private string formatJson(string json)
        {
            string jsonFormated = json.Replace(",", ",\n")
                                  .Replace(":", ": ")
                                  .Replace("{", "{\n")
                                  .Replace("}", "\n}");
            return jsonFormated;
        }
    }
}
