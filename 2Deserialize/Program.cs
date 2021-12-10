using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;




namespace Lab16

{
    internal class Program
    {
        static void Main(string[] args)

        /*2.    Необходимо разработать программу для получения информации о товаре из json-файла.
        Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.*/

        {
            string path = "C:\\Users\\v.baranova\\Documents\\Автоматизация BIM\\Labs\\Lab16\\Lab16\\bin\\Debug\\Products.json";
            if (!File.Exists(path)) Console.WriteLine("Файл не найден");
            else
            {
                string line;
                using (StreamReader sr = new StreamReader(path))
                {
                    line = sr.ReadToEnd();
                }

                string[] readProducts = line.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                Product[] products = new Product[5];

                for (int i = 0; i < products.Length; i++)
                {
                    products[i] = JsonSerializer.Deserialize<Product>(readProducts[i]);
                    Console.Write("#{0,10}", products[i].Code);
                    Console.Write(": {0,25} ", products[i].Name);
                    Console.Write("Цена: {0:f2}\n", products[i].Price);
                }

                decimal maxPrice = 0;
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Price > maxPrice)
                    {
                        maxPrice = products[i].Price;
                    }
                }

                Console.Write("\nСамые дорогие продукты: ");
                for (int i = 0; i < products.Length; i++)
                {
                    if (products[i].Price == maxPrice)
                    {
                        Console.Write("{0}, ", products[i].Name);
                    }
                }

            }
            Console.ReadKey();
        }


        public class Product
        {
            [JsonPropertyName("Код товара")]
            public uint Code { get; set; }
            [JsonPropertyName("Название товара")]
            public string Name { get; set; }
            [JsonPropertyName("Цена товара")]
            public decimal Price { get; set; }
        }
    }
}
