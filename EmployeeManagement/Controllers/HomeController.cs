using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;


            // THIS IS BAD, tight coupling dependency on MockEmployeeRepository
            // will make the program impossable to maintain if MockEmployeeRepository
            // is ever switched out with another class type in Startup.cs
            // can run into instance of having to rewrite hundreds of classes due to tight coupling
            //_employeeRepository = new MockEmployeeRepository();
        }
        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
    }
}
