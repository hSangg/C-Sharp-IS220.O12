class BAI7
{
    static void Main()
    {
        Console.Write("Nhập năm: ");
        int nam = Convert.ToInt32(Console.ReadLine());

        int soNgayThang13 = SoNgayThang13(nam);
        Console.WriteLine($"Năm {nam} có {soNgayThang13} ngày thứ sáu ngày 13.");
    }

    static int SoNgayThang13(int nam)
    {
        int soNgayThang13 = 0;
        for (int thang = 1; thang <= 12; thang++)
        {
            DateTime ngay13 = new DateTime(nam, thang, 13);
            if (ngay13.DayOfWeek == DayOfWeek.Friday)
            {
                soNgayThang13++;
            }
        }
        return soNgayThang13;
    }
}
