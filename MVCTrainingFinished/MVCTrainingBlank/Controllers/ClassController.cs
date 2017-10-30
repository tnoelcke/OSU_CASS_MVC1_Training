using MVCTrainingBlank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTrainingBlank.Controllers
{
    public class ClassController : Controller
    {

        public List<ClassViewModel> classes = new List<ClassViewModel>()
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
                },

                new ClassViewModel()
                {
                    ID = 3,
                    Designator = "CS 161",
                    ClassName = "Introduction To Programing",
                    Instructor = "Bob",
                    numberOfCredits = 5
                }
            };
        // GET: Class
        public ActionResult Index()
        {
            // This is where you would got out to the database and get the data
            //but for this example we are just using a hardcoded view model.
            List<ClassViewModel> toDisplay = classes;

            return View(classes);
        }

        /// <summary>
        /// Shows the details for an individual class.
        /// </summary>
        /// <returns>view for the individual class.</returns>
        public ActionResult Details(int id)
        {
            //note here is where we would go out to the DB and get the data.
            ClassViewModel toView = classes.Find(c => c.ID == id);
            if(toView == null)
            {
                return View("Error");
            }
            return View(toView);
        }
    }
}