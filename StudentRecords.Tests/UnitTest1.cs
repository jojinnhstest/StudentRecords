using NUnit.Framework;
using StudentRecords.Web.Models;
using StudentRecords.WebApi.Controllers;
using System.Collections.Generic;

namespace StudentRecords.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void HasStudentsEnrolled()
        {
            //This test will pass if there is atleast one student enrolled
            StudentController objTest = new StudentController();
            List<StudentModel> student = objTest.Get();
            Assert.That(student.Count > 0);
        }
    }
}