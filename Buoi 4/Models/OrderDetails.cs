using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class OrderDetails
    {
        [Key]
        public int? OrderID { get; set; }
        public int? ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
