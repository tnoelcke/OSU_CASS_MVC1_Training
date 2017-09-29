using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCTraining.Models;

namespace MVCTraining.DAL
{
    public class StudentInitializer : System.Data.Entity.DropCreateDatabaseAlways<StudentContext>
    {
        protected override void Seed(StudentContext context)
        {
            var classes = new List<Class>
            {
                new Class {ID = 1, courseName = "Introduction To Computer Science", identifier = "CS101", instructor = "Bob the AppBuilder"},
                new Class {ID = 2, courseName = "Analysis of Algorithms", identifier = "CS325", instructor = "Al Gore"},
                new Class {ID = 3, courseName = "Intro to Bussiness", identifier = "BS101", instructor = "Generic Buissnessman"},
                new Class {ID = 4, courseName = "Opperating Systems 2", identifier = "CS444", instructor = "Linus Torvalds"},
                new Class {ID = 5, courseName = "Senior Cap Stone", identifier = "CS 461", instructor = "Generic ComputerScience Instructor" },
                new Class {ID = 6, courseName = "Intro To Writing", identifier = "WR121" },
                new Class {ID = 7, courseName = "PHD Thesis", identifier = "CS700", instructor = "Who Wants to teach this class?" }
            };

            classes.ForEach(c => context.Classes.Add(c));
            context.SaveChanges();


            var CsSenior = new List<Class>();
            var Freshman = new List<Class>();
            var PHD = new List<Class>();

            CsSenior.AddRange(classes.FindAll(c => c.ID == 2 || c.ID == 4 || c.ID == 5));
            Freshman.AddRange(classes.FindAll(c => c.ID == 1 || c.ID == 3 || c.ID == 6));
            PHD.Add(classes.Find(c => c.ID == 7));

            var students = new List<Student>()
            {
                new Student {ID = 1, FirstName = "Generic", LastName = "Freshmen", Address = "Some Doorm on Campus", ClassList = Freshman },
                new Student {ID = 2, FirstName = "Generic", LastName = "LastName", Address = "Some Appartment Near Campus", ClassList = CsSenior},
                new Student {ID = 3, FirstName = "PHD", LastName = "Student", Address = "Some where with in 30 miles", ClassList = PHD }
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            
        }
    }
}