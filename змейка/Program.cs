
using System;
using System.ComponentModel.Design;
using System.Runtime;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;

class Program
{
    static void GenerateRPoint(out int randomX, out int randomY)
    {
        Random random = new Random();
        randomX = random.Next(0, 119);
        randomY = random.Next(0, 29);
    }
    public struct Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    static string input = "up";
    static List<Point> appleloc = new List<Point>();
    static List<Point> points = new List<Point>();
    static List<char> ButtonsHistory = new List<char>()
    {
        'W'
    };
    static int large = 1;
    static void Main()
    {
        Console.CursorVisible = false;
        GenerateRPoint(out int randomX1, out int randomY1);
        Point start = new Point(randomX1, randomY1);
        points.Add(start);
        Console.SetCursorPosition(randomX1, randomY1);
        Console.Write('o');
        Thread thread = new Thread(DoWork);
        thread.Start();
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    if (ButtonsHistory[ButtonsHistory.Count - 1] != 'S')
                    {
                        input = "up";
                        char button = 'W';
                        ButtonsHistory.Add(button);
                    }

                    break;

                case ConsoleKey.D:
                    if (ButtonsHistory[ButtonsHistory.Count - 1] != 'A')
                    {
                        input = "right";
                        char button = 'D';
                        ButtonsHistory.Add(button);
                    }
                    break;

                case ConsoleKey.A:
                    if (ButtonsHistory[ButtonsHistory.Count - 1] != 'D')
                    {
                        input = "left";
                        char button = 'A';
                        ButtonsHistory.Add(button);
                    }
                    break;
                case ConsoleKey.S:
                    if (ButtonsHistory[ButtonsHistory.Count - 1] != 'W')
                    {
                        input = "down";
                        char button = 'S';
                        ButtonsHistory.Add(button);
                    }
                    break;


            }
            
        }
    }
    static void DoWork()
    {
        int i = 0;
        while (true)
        {
            foreach (Point p in points)
            {
                if (points.Count > 1)
                {
                    for (int j = 0; j < points.Count - 1; j++)
                    {
                        if (points[points.Count - 1].x == points[j].x && points[points.Count - 1].y == points[j].y)
                        {
                            Environment.Exit(0);
                        }
                    }
                }
            }
            if (appleloc.Count == 0)
            {
                while (true)
                {
                    GenerateRPoint(out int randomX1, out int randomY1);
                    bool isOccupied = false;
                    foreach (Point p in points)
                    {
                        if (p.x == randomX1 && p.y == randomY1)
                        {
                            isOccupied = true;
                            break;
                        }
                    }

                    if (!isOccupied)
                    {
                        Point pointa = new Point(randomX1, randomY1);
                        appleloc.Add(pointa);
                        Console.SetCursorPosition(randomX1, randomY1);
                        Console.Write("@");
                        break; // Найдена свободная позиция, выходим из цикла
                    }
                }
            }
            if (points[points.Count - 1].x == appleloc[0].x && points[points.Count - 1].y == appleloc[0].y)
            {
                large++;
                appleloc.RemoveAt(0);
            }
            if (input == "up")
            {
                if (i > 30)
                {
                    i = 0;
                }
                if (points[points.Count - 1].y - 1 > -1)
                {
                    Thread.Sleep(100);
                    Console.SetCursorPosition(points[points.Count - 1].x, points[points.Count - 1].y - 1);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(50);
                    }


                }
                else
                {
                    Console.SetCursorPosition(points[points.Count - 1].x, 29);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(50);
                    }
                    i = 0;
                }
                i++;
            }
            if (input == "right")
            {
                if (i > 120)
                {
                    i = 0;
                }
                if (points[points.Count - 1].x + 1 < 120)
                {
                    Thread.Sleep(70);
                    Console.SetCursorPosition(points[points.Count - 1].x + 1, points[points.Count - 1].y);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(35);
                    }


                }
                else
                {
                    Console.SetCursorPosition(0, points[points.Count - 1].y);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(35);
                    }
                    i = 0;
                }
                i++;
            }
            if (input == "left")
            {
                if (i > 120)
                {
                    i = 0;
                }
                if (points[points.Count - 1].x - 1 > - 1)
                {
                    Thread.Sleep(70);
                    Console.SetCursorPosition(points[points.Count - 1].x - 1, points[points.Count - 1].y);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(35);
                    }


                }
                else
                {
                    Console.SetCursorPosition(119, points[points.Count - 1].y);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(35);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(5);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(35);
                    }
                    i = 0;
                }
                i++;
            }
            if (input == "down")
            {
                if (i > 30)
                {
                    i = 0;
                }
                if (points[points.Count - 1].y + 1 <30)
                {
                    Thread.Sleep(100);
                    Console.SetCursorPosition(points[points.Count - 1].x, points[points.Count - 1].y + 1);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(50);
                    }


                }
                else
                {
                    Console.SetCursorPosition(points[points.Count - 1].x, 0);
                    Point move = new Point(Console.CursorLeft, Console.CursorTop);
                    points.Add(move);
                    Console.Write('o');
                    if (points.Count - 1 - large >= 0 && large >= 0)
                    {
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        Console.Write('.');
                        Thread.Sleep(50);
                        Console.SetCursorPosition(points[points.Count - 1 - large].x, points[points.Count - 1 - large].y);
                        points.RemoveAt(points.Count - 1 - large);
                        Console.Write(' ');
                        Thread.Sleep(50);
                    }
                    i = 0;
                }
                i++;
            }

        }
        Console.ReadKey();
    }
}
    


