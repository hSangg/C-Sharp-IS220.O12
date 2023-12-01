using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? EmployeeID { get; set; }
        public int? totalPrice { get; set; }
        public virtual Customer? Customer { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
