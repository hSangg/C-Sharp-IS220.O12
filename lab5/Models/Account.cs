using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CshartpLab5.Models
{
    public class Account
    {
        [Key]
        public String USERNAME { get; set; }
        public String PASSWORD { get; set; }
        public string MAKH { get; set; }
        [ForeignKey("MAKH")]
        public virtual khachhang Khachhang { get; set; }
    }
}
