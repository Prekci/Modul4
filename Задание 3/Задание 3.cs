using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Задание_3
{
    // Интерфейс "Студент"
    public interface IStudent
    {
        // Имя студента
        string Name { get; set; }
        // Курс, на котором учится студент
        string Course { get; set; }
        // Метод для определения среднего балла студента
        double CalculateAverageGrade();
        // Метод для получения информации о курсе студента
        string GetCourseInfo();
    }
    // Класс для студента
    public class Student : IStudent
    {
        public string Name { get; set; }
        public string Course { get; set; }
        public List<double> Grades { get; set; }
        // Конструктор класса Student
        public Student()
        {
            // Запрос имени студента
            Console.Write("Введите имя студента (на русском языке): ");
            Name = Console.ReadLine();
            // Проверка, что имя состоит только из русских букв
            while (!IsRussianName(Name))
            {
                Console.Write("Некорректное имя. Введите имя студента на русском языке: ");
                Name = Console.ReadLine();
            }
            // Запрос курса студента
            Console.Write("Введите курс студента (от 1 до 4): ");
            Course = Console.ReadLine();
            int course;
            // Проверка корректности ввода курса
            while (!int.TryParse(Course, out course) || course < 1 || course > 4)
            {
                Console.Write("Некорректный ввод. Введите курс студента (от 1 до 4): ");
                Course = Console.ReadLine();
            }
            // Инициализация списка оценок студента
            Grades = new List<double>();
            int maxGrades = 10;
            int currentGrade = 1;
            // Запрос оценок
            while (currentGrade <= maxGrades)
            {
                Console.Write($"Введите оценку {currentGrade} (или введите 'выйти' для завершения): ");
                string input = Console.ReadLine();
                // Проверка на завершение ввода
                if (input.ToLower() == "выйти")
                    break;
                if (double.TryParse(input, out double grade) && grade >= 1 && grade <= 10)
                {
                    Grades.Add(grade);
                    currentGrade++;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Оценка должна быть от 1 до 10.");
                }
            }
        }
        // Метод для вычисления средней оценки студента
        public double CalculateAverageGrade()
        {
            if (Grades.Count == 0)
                return 0;
            double sum = Grades.Sum();
            double averageGrade = sum / Grades.Count;
            // Округление до двух знаков после запятой
            return Math.Round(averageGrade, 2);
        }
        // Метод для получения информации о студенте и его курсе
        public string GetCourseInfo()
        {
            return $"Студент {Name}, курс {Course}";
        }
        // Метод для проверки, что имя состоит только из русских букв
        private bool IsRussianName(string name)
        {
            return Regex.IsMatch(name, @"^[А-Яа-я]+$");
        }
    }
    // Пример использования
    class Program
    {
        static void Main(string[] args)
        {
            List<IStudent> students = new List<IStudent>();
            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Вывести информацию о студентах");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Введите информацию о студенте:");
                        IStudent student = new Student();
                        students.Add(student);
                        break;
                    case "2":
                        Console.WriteLine("Информация о студентах:");
                        foreach (var s in students)
                        {
                            Console.WriteLine(s.GetCourseInfo());
                            Console.WriteLine($"Средний балл: {s.CalculateAverageGrade()}");
                            Console.WriteLine();
                        }
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор\n");
                        break;
                }
            }
        }
    }
}