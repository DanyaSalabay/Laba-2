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
        Console.WriteLine("Задача 1: Имена");

        Console.WriteLine("Сколько имён создать?");
        int count = int.Parse(Console.ReadLine());

        Name[] names = new Name[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Имя " + (i + 1));
            Console.Write("  Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("  Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("  Отчество: ");
            string middleName = Console.ReadLine();

            names[i] = new Name(lastName, firstName,
                middleName);
        }

        Console.WriteLine("Результат:");
        for (int i = 0; i < names.Length; i++)
        {
            Console.WriteLine(names[i]);
        }
    }

    private static void RunTaskTwo()
    {
        Console.WriteLine("Задача 2 (2.2): Человек с именем");

        Console.WriteLine("Сколько людей создать?");
        int count = int.Parse(Console.ReadLine());

        Human[] people = new Human[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Человек " + (i + 1));

            Console.Write("  Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("  Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("  Отчество: ");
            string middleName = Console.ReadLine();

            int height = ReadHeight();

            Name name = new Name(lastName, firstName,
                middleName);
            people[i] = new Human(name, height);
        }

        Console.WriteLine("Результат:");
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine(people[i]);
        }
    }

    private static void RunTaskThree()
    {
        Console.WriteLine("Задача 3 (2.3): Человек с родителем");

        Console.WriteLine("Сколько людей создать?");
        int count = int.Parse(Console.ReadLine());

        Human[] people = new Human[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Человек " + (i + 1));

            Console.Write("  Фамилия: ");
            string lastName = Console.ReadLine();
            Console.Write("  Имя: ");
            string firstName = Console.ReadLine();
            Console.Write("  Отчество: ");
            string middleName = Console.ReadLine();

            Name name = new Name(lastName, firstName,
                middleName);

            Console.Write("  Есть отец? (1 - да, 0 - нет): ");
            string hasFather = Console.ReadLine();

            if (hasFather == "1")
            {
                Console.Write("  Фамилия отца: ");
                string fatherLastName = Console.ReadLine();
                Console.Write("  Имя отца: ");
                string fatherFirstName = Console.ReadLine();
                Console.Write("  Отчество отца: ");
                string fatherMiddleName = Console.ReadLine();

                Human father = FindFather(people, i,
                    fatherLastName, fatherFirstName,
                    fatherMiddleName);

                if (father != null)
                {
                    people[i] = new Human(name, 0, father);
                }
                else
                {
                    Console.WriteLine("  Отец не найден. "
                        + "Человек создан без отца.");
                    people[i] = new Human(name, 0);
                }
            }
            else
            {
                people[i] = new Human(name, 0);
            }
        }

        Console.WriteLine("Результат:");
        for (int i = 0; i < people.Length; i++)
        {
            Console.WriteLine(people[i]);
        }
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

    private static int ReadHeight()
    {
        int height;

        while (true)
        {
            Console.Write("  Рост: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out height) && height > 0)
            {
                return height;
            }

            Console.WriteLine("  Рост должен быть "
                + "положительным числом. Попробуйте снова.");
        }
    }

    private static Human FindFather(Human[] people,
        int count, string lastName, string firstName,
        string middleName)
    {
        for (int i = 0; i < count; i++)
        {
            Name fatherName = people[i].Name;

            if (fatherName.LastName == lastName &&
                fatherName.FirstName == firstName &&
                fatherName.MiddleName == middleName)
            {
                return people[i];
            }
        }

        return null;
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
