using Microsoft.AspNetCore.Mvc;
using prjWeb.Models;

namespace prjWeb.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> Students = new List<Student>();

        public IActionResult Index()
        {
            return View();
        }

        // POST: Student/Index
        [HttpPost]
        public ActionResult Index(Student student)
        {
            if (ModelState.IsValid)
            {
                Students.Add(student);

                // Truyền dữ liệu sang trang ShowKQ
                return RedirectToAction("ShowKQ", new
                {
                    MSSV = student.MSSV,
                    HoTen = student.HoTen,
                    ChuyenNganh = student.ChuyenNganh
                });
            }
            return View(student);
        }

        // GET: Student/ShowKQ
        public ActionResult ShowKQ(string MSSV, string HoTen, string ChuyenNganh)
        {
            var sameMajorCount = Students.Count(s => s.ChuyenNganh == ChuyenNganh);
            var orderNumber = Students.FindIndex(s => s.MSSV == MSSV) + 1;

            ViewBag.MSSV = MSSV;
            ViewBag.HoTen = HoTen;
            ViewBag.ChuyenNganh = ChuyenNganh;
            ViewBag.SameMajorCount = sameMajorCount;
            ViewBag.OrderNumber = orderNumber;

            return View();
        }
    }
    public class Student
    {
        public string MSSV { get; set; }
        public string HoTen { get; set; }
        public double DiemTB { get; set; }
        public string ChuyenNganh { get; set; }
    }
}
