using Microsoft.AspNetCore.Mvc;
using StudentApp.Data.Services;
using StudentApp.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentApp.Web.Controllers
{
    public class StudentController : Controller
    {
        private StudentServices _service;

        public StudentController(StudentServices service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var vm = new StudentViewModel();
            vm.SetService(_service);
            vm.Read();
            return View(vm);
        }
    }
}
