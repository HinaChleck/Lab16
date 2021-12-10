using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;

namespace Serialize
{
    internal class Program
    {
        /*1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

        Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число),
        «Название товара» (строка), «Цена товара» (вещественное число).
        Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
        Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/
        static void Main(string[] args)
        {
            Product[] products = new Product[5];
            string path = "C:\\Users\\v.baranova\\Documents\\Автоматизация BIM\\Labs\\Lab16\\Lab16\\bin\\Debug\\Products.json";
            if (File.Exists(path)) File.Delete(path);
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                for (int i = 0; i < products.Length; i++)
                {
                    products[i] = new Product();
                    uint code;
                    Console.Write("Введите код товара №{0}: ", i + 1);
                    string codeS = Console.ReadLine();
                    if (UInt32.TryParse(codeS, out code))
                    {
                        products[i].Code = code;
                        sw.Write("{");
                        sw.Write("\"Код товара\":{0},", code);
                    }
                    else
                    {
                        products[i].Code = 0;
                        sw.Write("{");
                        sw.Write("\"Код товара\":{0},", 0);
                        Console.WriteLine("Предупреждение: неверный формат введенных данных. Код товара не записан");
                    }

                    Console.Write("Введите наименование товара №{0}: ", i + 1);
                    products[i].Name = Console.ReadLine();
                    sw.Write("\"Название товара\":\"{0}\",", products[i].Name);

                    decimal price;
                    Console.Write("Введите цену товара № {0}: ", i + 1);
                    string priceS = Console.ReadLine();
                    if (Decimal.TryParse(priceS, out price))
                    {

                        products[i].Price = price;
                        sw.Write("\"Цена товара\":{0}", products[i].Price);
                        sw.Write("}\n");
                    }
                    else
                    {
                        products[i].Price = price;
                        sw.Write("\"Цена товара\":{0}", 0);
                        sw.Write("}\n");
                        Console.WriteLine("Предупреждение: неверный формат введенных данных. Цена товара не записана");
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
