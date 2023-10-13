using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Задание_4
{
    // Интерфейс "Книга"
    public interface IBook
    {
        // Метод для проверки доступности книги
        bool IsAvailable();
        // Метод для выдачи книги
        void BorrowBook();
    }
    // Класс для хранения информации о книге
    public class Book
    {
        public string Title { get; set; }
        public Book(string title)
        {
            Title = title;
        }
        // Переопределение метода ToString для возвращения названия книги в виде строки
        public override string ToString()
        {
            return Title;
        }
    }
    // Класс для реализации интерфейса "Книга" для бумажных книг
    public class PhysicalBook : IBook
    {
        private bool isBorrowed;
        public Book BookInfo { get; set; }
        public PhysicalBook(Book book)
        {
            BookInfo = book;
            isBorrowed = false;
        }
        // Реализация метода проверки доступности книги
        public bool IsAvailable()
        {
            // Возвращает true, если книга доступна, иначе false
            return !isBorrowed; 
        }
        // Реализация метода выдачи книги
        public void BorrowBook()
        {
            if (isBorrowed)
            {
                Console.WriteLine($"{BookInfo.Title} уже выдана.\n");
            }
            else
            {
                isBorrowed = true;
                Console.WriteLine($"Выдаем книгу: {BookInfo.Title}\n");
            }
        }
        // Переопределение метода ToString для возвращения названия книги в виде строки
        public override string ToString()
        {
            return BookInfo.Title;
        }
    }
    // Класс для реализации интерфейса "Книга" для электронных книг
    public class EBook : IBook
    {
        public Book BookInfo { get; set; }
        public EBook(Book book)
        {
            BookInfo = book;
        }
        // Реализация метода проверки доступности книги
        public bool IsAvailable()
        {
            // Всегда возвращает true, так как электронная книга не может быть выдана
            return true; 
        }
        // Реализация метода выдачи книги (загрузки и чтения электронной книги)
        public void BorrowBook()
        {
            Console.WriteLine($"Загружаем и читаем книгу: {BookInfo.Title}\n");
        }
        // Переопределение метода ToString для возвращения названия книги в виде строки
        public override string ToString()
        {
            return BookInfo.Title;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IBook> books = new List<IBook>();
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Проверить доступность и выдать книгу");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddBook(books);
                        break;
                    case "2":
                        CheckAndBorrowBook(books);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор. Попробуйте снова.\n");
                        break;
                }
            }
        }
        static void AddBook(List<IBook> books)
        {
            Console.WriteLine("Введите название книги на русском:");
            string title = Console.ReadLine();
            if (!IsRussianTitle(title))
            {
                Console.WriteLine("Название книги должно быть на русском языке.\n");
                return;
            }
            Book book = new Book(title);
            Console.WriteLine("Выберите тип книги:");
            Console.WriteLine("1. Бумажная книга");
            Console.WriteLine("2. Электронная книга");
            string bookTypeChoice = Console.ReadLine();
            IBook newBook;
            switch (bookTypeChoice)
            {
                case "1":
                    newBook = new PhysicalBook(book);
                    break;
                case "2":
                    newBook = new EBook(book);
                    break;
                default:
                    Console.WriteLine("Некорректный выбор типа книги.\n");
                    return;
            }
            books.Add(newBook);
            Console.WriteLine($"Книга \"{book.Title}\" добавлена.\n");
        }
        static void CheckAndBorrowBook(List<IBook> books)
        {
            Console.WriteLine("Выберите книгу для проверки доступности и выдачи:");
            for (int i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {books[i]}");
            }
            if (books.Count == 0)
            {
                Console.WriteLine("Нет доступных книг.\n");
                return;
            }
            int bookChoice;
            if (!int.TryParse(Console.ReadLine(), out bookChoice) || bookChoice < 1 || bookChoice > books.Count)
            {
                Console.WriteLine("Некорректный выбор книги.\n");
                return;
            }
            IBook selectedBook = books[bookChoice - 1];
            Console.WriteLine($"Выбрана книга: {selectedBook}");
            if (selectedBook.IsAvailable())
            {
                selectedBook.BorrowBook();
            }
            else
            {
                Console.WriteLine("Эта книга уже выдана.\n");
            }
        }
        // Метод для проверки, что название книги находится на русском языке
        static bool IsRussianTitle(string title)
        {
            return Regex.IsMatch(title, @"^[А-Яа-я ]+$");
        }
    }
}
