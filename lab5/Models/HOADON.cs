using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace CshartpLab5.Models
{
    public class HOADON
    {
        [Key]
        public string MAHD { get; set; }
        public string MAKH { get; set; }
        public decimal THT { get; set; }
        public DateTime NGAYHD { get; set; }
        public virtual ICollection<CTHD> CTHDs { get; set; }
        [ForeignKey("MAKH")]
        public virtual khachhang Khachhang { get; set; }
    }
}
