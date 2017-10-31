using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTrainingBlank.Models;

namespace MVCTrainingBlank.Controllers
{
    public class StudentController : Controller
    {
        public List<StudentViewModel> students = new List<StudentViewModel>()
        {
            new StudentViewModel()
            {
                Id = 1,
                FirstName = "Patrick",
                LastName = "Star",
                gpa = 2.3,
                Classes = new List<ClassViewModel>()
                {
                    new ClassViewModel()
                    {
                        ID = 3,
                        Designator = "CS 161",
                        ClassName = "Introduction To Programming",
                        Instructor = "Bob",
                        numberOfCredits = 5
                    }
                }
            },
            new StudentViewModel()
            {
                Id = 2,
                FirstName = "Strong",
                LastName = "Bad",
                gpa = 2.9,
                Classes = new List<ClassViewModel>()
                {
                    new ClassViewModel()
                    {
                        ID = 1,
                        Designator = "CS325",
                        ClassName = "Algorithms",
                        Instructor = "Bob",
                        numberOfCredits = 4
                    },
                    new ClassViewModel()
                    {
                        ID = 2,
                        Designator = "CS461",
                        ClassName = "Capstone",
                        Instructor = "Kelly",
                        numberOfCredits = 3
                    }
                }
            },
            new StudentViewModel()
            {
                Id = 3,
                FirstName = "Thomas",
                LastName = "Dudeman",
                gpa = 3.8,
                Classes = null
            }
        };
        // GET: Student
        public ActionResult Index()
        {
            List<StudentViewModel> students = this.students; 
            return View(students);
        }

        public ActionResult Details(int id)
        {
            StudentViewModel student = students.Find(s => s.Id == id);
            if(student == null)
            {
                return View("Error");
            }
            return View(student);
        }
    }
}