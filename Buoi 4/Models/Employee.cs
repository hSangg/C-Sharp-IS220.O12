using System.ComponentModel.DataAnnotations;

namespace Lab4.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Photo { get; set; }
        public string? Notes { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }

        public void CreateEmployee(Employee employee)
        {
            String sql = "INSERT INTO employees VALUES(N'" + employee.LastName + "',N'" + employee.FirstName + "','" + employee.BirthDate + "','" + employee.Photo + "','" + employee.Notes+"')";
            
        }
    }
}
