using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentRecords.Web.Models;

namespace StudentRecords.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<StudentModel> students;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<StudentModel> student = GetStudents();
            return View(student);
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

        public IEnumerable<StudentModel> GetStudents()
        {
            IEnumerable<StudentModel> students = null;
            using (HttpClient client = new HttpClient()) {
                string URL = "https://localhost:44351/Student/GetStudents";
                Uri uri = new Uri(URL);
                System.Threading.Tasks.Task<HttpResponseMessage> result = client.GetAsync(URL);
                if (result.Result.IsSuccessStatusCode) {
                    System.Threading.Tasks.Task<string> response = result.Result.Content.ReadAsStringAsync();
                    students = Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<StudentModel>>(response.Result);
                }

            }

            return students;
        }
    }
}
