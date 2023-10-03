using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //Câu 1
            double r, circumference;
            string stringR;
            Console.Write("Nhap vao duong kinh hinh tron: ");
            stringR = Console.ReadLine();
            r = double.Parse(stringR);
            Console.WriteLine(r);
            circumference = r * 2 * Math.PI;
            Console.WriteLine(circumference);

            //Câu 3
            int day, month, year;
            String name, sex;
            Console.Write("Name: ");
            name = Console.ReadLine();
            Console.Write("Day: ");
            day = int.Parse(Console.ReadLine());
            Console.Write("Month: ");
            month = int.Parse(Console.ReadLine());
            Console.Write("Year: ");
            year = int.Parse(Console.ReadLine());
            DateTime birth = new DateTime(year, month, day);
            Console.Write("sex: ");
            sex = Console.ReadLine();
            if (birth.Day == 29 && birth.Month == 2)
            {
                birth = birth.AddDays(1);
            }
            birth = birth.AddYears(sex == "nu" ? 55 : 60);
            Console.WriteLine(birth.ToString());

            //Câu 5
            int electricUse, bill = 0;
            Console.Write("Nhap so dien sd: ");
            electricUse = int.Parse(Console.ReadLine());
            if (electricUse <= 0)
            {
                Console.WriteLine("sao xai am dien duoc vay chi voi");
            }
            else if (electricUse <= 50)
            {
                bill = electricUse * 2000;
            }
            else
            {
                bill = 50 * 2000 + (electricUse - 50) * (electricUse > 100 ? 3500 : 2500);
            }
            Console.WriteLine(bill);
        }

    }
}
