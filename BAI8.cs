using System;

public class Bai8
{
    public class DinhTamGiac
    {
        public double x;
        public double y;

        public DinhTamGiac(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    public static void Main(string[] args)
    {

        DinhTamGiac a = new DinhTamGiac(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
        DinhTamGiac b = new DinhTamGiac(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));
        DinhTamGiac c = new DinhTamGiac(double.Parse(Console.ReadLine()), double.Parse(Console.ReadLine()));

        double perimeter = a.x + b.x + c.x + a.y + b.y + c.y;

        double area = Math.Abs((a.x * b.y + b.x * c.y + c.x * a.y) - (a.y * b.x + b.y * c.x + c.y * a.x)) / 2;

        Console.WriteLine($"Chu vi: {perimeter}.");
        Console.WriteLine($"Dien tich {area}.");
    }
}
