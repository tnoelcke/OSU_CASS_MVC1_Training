using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTrainingBlank.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double gpa { get; set; }
        public IEnumerable<ClassViewModel> Classes { get; set;}

    }
}