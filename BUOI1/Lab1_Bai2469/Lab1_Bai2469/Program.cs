using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_2_4_6_9
{
    struct PhanSo
    {
        public int TuSo;
        public int MauSo;
        public PhanSo(int tu, int mau)
        {
            TuSo = tu;
            if (mau == 0)
                MauSo = 1;
            MauSo = mau;
        }
    }
    class Program
    {
        //Cau 2
        static PhanSo NhapPhanSo()
        {
            Console.Write("Nhap tu so: ");
            int TuSo = int.Parse(Console.ReadLine());
            Console.Write("Nhap mau so: ");
            int MauSo = int.Parse(Console.ReadLine());

            return new PhanSo(TuSo, MauSo);
        }

        static int UCLN(int a, int b)
        {
            if (b == 0) return a;
            return UCLN(b, a % b);
        }
        static void RutGon(ref PhanSo ps)
        {
            int SoRutGon = UCLN(ps.TuSo, ps.MauSo);
            ps.TuSo = ps.TuSo / SoRutGon;
            ps.MauSo = ps.MauSo / SoRutGon;
        }

        static void TinhToan(PhanSo ps1, PhanSo ps2)
        {
            RutGon(ref ps1);
            RutGon(ref ps2);
            //Console.WriteLine($"{ps1.TuSo}/{ps1.MauSo}");
            //Console.WriteLine($"{ps2.TuSo}/{ps2.MauSo}");
            PhanSo tong, hieu, tich, thuong;
            tong = new PhanSo(ps1.TuSo * ps2.MauSo + ps2.TuSo * ps1.MauSo, ps1.MauSo * ps2.MauSo);
            hieu = new PhanSo(ps1.TuSo * ps2.MauSo - ps2.TuSo * ps1.MauSo, ps1.MauSo * ps2.MauSo);
            tich = new PhanSo(ps1.TuSo * ps2.TuSo, ps1.MauSo * ps2.MauSo);
            thuong = new PhanSo(ps1.TuSo * ps2.MauSo, ps1.MauSo * ps2.TuSo);
            RutGon(ref tong);
            RutGon(ref hieu);
            if (hieu.MauSo < 0)
            {
                hieu.TuSo *= -1;
                hieu.MauSo *= -1;
            }
            RutGon(ref tich);
            RutGon(ref thuong);
            Console.WriteLine($"Tong hai phan so la: {tong.TuSo}/{tong.MauSo}");
            Console.WriteLine($"Hieu hai phan so la: {hieu.TuSo}/{hieu.MauSo}");
            Console.WriteLine($"Tich hai phan so la: {tich.TuSo}/{tich.MauSo}");
            Console.WriteLine($"Thuong hai phan so la: {thuong.TuSo}/{thuong.MauSo}");

        }

        //Cau 4
        static void ThaoTacChuoi_Cau4(String str1_x, String str2_y)
        {
            Console.WriteLine($"Do dai cua chuoi x la: {str1_x.Length}");

            String BaKiTuDau_x = str1_x.Length >= 3 ? str1_x.Substring(0, 3) : str1_x;
            Console.WriteLine($"Ba ki tu dau cua chuoi x la: {BaKiTuDau_x}");

            String BaKiTuCuoi_x = str1_x.Length >= 3 ? str1_x.Substring(str1_x.Length - 3) : str1_x;
            Console.WriteLine($"Ba ki tu cuoi cua chuoi x la: {BaKiTuCuoi_x}");

            String KiTuThuSau = str1_x.Length >= 6 ? str1_x.Substring(5, 1) : str1_x;
            Console.WriteLine($"Ki tu thu sau cua chuoi x la: {KiTuThuSau}");

            String BaKiTuCuoi_y = str2_y.Length >= 3 ? str2_y.Substring(str2_y.Length - 3) : str2_y;
            String ChuoiMoi = BaKiTuDau_x + BaKiTuCuoi_y;
            Console.WriteLine($"Chuoi moi duoc tao la: {ChuoiMoi}");

            Boolean checkChuoi = str1_x.Equals(str2_y);
            if (checkChuoi)
            {
                Console.WriteLine("Hai chuoi x va y bang nhau");
            }
            else
            {
                Console.WriteLine("Hai chuoi x va y khong bang nhau");
            }

            int ViTri = str1_x.IndexOf(str2_y);
            if(ViTri >= 0)
            {
                Console.WriteLine($"y co xuat hien trong x va xuat hien tai vi tri: {ViTri}");
            } 
            else
            {
                Console.WriteLine("y khong xuat hien trong x");
            }

            int[] viTriXuatHien = TimViTriXuatHien(str1_x, str2_y);
            if (viTriXuatHien.Length > 0)
            {
                Console.WriteLine($"Tat ca vi tri xuat hien cua y trong x: {string.Join(", ", viTriXuatHien)}");
            }
            else
            {
                Console.WriteLine("y khong xuat hien trong x");
            }
        }

        static int[] TimViTriXuatHien(string x, string y)
        {
            var viTriList = new System.Collections.Generic.List<int>();
            int viTri = x.IndexOf(y);
            while (viTri != -1)
            {
                viTriList.Add(viTri);
                viTri = x.IndexOf(y, viTri + 1);
            }
            return viTriList.ToArray();
        }

        //cau 9
        static int SoChuSoCuaN(int So_N)
        {
            int demSo = 0;
            while(So_N > 0)
            {
                So_N /= 10;
                demSo++;
            }
            return demSo;
        }

        static void Main(string[] args)
        {

            //Cau2
            Console.WriteLine("Nhap phan so thu nhat:");
            PhanSo phanSo1 = NhapPhanSo();

            Console.WriteLine("\nNhap phan so thu hai:");
            PhanSo phanSo2 = NhapPhanSo();

            TinhToan(phanSo1, phanSo2);

            //Cau 4
            Console.Write("\n\nNhap chuoi x: ");
            string x = Console.ReadLine();

            Console.Write("\nNhap chuoi y: ");
            string y = Console.ReadLine();

            ThaoTacChuoi_Cau4(x, y);


            //Cau 9
            Console.Write("\n\nNhap so n de dem so luong chu so:");
            int So_N = int.Parse(Console.ReadLine());
            Console.WriteLine($"So chu so cua {So_N} la: {SoChuSoCuaN(So_N)}");

        }
    }
}
