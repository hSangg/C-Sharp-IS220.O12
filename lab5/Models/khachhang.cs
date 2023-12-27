using System.ComponentModel.DataAnnotations;

namespace CshartpLab5.Models
{
    public class khachhang
    {
        [Key]
        public string MAKH { get; set; }
        public string HO { get; set; }
        public string TEN { get; set; }
        public DateTime NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        public string SDT { get; set; }
        public string FullName
        {
            get { return HO + " " + TEN; }
        } 
    }
}
