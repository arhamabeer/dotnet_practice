using System.Xml.Linq;

namespace dotnet_mvc.Models
{
    public class MockEmployeeRepository : IEmployee_Repository
    {

        private List<Employee> _employees;

        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee(){id = 1, name = "Arham", email = "arham@gmail.com", department = "SE"},
                new Employee(){id = 2, name = "Abeer", email = "abeer@gmail.com", department = "CS"},
                new Employee(){id = 3, name = "Ahmed", email = "aaa@gmail.com", department = "SE"},
            };
        }
        public Employee getName(int id)
        {
            Employee? res = _employees.FirstOrDefault(e => e.id == id);
            Console.WriteLine("getName => " + id + "---" + res);
            return res;
        }
    }
}
