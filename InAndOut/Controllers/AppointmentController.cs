using Microsoft.AspNetCore.Mvc;
using System;

namespace InAndOut.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult ajdi(int id)
        {
            return Ok("You have entered id = " + id);
        }
    }
}
