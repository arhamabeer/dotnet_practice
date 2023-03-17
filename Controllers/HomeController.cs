using dotnet_mvc.Models;
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

        public void Index(int id)
        {
            var data = _employee_repo.getName(1);

            Console.WriteLine("data => " + data);
            //return data;
        }
    }
}