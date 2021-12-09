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
        {
            Product[] products = new Product[5];
            string path = "C:\\Users\\v.baranova\\Documents\\Автоматизация BIM\\Labs\\Lab16\\Lab16\\bin\\Debug\\Products.json";
            if (!File.Exists(path)) Console.WriteLine("Файл не найден");
            else

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
