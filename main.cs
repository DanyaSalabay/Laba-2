using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Выберите задачу:");
        Console.WriteLine("1 - Имена");
        Console.WriteLine("2 - Человек с именем и ростом");
        Console.WriteLine("3 - Человек с родителем");
        Console.WriteLine("4 - Создание ломаной");
        Console.WriteLine("5 - Длина ломаной");
        Console.Write("Введите номер задачи: ");
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            RunTaskOne();
        }
        else if (choice == "2")
        {
            RunTaskTwo();
        }
        else if (choice == "3")
        {
            RunTaskThree();
        }
        else if (choice == "4")
        {
            RunTaskFour();
        }
        else if (choice == "5")
        {
            RunTaskFive();
        }
        else
        {
            Console.WriteLine("Такой задачи нет.");
        }
    }

    private static void RunTaskOne()
    {
        Name cleopatra = new Name("", "Клеопатра");
        Name pushkin = new Name("Пушкин", "Александр",
            "Сергеевич");
        Name mayakovsky = new Name("Маяковский", "Владимир");

        Console.WriteLine("Задача 1: Имена");
        Console.WriteLine(cleopatra);
        Console.WriteLine(pushkin);
        Console.WriteLine(mayakovsky);
    }

    private static void RunTaskTwo()
    {
        Human cleopatra = new Human(
            new Name("Клеопатра", ""), 152);
        Human pushkin = new Human(
            new Name("Пушкин", "Александр",
                "Сергеевич"), 167);
        Human mayakovsky = new Human(
            new Name("Маяковский", "Владимир"), 189);

        Console.WriteLine("Задача 2 (2.2): Человек с именем");
        Console.WriteLine(cleopatra);
        Console.WriteLine(pushkin);
        Console.WriteLine(mayakovsky);
    }

    private static void RunTaskThree()
    {
        Human chudovIvan = new Human(
            new Name("Чудов", "Иван", "Петрович"), 180);
        Human chudovPetr = new Human(
            new Name("Чудов", "Петр", ""), 175,
            chudovIvan);
        Human boris = new Human(
            new Name("", "Борис", ""), 170,
            chudovPetr);

        Console.WriteLine("Задача 3 (2.3): Человек с родителем");
        Console.WriteLine(chudovIvan);
        Console.WriteLine(chudovPetr);
        Console.WriteLine(boris);
    }

    private static void RunTaskFour()
    {
        Console.WriteLine("Задача 4 (4.9): Ломаная");

        Polyline empty = new Polyline();
        Console.WriteLine("Пустая ломаная:");
        Console.WriteLine(empty);

        Point[] points = ReadPoints();
        Polyline polyline = new Polyline(points);

        Console.WriteLine("Ломаная с точками:");
        Console.WriteLine(polyline);
    }

    private static void RunTaskFive()
    {
        Console.WriteLine("Задача 5 (5.7): Длина");

        Point[] points = ReadPoints();
        Polyline polyline = new Polyline(points);

        Console.WriteLine("Ломаная:");
        Console.WriteLine(polyline);
        Console.WriteLine("Длина: " + polyline.GetLength());

        Console.WriteLine("Сколько точек добавить?");
        Point[] extraPoints = ReadPoints();
        polyline.AddPoints(extraPoints);

        Console.WriteLine("После добавления точек:");
        Console.WriteLine(polyline);
        Console.WriteLine("Длина: " + polyline.GetLength());
    }

    private static Point[] ReadPoints()
    {
        Console.WriteLine("Введите количество точек:");
        int count = int.Parse(Console.ReadLine());

        Point[] points = new Point[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Точка " + (i + 1));
            Console.Write("  x = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("  y = ");
            double y = double.Parse(Console.ReadLine());
            points[i] = new Point(x, y);
        }

        return points;
    }
}
