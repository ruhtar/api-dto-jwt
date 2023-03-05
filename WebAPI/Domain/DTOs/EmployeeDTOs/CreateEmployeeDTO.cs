using WebAPI.Domain.Models;

namespace WebAPI.Domain.DTOs.EmployeeDTOs
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }

    }
}
