using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Задание_1;

namespace Задание_1
{
    // Интерфейс Shape 
    interface Shape
    {
        // Метод для вычисления площади фигуры
        double Area();
        // Метод для вычисления периметра фигуры
        double Perimeter();
    }
    // Производный класс Circle
    public class Circle : Shape
    {
        // Объявление переменной для хранения радиуса
        private double radius;
        // Конструктор класса, принимающий радиус круга
        public Circle(double radius)
        {
            // Инициализация поля radius значением, переданным в конструктор
            this.radius = radius;
        }
        // Реализация метода Draw()
        public double Area()
        {
            // Формула площади круга
            return Math.PI * Math.Pow(radius, 2);
        }
        public double Perimeter()
        {
            // Вывод информации о рисуемом круге
            return 2 * Math.PI * radius;
        }
    }
    // Производный класс Rectangle
    public class Rectangle : Shape
    {
        // Объявление переменных для хранения высоты и ширины
        private double width;
        private double height;
        // Конструктор класса, принимающий размеры прямоугольника
        public Rectangle(double width, double height)
        {
            // Инициализация полей width и height значением, переданным в конструктор
            this.width = width;
            this.height = height;
        }
        public double Area()
        {
            return width * height; // Формула площади прямоугольника
        }
        public double Perimeter()
        {
            return 2 * (width + height); // Формула периметра прямоугольника.
        }
    }
    // Производный класс Triangle
    public class Triangle : Shape
    {
        // Объявление переменных для хранения трех сторон
        private double side1;
        private double side2;
        private double side3;
        // Конструктор класса, принимающий размеры треугольника
        public Triangle(double side1, double side2, double side3)
        {
            // Инициализация полей 3-х сторон значением, переданным в конструктор
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        // Реализация метода Draw() для треугольника
        public double Area()
        {
            // Полупериметр треугольника
            double s = (side1 + side2 + side3) / 2;
            // Формула для вычисления площади треугольника
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }
        public double Perimeter()
        {
            // Периметр треугольника
            return (side1 + side2 + side3);
        }
    }
    // Объявление класса Test
    class Test
    {
        // Объявление метода Main
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Выберите фигуру: ");
                Console.WriteLine("1. Круг");
                Console.WriteLine("2. Прямоугольник");
                Console.WriteLine("3. Треугольник");
                // Считываем выбор пользователя
                string choice_ = Console.ReadLine();
                // Считываем ввод пользователя и преобразовываем его в целое число
                if (!int.TryParse(choice_, out int choice))
                {
                    // Вывод сообщения об ошибке при некорректном вводе
                    Console.WriteLine("Введите корректное число");
                    // Продолжение цикла
                    continue;
                }
                switch (choice)
                {
                    case 1:
                        Console.Write("Введите радиус круга: ");
                        double radiusCircle;
                        while ((!double.TryParse(Console.ReadLine(), out radiusCircle)) || (radiusCircle < 0))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.Write("Введите радиус круга: ");
                            continue;
                        }
                        // Создаем объект класса "Круг"
                        Circle circleArea = new Circle(radiusCircle);
                        Circle circlePerimeter = new Circle(radiusCircle);
                        // Выводим площадь круга с точностью до двух знаков после запятой
                        Console.WriteLine($"Площадь круга: {circleArea.Area():F2}");
                        Console.WriteLine($"Периметр круга: {circlePerimeter.Perimeter():F2}");
                        Console.Write("Нажмите Enter для продолжения...");
                        break;
                    case 2:
                        Console.Write("Введите ширину прямоугольника: ");
                        double widthRectangle;
                        while ((!double.TryParse(Console.ReadLine(), out widthRectangle) || (widthRectangle < 0)))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.Write("Введите ширину прямоугольника: ");
                        }
                        Console.Write("Введите высоту прямоугольника: ");
                        double heightRectangle;
                        while ((!double.TryParse(Console.ReadLine(), out heightRectangle)) || (heightRectangle < 0))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.Write("Введите высоту прямоугольника: ");
                        }
                        // Создаем объект класса "Прямоугольник"
                        Rectangle rectangleArea = new Rectangle(widthRectangle, heightRectangle);
                        Rectangle rectanglePerimeter = new Rectangle(widthRectangle, heightRectangle);
                        // Выводим площадь прямоугольника с точностью до двух знаков после запятой
                        Console.WriteLine($"Площадь прямоугольника: {rectangleArea.Area():F2}");
                        Console.WriteLine($"Периметр прямоугольника: {rectanglePerimeter.Perimeter():F2}");
                        Console.Write("Нажмите Enter для продолжения...");
                        break;
                    case 3:
                        Console.Write("Введите длину стороны a: ");
                        double sideA;
                        while ((!double.TryParse(Console.ReadLine(), out sideA)) || (sideA < 0))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.Write("Введите длину стороны a: ");
                        }
                        Console.Write("Введите длину стороны b: ");
                        double sideB;
                        while ((!double.TryParse(Console.ReadLine(), out sideB)) || (sideB < 0))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.Write("Введите длину стороны b: ");
                        }
                        Console.Write("Введите длину стороны c: ");
                        double sideC;
                        while ((!double.TryParse(Console.ReadLine(), out sideC)) || (sideC < 0))
                        {
                            Console.WriteLine("Некорректный ввод");
                            Console.Write("Введите длину стороны c: ");
                        }
                        if ((sideA + sideB) > sideC && (sideA + sideC) > sideB && (sideB + sideC) > sideA)
                        {
                            // Создаем объект класса "Треугольник"
                            Triangle triangleArea = new Triangle(sideA, sideB, sideC);
                            Console.WriteLine($"Площадь треугольника: {triangleArea.Area():F2}");
                        }
                        else
                        {
                            Console.WriteLine("Сумма двух сторон треугольника меньше либо равна третьей. Введите другие параметры сторон. ");
                        }
                        Triangle trianglePerimetr = new Triangle(sideA, sideB, sideC);
                        // Выводим площадь треугольника с точностью до двух знаков после запятой
                        Console.WriteLine($"Периметр треугольника: {trianglePerimetr.Perimeter():F2}");
                        Console.Write("Нажмите Enter для продолжения...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        Console.Write("Нажмите Enter для продолжения...\n");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
