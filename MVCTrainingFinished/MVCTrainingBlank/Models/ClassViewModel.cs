using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTrainingBlank.Models
{
    public class ClassViewModel
    {
        public int ID { get; set; }
        //holds the designator ex: cs325
        public string Designator { get; set; }
        public string ClassName { get; set; }
        public int numberOfCredits { get; set; }
        public string Instructor { get; set; }
    }
}