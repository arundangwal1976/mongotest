using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoWebAppTest.Helper;
using MongoWebAppTest.Models;

namespace MongoWebAppTest.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IDataContext<Employee, EmployeeViewModel> employeeContext;

        public EmployeeController(ILogger<EmployeeController> logger, IDataContext<Employee, EmployeeViewModel> dbContext)
        {
            _logger = logger;
            employeeContext = dbContext;
        }

        public IActionResult Index()
        {
            var employees = employeeContext.Get();

            return View(employees);
        }

        [Route("Employee/Add")]
        public IActionResult Add()
        {
            return View();

        }

        [Route("Employee/{id}")]
        public IActionResult Detail(string id)
        {
            var vm = employeeContext.Get(id).FirstOrDefault();

            return View(vm);
        }

        [HttpPost]
        [Route("Employee/Add")]
        public IActionResult Add(EmployeeViewModel vm)
        {
            employeeContext.Add(vm);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Employee/Update")]
        public IActionResult Update(EmployeeViewModel vm)
        {
            employeeContext.Update(vm);

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
