using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentRecords.Web.Models;

namespace StudentRecords.WebApi.Controllers
{
    public class StudentController : Controller
    {
        List<StudentModel> student;


        public IActionResult Index()
        {
            return View();
        }

        public StudentController()
        {
            student = new List<StudentModel>();
            student.Add(new StudentModel { ID = "1", Name = "Jessia Ann", Phone = "7833289952" });
            student.Add(new StudentModel { ID = "2", Name = "Julia Ann", Phone = "8633289952" });
            student.Add(new StudentModel { ID = "3", Name = "Jojin Abraham", Phone = "3381229952" });
        }

        [Route("Student/GetStudents")]
        public List<StudentModel> Get() {
            return student;
        }
    }
}
