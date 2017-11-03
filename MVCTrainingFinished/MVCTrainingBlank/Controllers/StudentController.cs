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
        public static List<StudentViewModel> studentsList = new List<StudentViewModel>()
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
            List<StudentViewModel> students = studentsList; 
            return View(students);
        }

        public ActionResult Details(int id)
        {
            StudentViewModel student = studentsList.Find(s => s.Id == id);
            if(student == null)
            {
                return View("Error");
            }
            return View(student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel model)
        {
            try
            {
                model.Id = studentsList.Last().Id + 1;
                studentsList.Add(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentViewModel model = studentsList.Find(s => s.Id == id);
            if (model == null)
            {
                return View("Error");
            }
            return View(model);
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, StudentViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                studentsList.RemoveAll(s => s.Id == id);
                studentsList.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            StudentViewModel model = studentsList.Find(s => s.Id == id);
            return View(model);
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, StudentViewModel model)
        {
            try
            {
                studentsList.RemoveAll(s => s.Id == id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

    }
}