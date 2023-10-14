using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Bai1
{
    class Program
    {
        interface IKhachHang {
            void XuatHoaDon();
        }
        abstract class KhachHang : IKhachHang
        {
            public int MaKH { get; set; }
            public string TenKH { get; set; }
            public int NgayHD { get; set; }
            public int ThangHD { get; set; }
            public int NamHD { get; set; }
            public long SLDien { get; set; }
            public long DonGia { get; set; }
            public long ThanhTien { get; set; }

            public KhachHang() { }
            public KhachHang(int maKH, string tenKH, int ngayHD, int thangHD, int namHD, long sLDien, long donGia, long thanhTien)
            {
                MaKH = maKH;
                TenKH = tenKH;
                NgayHD = ngayHD;
                ThangHD = thangHD;
                NamHD = namHD;
                SLDien = sLDien;
                DonGia = donGia;
                ThanhTien = thanhTien;
            }

            public long TinhThanhTien() { return 0; }
            public void XuatHoaDon()
            {
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine($"Mã khách hàng: {MaKH}");
                Console.WriteLine($"Tên khách hàng: {TenKH}");
                DateTime date = new DateTime(NamHD, ThangHD, NgayHD);
                string formattedDate = date.ToString("dd/MM/yyyy");
                Console.WriteLine($"Ngày hoá đơn: {formattedDate}");
                Console.WriteLine($"Số lượng điện đã dùng: ${SLDien}");
                Console.WriteLine($"Đơn giá: ${DonGia}");
            }
        }
        static void Main(string[] args)
        {

        }
    }
}

