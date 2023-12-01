using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }
        public string? SupplierName { get; set; }
        public string? ContactName { get; set; } 
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public string? Phone { get; set; }

        public virtual ICollection<Product>? products { get; set; }
    }
}
