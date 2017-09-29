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

            
        }
    }
}