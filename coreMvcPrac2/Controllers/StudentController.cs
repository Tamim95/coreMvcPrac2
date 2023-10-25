using Microsoft.AspNetCore.Mvc;
using coreMvcPrac2.Models;
namespace coreMvcPrac2.Controllers
{
    public class StudentController : Controller
    {
        public List<StudentModel> students = new List<StudentModel>()
        {
            new StudentModel() { Id=101, Name="Josep", School="Saint Josep", Department="Science"},
            new StudentModel() {Id=301,Name="Paul Adam", School="Saint Josep", Department="Arts"},
            new StudentModel() {Id=401, Name="Mike Toe", School="Saint Josep",Department="Business"}

        };
        public IActionResult Show()
        {
            ViewBag.Message = "Welcome in our school.";
            ViewBag.StudentCount=students.Count();
            ViewBag.StudentList = students;

            return View();
        }
        public IActionResult Science()
        {
            ViewBag.Message = "Welcome to Our Science Department.";
            return View();
        }
        public IActionResult Arts()
        {
            ViewBag.Message = "Welcome to our Arts Department.";
            return View();
        }
        public IActionResult Business()
        {
            ViewBag.Message = "Welcome to our Business Department.";
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            HttpContext.Session.SetString("username", "Josep");
            //HttpContext.Session.SetString("username", "Bhawna");
            return RedirectToAction("Success");
        }
        public IActionResult Success()
        {
            ViewBag.UserName = HttpContext.Session.GetString("username");
            return View();
        }
       
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Index");
        }
        
    }
}
