using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        public string? CustomerName { get; set; }
        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
