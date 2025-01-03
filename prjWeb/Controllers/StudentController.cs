﻿using Microsoft.AspNetCore.Mvc;
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
            if (Students.Any(s => s.MSSV == student.MSSV))
            {
                Student s = Students.FirstOrDefault(s => s.MSSV == student.MSSV);
                return RedirectToAction("ShowKQ", new
                {
                    MSSV = s.MSSV,
                    HoTen = s.HoTen,
                    ChuyenNganh = s.ChuyenNganh
                });
            }

            if (ModelState.IsValid)
            {
                Students.Add(student);
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
            var sameMajorStudents = Students.Where(s => s.ChuyenNganh == ChuyenNganh).ToList();
            var orderNumber = sameMajorStudents.FindIndex(s => s.MSSV == MSSV) + 1;

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
