using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CshartpLab5.Models
{
    public class CTHD
    {
        public string MAHD { get; set; }

        public string MAMA { get; set; }
        public string ?MAK { get; set; }
        public int SL { get; set; }
        [ForeignKey("MAHD")]
        public virtual HOADON HOADON { get; set; }
        [ForeignKey("MAMA")]
        public virtual Monan monan { get; set; }

    }
}
