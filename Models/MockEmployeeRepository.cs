using System.Xml.Linq;

namespace dotnet_mvc.Models
{

    public class ResponseEmployeeRepository
    {
        public Employee? employee = new Employee();
        public Boolean isFind = false;
        public string message = "";
        public ResponseEmployeeRepository(Employee? _emp, Boolean _isFind, string _msg) {
            employee = _emp;
            isFind = _isFind;
            message = _msg;
        }
       
    }
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
        public ResponseEmployeeRepository getName(int id)
        {
            ResponseEmployeeRepository _rer;
            Employee? res = _employees.FirstOrDefault(e => e.id == id);
            if (res != null) {
                _rer = new ResponseEmployeeRepository(res, true,"Employee found.");
            }
            else
            {
               _rer = new ResponseEmployeeRepository(res, false, "No corresponding employee found during search.");
            }

            //System.Diagnostics.Debug.WriteLine(_rer);

            return _rer;

        }

        public List<Employee> getEmployees() { 
            return _employees;
        }
    }
}
