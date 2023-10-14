using System.Diagnostics;
using System.Text;

class HangHoa
{
    public string MaHang { get; set; }
    public string TenHang { get; set; }
    public int SoLuongTon { get; set; }
    public double DonGia { get; set; }

    public HangHoa(string maHang, string tenHang, int soLuongTon, double donGia)
    {
        MaHang = maHang;
        TenHang = tenHang;
        SoLuongTon = soLuongTon;
        DonGia = donGia;
    }

    public virtual void InThongTin()
    {
        Console.WriteLine($"Mã hàng: {MaHang}");
        Console.WriteLine($"Tên hàng: {TenHang}");
        Console.WriteLine($"Số lượng tồn: {SoLuongTon}");
        Console.WriteLine($"Đơn giá: {DonGia}");
    }

    public virtual double TinhThanhTien()
    {
        return SoLuongTon * DonGia;
    }



}

class HangDienMay : HangHoa
{
    public string ThuongHieu { get; set; }
    public string LoaiMay { get; set; }
    public int ThoiGianBaoHanh { get; set; }

    public HangDienMay(string maHang, string tenHang, int soLuongTon, double donGia, string thuongHieu, string loaiMay, int thoiGianBaoHanh)
        : base(maHang, tenHang, soLuongTon, donGia)
    {
        ThuongHieu = thuongHieu;
        LoaiMay = loaiMay;
        ThoiGianBaoHanh = thoiGianBaoHanh;
    }

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Thương hiệu: {ThuongHieu}");
        Console.WriteLine($"Loại máy: {LoaiMay}");
        Console.WriteLine($"Thời gian bảo hành: {ThoiGianBaoHanh} tháng");
    }

    public override double TinhThanhTien()
    {
        double vat = 0.1;
        double thanhTien = base.TinhThanhTien() * (1 + vat);
        SoLuongTon = 0;
        return thanhTien;
    }

}

class HangThucPham : HangHoa
{
    public DateTime NgaySanXuat { get; set; }
    public DateTime NgayHetHan { get; set; }
    public string NhaCungCap { get; set; }

    public HangThucPham(string maHang, string tenHang, int soLuongTon, double donGia, DateTime ngaySanXuat, DateTime ngayHetHan, string nhaCungCap)
        : base(maHang, tenHang, soLuongTon, donGia)
    {
        NgaySanXuat = ngaySanXuat;
        NgayHetHan = ngayHetHan;
        NhaCungCap = nhaCungCap;
    }

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Ngày sản xuất: {NgaySanXuat.ToShortDateString()}");
        Console.WriteLine($"Ngày hết hạn: {NgayHetHan.ToShortDateString()}");
        Console.WriteLine($"Nhà cung cấp: {NhaCungCap}");
    }

    public override double TinhThanhTien()
    {
        double vat = 0.05;
        double thanhTien = base.TinhThanhTien() * (1 + vat);
        return thanhTien;
    }
}


class HangGiaDung : HangHoa
{
    public string NhaSanXuat { get; set; }
    public DateTime NgayNhap { get; set; }
    public string LoaiHang { get; set; }

    public HangGiaDung(string maHang, string tenHang, int soLuongTon, double donGia, string nhaSanXuat, DateTime ngayNhap, string loaiHang)
        : base(maHang, tenHang, soLuongTon, donGia)
    {
        NhaSanXuat = nhaSanXuat;
        NgayNhap = ngayNhap;
        LoaiHang = loaiHang;
    }

    public override void InThongTin()
    {
        base.InThongTin();
        Console.WriteLine($"Nhà sản xuất: {NhaSanXuat}");
        Console.WriteLine($"Ngày nhập: {NgayNhap.ToShortDateString()}");
        Console.WriteLine($"Loại hàng: {LoaiHang}");
    }

    public override double TinhThanhTien()
    {
        double vat = 0.1;
        double thanhTien = base.TinhThanhTien() * (1 + vat);
        return thanhTien;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        List<HangHoa> danhSachHangHoa = new List<HangHoa>();

        danhSachHangHoa.Add(new HangDienMay("DM001", "Laptop Dell", 5, 12000000, "Dell", "Laptop", 12));
        danhSachHangHoa.Add(new HangThucPham("TP001", "Thịt bò", 10, 150000, new DateTime(2023, 10, 1), new DateTime(2023, 10, 15), "Nhà máy thịt XYZ"));
        danhSachHangHoa.Add(new HangGiaDung("GD001", "Nồi điện", 3, 500000, "Nồi Ngon", new DateTime(2023, 9, 1), "Nồi"));

        Console.WriteLine("Danh sách hàng hóa trong siêu thị:");
        foreach (var hangHoa in danhSachHangHoa)
        {
            hangHoa.InThongTin();
            double thanhTien = hangHoa.TinhThanhTien();
            Console.WriteLine($"Thành tiền (bao gồm VAT): {thanhTien:C}");
            Console.WriteLine(new string('-', 50));
        }

        NhapHangHoa(danhSachHangHoa);

        XuatHangCanNhap(danhSachHangHoa);

        TaoHoaDonMuaHang(danhSachHangHoa);
    }

    static void NhapHangHoa(List<HangHoa> danhSachHangHoa)
    {
        while (true)
        {
            Console.WriteLine("Nhập thông tin hàng hóa mới (Nhập mã hàng trống để kết thúc):");
            Console.Write("Mã hàng: ");
            string maHang = Console.ReadLine();
            if (string.IsNullOrEmpty(maHang))
            {
                break;
            }

            Console.Write("Tên hàng: ");
            string tenHang = Console.ReadLine();
            Console.Write("Số lượng tồn: ");
            int soLuongTon = int.Parse(Console.ReadLine());
            Console.Write("Đơn giá: ");
            double donGia = double.Parse(Console.ReadLine());

            Console.Write("Loại hàng (1 - Điện máy, 2 - Thực phẩm, 3 - Gia dụng): ");
            int loaiHang = int.Parse(Console.ReadLine());

            HangHoa hangHoa = null;

            switch (loaiHang)
            {
                case 1:
                    Console.Write("Thương hiệu: ");
                    string thuongHieu = Console.ReadLine();
                    Console.Write("Loại máy: ");
                    string loaiMay = Console.ReadLine();
                    Console.Write("Thời gian bảo hành (tháng): ");
                    int thoiGianBaoHanh = int.Parse(Console.ReadLine());
                    hangHoa = new HangDienMay(maHang, tenHang, soLuongTon, donGia, thuongHieu, loaiMay, thoiGianBaoHanh);
                    break;

                case 2:
                    Console.Write("Ngày sản xuất (yyyy/MM/dd): ");
                    DateTime ngaySanXuat = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", null);
                    Console.Write("Ngày hết hạn (yyyy/MM/dd): ");
                    DateTime ngayHetHan = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", null);
                    Console.Write("Nhà cung cấp: ");
                    string nhaCungCap = Console.ReadLine();
                    hangHoa = new HangThucPham(maHang, tenHang, soLuongTon, donGia, ngaySanXuat, ngayHetHan, nhaCungCap);
                    break;

                case 3:
                    Console.Write("Nhà sản xuất: ");
                    string nhaSanXuat = Console.ReadLine();
                    Console.Write("Ngày nhập (yyyy/MM/dd): ");
                    DateTime ngayNhap = DateTime.ParseExact(Console.ReadLine(), "yyyy/MM/dd", null);
                    Console.Write("Loại hàng (VD: ly, chén, nồi...): ");
                    string loaiGiaDung = Console.ReadLine();
                    hangHoa = new HangGiaDung(maHang, tenHang, soLuongTon, donGia, nhaSanXuat, ngayNhap, loaiGiaDung);
                    break;
            }

            if (hangHoa != null)
            {
                danhSachHangHoa.Add(hangHoa);
                Console.WriteLine("Hàng hóa đã được thêm vào danh sách.");
            }
        }
    }

    static void XuatHangCanNhap(List<HangHoa> danhSachHangHoa)
    {
        Console.WriteLine("Danh sách hàng cần nhập:");
        foreach (var hangHoa in danhSachHangHoa)
        {
            if ((hangHoa is HangDienMay && hangHoa.SoLuongTon < 3) ||
                (hangHoa is HangThucPham && DateTime.Now >= ((HangThucPham)hangHoa).NgayHetHan) ||
                (hangHoa is HangGiaDung && hangHoa.SoLuongTon < 5))
            {
                Console.WriteLine($"Mã hàng: {hangHoa.MaHang}");
                Console.WriteLine($"Tên hàng: {hangHoa.TenHang}");
                if (hangHoa is HangThucPham)
                {
                    Console.WriteLine($"Ngày hết hạn: {((HangThucPham)hangHoa).NgayHetHan.ToShortDateString()}");
                }
                else
                {
                    Console.WriteLine($"Số lượng tồn: {hangHoa.SoLuongTon}");
                }
                Console.WriteLine(new string('-', 50));
            }
        }
    }

    static void TaoHoaDonMuaHang(List<HangHoa> danhSachHangHoa)
    {
        Console.WriteLine("Nhập mã hàng và số lượng muốn mua (Nhập mã hàng trống để kết thúc mua hàng):");

        Dictionary<string, int> hoaDonMuaHang = new Dictionary<string, int>();
        double tongTien = 0;

        while (true)
        {
            Console.Write("Mã hàng: ");
            string maHang = Console.ReadLine();
            if (string.IsNullOrEmpty(maHang))
            {
                break;
            }

            Console.Write("Số lượng: ");
            int soLuong = int.Parse(Console.ReadLine());

            foreach (var hangHoa in danhSachHangHoa)
            {
                if (hangHoa.MaHang == maHang && hangHoa.SoLuongTon >= soLuong)
                {
                    hoaDonMuaHang[maHang] = soLuong;
                    tongTien += hangHoa.DonGia * soLuong;
                    hangHoa.SoLuongTon -= soLuong;
                    break;
                }
            }
        }

        Console.WriteLine("Hóa đơn mua hàng:");

        foreach (var item in hoaDonMuaHang)
        {
            foreach (var hangHoa in danhSachHangHoa)
            {
                if (hangHoa.MaHang == item.Key)
                {
                    Console.WriteLine($"Mã hàng: {hangHoa.MaHang}");
                    Console.WriteLine($"Tên hàng: {hangHoa.TenHang}");
                    Console.WriteLine($"Số lượng: {item.Value}");
                    Console.WriteLine($"Đơn giá: {hangHoa.DonGia:C}");
                    Console.WriteLine($"Thành tiền: {hangHoa.DonGia * item.Value:C}");
                    Console.WriteLine(new string('-', 50));
                }
            }
        }

        double chietKhau = 0;
        if (tongTien > 2000000)
        {
            chietKhau = 0.15;
        }
        else if (tongTien > 1000000)
        {
            chietKhau = 0.1;
        }

        Console.WriteLine($"Tổng tiền trước chiết khấu: {tongTien:C}");
        double tongTienSauChietKhau = tongTien * (1 - chietKhau);
        Console.WriteLine($"Tổng tiền sau chiết khấu ({chietKhau * 100}% giảm giá): {tongTienSauChietKhau:C}");
    }
}