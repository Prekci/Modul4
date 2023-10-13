using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text;  
using System.Threading.Tasks;  
namespace Задание_5  
{
    // Интерфейс "Рисунок"
    public interface IDrawing  
    {
        // Метод для рисования линии
        void DrawLine(int x1, int y1, int x2, int y2);
        // Метод для рисования круга
        void DrawCircle(int centerX, int centerY, int radius);
        // Метод для рисования прямоугольника
        void DrawRectangle(int x, int y, int width, int height);
        // Метод для очистки холста
        void ClearCanvas();
    }
    // Класс для работы с холстом    
    public class Canvas : IDrawing  
    {
        // Приватное поле "canvas" для хранения данных о холсте
        private List<string> canvas;
        // Конструктор класса "Canvas" с параметрами "width" и "height"  
        public Canvas(int width, int height)  
        {
            // Инициализируем поле "canvas" новым списком строк
            canvas = new List<string>();  
            // Начинаем цикл по высоте холста
            for (int i = 0; i < height; i++)  
            {
                // Создаем строку, представляющую строку холста, заполненную пробелами
                string row = new string(' ', width);  
                // Добавляем эту строку в список "canvas" (представляющий холст)
                canvas.Add(row);  
            }
        }
        // Реализация метода интерфейса "DrawLine"
        public void DrawLine(int x1, int y1, int x2, int y2)  
        {
            // Проверка на нахождение координат вне холста
            if (x1 < 0 || x2 < 0 || y1 < 0 || y2 < 0 || x1 >= canvas[0].Length || x2 >= canvas[0].Length || y1 >= canvas.Count || y2 >= canvas.Count)
            {
                Console.WriteLine("Координаты линии находятся вне холста");  
                return;  
            }
            // Если x1 равно x2, значит рисуется вертикальная линия
            if (x1 == x2)  
            {
                // Рисуем вертикальную линию
                // Цикл по координатам y
                for (int y = Math.Min(y1, y2); y <= Math.Max(y1, y2); y++)  
                {
                    // Получаем массив символов для текущей строки
                    char[] row = canvas[y].ToCharArray();  
                    // Устанавливаем символ '-' в позиции x1
                    row[x1] = '-';  
                    // Обновляем строку в списке "canvas"
                    canvas[y] = new string(row);  
                }
            }
            // Если y1 равно y2, значит рисуется горизонтальная линия
            else if (y1 == y2)  
            {
                // Получаем массив символов для строки, в которой рисуется линия
                char[] row = canvas[y1].ToCharArray();  
                // Рисуем горизонтальную линию
                // Цикл по координатам x
                for (int x = Math.Min(x1, x2); x <= Math.Max(x1, x2); x++)  
                {
                    // Устанавливаем символ '-' в позиции x
                    row[x] = '-';  
                }
                // Обновляем строку в списке "canvas"
                canvas[y1] = new string(row);  
            }
            else
            {
                Console.WriteLine("Линии могут быть только горизонтальными или вертикальными");  
            }
        } 
        // Реализация метода интерфейса "DrawCircle"
        public void DrawCircle(int centerX, int centerY, int radius) 
        {
            // Проверка на нахождение координат вне холста
            if (centerX - radius < 0 || centerX + radius >= canvas[0].Length || centerY - radius < 0 || centerY + radius >= canvas.Count)
            {
                
                Console.WriteLine("Круг находится за пределами холста");  
                return;  
            }
            // Рисуем круг
            // Цикл по координатам y
            for (int y = centerY - radius; y <= centerY + radius; y++)  
            {
                // Цикл по координатам x
                for (int x = centerX - radius; x <= centerX + radius; x++)  
                {
                    // Используем формулу окружности для определения, принадлежит ли точка кругу
                    if ((x - centerX) * (x - centerX) + (y - centerY) * (y - centerY) <= radius * radius)
                    {
                        // Получаем массив символов для текущей строки
                        char[] row = canvas[y].ToCharArray();  
                        // Устанавливаем символ '█' в позиции x
                        row[x] = '█';  
                        // Обновляем строку в списке "canvas"
                        canvas[y] = new string(row);  
                    }
                }
            }
        }
        // Реализация метода интерфейса "DrawRectangle"
        public void DrawRectangle(int x, int y, int width, int height)  
        {
            // Проверка на нахождение координат вне холста
            if (x < 0 || y < 0 || x >= canvas[0].Length || y >= canvas.Count)
            {
                Console.WriteLine("Координаты прямоугольника находятся вне холста");  
                return;  
            }
            if (width <= 0 || height <= 0)
            {
                Console.WriteLine("Ширина и высота прямоугольника должны быть положительными числами"); 
                return;  
            }
            // Рисуем прямоугольник
            // Цикл по координатам y для рисования высоты прямоугольника
            for (int row = y; row < y + height; row++)  
            {
                if (row >= canvas.Count)
                    // Если строка вышла за пределы холста, завершаем цикл
                    break;  
                // Цикл по координатам x для рисования ширины прямоугольника
                for (int col = x; col < x + width; col++)  
                {
                    if (col >= canvas[0].Length)
                        // Если позиция вышла за пределы холста, завершаем цикл
                        break;  
                    // Получаем массив символов для текущей строки
                    char[] canvasRow = canvas[row].ToCharArray();  
                    // Устанавливаем символ '█' в текущей позиции
                    canvasRow[col] = '█';  
                    // Обновляем строку в списке "canvas"
                    canvas[row] = new string(canvasRow);  
                }
            }
        }
        // Реализация метода интерфейса "ClearCanvas"
        public void ClearCanvas()  
        {
            // Цикл по строкам холста
            for (int i = 0; i < canvas.Count; i++)  
            {
                // Получаем массив символов для текущей строки
                char[] row = canvas[i].ToCharArray();  
                // Цикл по символам строки
                for (int j = 0; j < row.Length; j++)  
                { 
                    // Очищаем холст, заменяя '-' на пробел
                    row[j] = ' '; 
                }
                // Обновляем строку в списке "canvas"
                canvas[i] = new string(row);  
            }
        }
        // Реализация метода для отображения содержимого холста
        public void Display()  
        {
            // Вывод содержимого холста в консоль
            // Перебираем строки холста
            foreach (var row in canvas)  
            {
                // Выводим строку в консоль
                Console.WriteLine(row);  
            }
        }
    }
    class Test
    {
        static void Main()  
        {

            Console.Write("Введите ширину холста: ");  
            if (!int.TryParse(Console.ReadLine(), out int canvasWidth) || canvasWidth <= 0)
            {
               
                Console.WriteLine("Введите корректную ширину холста");  
                Console.ReadLine();  
                return;  
            }
            Console.Write("Введите высоту холста: "); 
            if (!int.TryParse(Console.ReadLine(), out int canvasHeight) || canvasHeight <= 0)
            {
                Console.WriteLine("Введите корректную высоту холста"); 
                Console.ReadLine(); 
                return; 
            }
            // Создаем объект класса "Canvas" с указанными размерами
            Canvas canvas = new Canvas(canvasWidth, canvasHeight);  
            // Запускаем бесконечный цикл для взаимодействия с пользователем
            while (true)  
            {
                // Выводим меню выбора действий
                Console.WriteLine("Выберите действие:");  
                Console.WriteLine("1. Нарисовать линию");
                Console.WriteLine("2. Нарисовать круг");
                Console.WriteLine("3. Нарисовать прямоугольник");
                Console.WriteLine("4. Вывести холст");
                Console.WriteLine("5. Очистить холст");
                // Считываем выбор пользователя
                if (!int.TryParse(Console.ReadLine(), out int choice))  
                {
                    Console.WriteLine("Введите корректный выбор"); 
                    continue;  
                }
                switch (choice)  // Обрабатываем выбор пользователя
                {
                    case 1:  
                        Console.Write("Введите координаты начала линии (x1): ");
                        if (!int.TryParse(Console.ReadLine(), out int x1) || x1 <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        Console.Write("Введите координаты начала линии (y1): ");
                        if (!int.TryParse(Console.ReadLine(), out int y1) || y1 <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        Console.Write("Введите координаты конца линии (x2): ");
                        if (!int.TryParse(Console.ReadLine(), out int x2) || x2 <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        Console.Write("Введите координаты конца линии (y2): ");
                        if (!int.TryParse(Console.ReadLine(), out int y2) || y2 <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        // Вызываем метод для рисования линии на холсте
                        canvas.DrawLine(x1, y1, x2, y2);  
                        break;
                    case 2:  
                        Console.Write("Введите координаты центра круга (x): ");
                        if (!int.TryParse(Console.ReadLine(), out int centerX) || centerX <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        Console.Write("Введите координаты центра круга (y): ");
                        if (!int.TryParse(Console.ReadLine(), out int centerY) || centerY <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        Console.Write("Введите радиус круга: ");
                        if (!int.TryParse(Console.ReadLine(), out int radius) || radius <= 0)
                        {
                            Console.WriteLine("Введите корректный радиус");
                            continue;
                        }
                        // Вызываем метод для рисования круга на холсте
                        canvas.DrawCircle(centerX, centerY, radius);  
                        break;
                    case 3:  
                        Console.Write("Введите координаты верхнего левого угла прямоугольника (x y): ");
                        if (!int.TryParse(Console.ReadLine(), out int x) || !int.TryParse(Console.ReadLine(), out int y) || x <= 0 || y <= 0)
                        {
                            Console.WriteLine("Введите корректные координаты");
                            continue;
                        }
                        Console.Write("Введите ширину прямоугольника: ");
                        if (!int.TryParse(Console.ReadLine(), out int width) || width <= 0)
                        {
                            Console.WriteLine("Введите корректную ширину");
                            continue;
                        }
                        Console.Write("Введите высоту прямоугольника: ");
                        if (!int.TryParse(Console.ReadLine(), out int height) || height <= 0)
                        {
                            Console.WriteLine("Введите корректную высоту");
                            continue;
                        }
                        // Вызываем метод для рисования прямоугольника на холсте
                        canvas.DrawRectangle(x, y, width, height);  
                        break;
                    case 4: 
                        Console.WriteLine("Содержимое холста:"); 
                        // Вызываем метод для отображения содержимого холста
                        canvas.Display(); 
                        break;
                    case 5:  
                        // Вызываем метод для очистки холста
                        canvas.ClearCanvas();  
                        break;
                    default: 
                        Console.WriteLine("Выберите корректное действие");
                        break;
                }
            }
        }
    }
}