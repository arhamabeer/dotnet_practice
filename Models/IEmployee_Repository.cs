namespace dotnet_mvc.Models
{
    public interface IEmployee_Repository
    {
        ResponseEmployeeRepository getName(int id);
        List<Employee> getEmployees();
    }
}
