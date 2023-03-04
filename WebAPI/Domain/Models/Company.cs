using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
