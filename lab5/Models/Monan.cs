using System.ComponentModel.DataAnnotations;

namespace CshartpLab5.Models
{
    public class Monan
    {
        [Key] public string MAMA { get; set; }
        public string TENMA { get; set; }
        public float DONGIA { get; set; }
        public string LOAIMA { get; set; }
    }
}
