using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCTraining.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCTraining.DAL
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("StudentContext")
        {
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}