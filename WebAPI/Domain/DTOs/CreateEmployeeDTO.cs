using WebAPI.Domain.Models;

namespace WebAPI.Domain.DTOs
{
    public class CreateEmployeeDTO
    {


        public string Name { get; set; }
        public int Age { get; set; }
        public Company Company { get; set; }

        //public CreateEmployeeDTO(string name, int age, Company company)
        //{
        //    Name = name;
        //    Age = age;
        //    Company = company;
        //}

    }
}
