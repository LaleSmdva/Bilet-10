using Exam_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exam_Test.Controllers
{
    public class HomeController : Controller
    {
       

        public IActionResult Index()
        {
            return View();
        }

  
    }
}