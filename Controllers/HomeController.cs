using dotnet_mvc.Models;
using dotnet_mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dotnet_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee_Repository _employee_repo;

        public HomeController(IEmployee_Repository _emp_rep)
        {
             _employee_repo = _emp_rep;
        }

        public string Index()
        {
            var data = _employee_repo.getName(1);

            Console.WriteLine($"data => {data.message}, {data.employee}, {data.isFind}");
            if (data.isFind)
            {
                return data.employee.name;
            }
            else
            {
                return data.message;
            }
        }
        public ViewResult Details()
        {
            ResponseEmployeeRepository data = _employee_repo.getName(1);
            HomeDetailsViewModel hdvm = new HomeDetailsViewModel()
            {
                Title = "Employee Details",

            };

            Console.WriteLine($"data => {data.message}, {data.employee}, {data.isFind}");
            if (data.isFind)
            {
                //return Json(data.employee);
                hdvm.data = data.employee;
                return View(hdvm);
            }
            else
            {
                return View(data.message);
            }
        }

        public ViewResult AllEmployees()
        {
            var data = _employee_repo.getEmployees();
            return View(data);
        }
    }
}