using System.ComponentModel.DataAnnotations;

namespace WebAPI.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string? Photo { get; set; }
        public virtual Company? CurrentCompany { get; set; }

        public Employee(string name, int age, string photo, Company company)
        {
            Name = name;
            Age = age;
            Photo = photo;
            CurrentCompany = company;
        }

        public Employee()
        {
        }
    }
}
