using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }

        public string? Unit { get; set; }
        public Decimal Price { get; set; }

        public virtual Supplier? Supplier { get; set; }

        
    }
}
