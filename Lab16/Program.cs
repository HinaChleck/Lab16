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
        /*1.    Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.

        Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число),
        «Название товара» (строка), «Цена товара» (вещественное число).
        Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
        Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».*/
        static void Main(string[] args)
        {
            #region Задача 8
            /*{

            string path = @"Lab8_2.txt";
            if (File.Exists(path))   File.Delete(path);

            #region Создание и запись в файл массива случайных чисел
            string[] row=new string[10];
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                row[i] = Convert.ToString(random.Next(0, 10));
                using (StreamWriter sw = new StreamWriter(path, true)) 
                { 
                    sw.Write("{0} ",row[i]); 
                }                
            }
            #endregion
            string line;
            using (StreamReader sr=new StreamReader(path))            
            {
                line =sr.ReadLine();
            }

            line= line.Trim();
            string[] readrow = line.Split();

            int sum = 0;
            for (int i = 0; i < readrow.Length; i++)
            {
                int number=Convert.ToInt32(readrow[i]);
                sum+=number;
            }
            Console.WriteLine("Сумма чисел в файле = {0}",sum);
            Console.WriteLine("\n(Создан файл: {0})", Path.GetFullPath(path));
            Console.ReadKey();  
        }*/
            #endregion

            
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
                        sw.Write("\"Код товара\":\"{0}\",", code);
                    }
                    else
                    {
                        products[i].Code = 0;
                        sw.Write("{");
                        sw.Write("\"Код товара\":\"{0}\",", 0);
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
                        sw.Write("\"Цена товара\":\"{0}\"", products[i].Price);
                        sw.Write("}");
                    }
                    else
                    {
                        products[i].Price = price;
                        sw.Write("\"Цена товара\":\"{0}\"", 0);
                        sw.Write("}");
                        Console.WriteLine("Предупреждение: неверный формат введенных данных. Цена товара не записана");
                    }
                    
                }
            }
            /*for (int i = 0; i < products.Length; i++)
            {
                Console.WriteLine(products[i].Code);
                Console.WriteLine(products[i].Name);
                Console.WriteLine(products[i].Price); 
            }
            */
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
