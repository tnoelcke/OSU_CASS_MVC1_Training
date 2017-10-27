using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCTraining.Models
{
    public class Class
    {
        //keeps track of a unique id. Useful later when binding data
        // and trying to query data.
        public int ID { get; set; }
        //Two lets and three digits that identifies what the class is ie: CS 325
        public string identifier { get; set; }
        //The course name
        public string courseName { get; set; }
        //who is teaching the class.
        public string instructor { get; set; }
    }
}