using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTraining.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Class> ClastList { get; set; }

    }
}