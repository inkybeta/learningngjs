using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AngularJSCore;
using AngularJSData;
using AngularJSData.Repositories;
using Newtonsoft.Json;
using Ninject.Planning.Bindings;

namespace AngularJS.Controllers
{
    public class HomeController : Controller
    {
        public IEmployeeRepository _dbContext;
        public HomeController(IEmployeeRepository context)
        {
            _dbContext = context;
        }
        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> GetEmployees(int count)
        {
            Response.Headers.Set("Content-Type", "text/plain");
            EmployeeModel[] employees = await _dbContext.GetEmployees(count, 0);
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(employees));
        }
        public async Task<string> GetEmployeesByJob(string job)
        {
            Response.Headers.Set("Content-Type", "text/plain");
            EmployeeModel[] employees = await _dbContext.GetEmployeesByName(job);
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(employees));
        }

        [HttpPost]
        public async Task<string> AddEmployee(string jsonEmployee)
        {
            var employee = JsonConvert.DeserializeObject<EmployeeModel>(jsonEmployee);
            Response.Headers.Set("Content-Type", "text/plain");
            string succeeded = (await _dbContext.AddEmployee(employee)).ToString();
            return await Task.Factory.StartNew(() => succeeded);
        }
    }
}