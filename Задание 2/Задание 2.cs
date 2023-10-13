using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace Задание_2
{
    // Интерфейс "Товар"
    public interface IProduct
    {
        // Название товара
        string Name { get; set; } 
        // Стоимость товара
        double Price { get; set; } 
        // Количество товара на складе
        double ProductRemaining { get; set; } 
        // Метод для определения стоимости товара на складе
        double CalculateTotalValue(); 
    }
    // Класс для товара
    public class Product : IProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public double ProductRemaining { get; set; }
        public Product(string name, double price, double productRemaining)
        {
            Name = name;
            Price = price;
            ProductRemaining = productRemaining;
        }
        public double CalculateTotalValue()
        {
            return Price * ProductRemaining;
        }
        public void UpdateStock(int remaining)
        {
            ProductRemaining += remaining;
        }
    }
    // Пример использования
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите информацию о товаре:");
            // Запрашиваем у пользователя параметры товара
            Console.Write("Название товара: ");
            string name = Console.ReadLine();
            if (!IsValidRussianName(name))
            {
                Console.WriteLine("Название товара должно состоять только из русских букв");
                Console.ReadLine();
                return;
            }
            Console.Write("Цена: ");
            // Проверка ввода стоимости (должны быть только цифры)
            if ((!double.TryParse(Console.ReadLine(), out double price)) || (price < 0))
            {
                Console.WriteLine("Цена должен быть неотрицательным целым числом");
                Console.ReadLine();
                return;
            }
            Console.Write("Количество на складе: ");
            // Проверка ввода количества товара (должны быть только цифры)
            if ((!double.TryParse(Console.ReadLine(), out double Reamaining)) || (Reamaining < 0))
            {
                Console.WriteLine("Количество товара должно быть неотрицательным целым числом");
                Console.ReadLine();
                return;
            }
            // Создаем экземпляр товара
            IProduct product = new Product(name, price, Reamaining);
            // Выводим информацию о товаре
            Console.WriteLine($"\nНазвание: {product.Name}");
            Console.WriteLine($"Цена: {product.Price}");
            Console.WriteLine($"Количество на складе: {product.ProductRemaining}");
            Console.WriteLine($"Общая стоимость: {product.CalculateTotalValue()}");
            Console.ReadLine();
        }
        // Метод для проверки, что строка состоит только из русских букв
        static bool IsValidRussianName(string name)
        {
            return Regex.IsMatch(name, @"^[А-Яа-я ]+$", RegexOptions.IgnoreCase);
        }
    }
}