using dotnet_mvc.Models;
using dotnet_mvc.ViewModels;

namespace dotnet_mvc.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEmployee_Repository _employee_repo;
        [Obsolete]
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public HomeController(IEmployee_Repository _emp_rep, Microsoft.AspNetCore.Hosting.IHostingEnvironment hostingEnvironment)
        {
             _employee_repo = _emp_rep;
            this.hostingEnvironment = hostingEnvironment;
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

        public ViewResult Details(int? id)
        {
            Console.WriteLine("_ID CHECK => " + id);
            ResponseEmployeeRepository data = _employee_repo.getName(id??1);
            Console.WriteLine("Data CHECK => " + data?.employee?.name);

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

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(HomeCreateViewModel emp_model)
        {
            if (ModelState.IsValid) {

                Console.WriteLine("CREATE DATA --- " + emp_model.photo);
                string photoName = null;
                if(emp_model.photo != null)
                {
                    string uploadFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    photoName = Guid.NewGuid().ToString() + "_" + emp_model.photo.FileName;
                    string photoLocation = Path.Combine(uploadFolder, photoName);
                    emp_model.photo.CopyTo(new FileStream(photoLocation, FileMode.Create));
                }
                Employee newEmp = new Employee
                {
                    name = emp_model.name,
                    email = emp_model.email,
                    department = emp_model.department,
                    photoPath = photoName,
                    
                };
                _employee_repo.AddNewEmpoyee(newEmp);
                Console.WriteLine("CREATE DATA ID --- " + newEmp.id);

                return RedirectToAction("Details", new {id = newEmp.id});
            }
            return View();
        }
    }
}