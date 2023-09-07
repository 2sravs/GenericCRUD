using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericCRUDOp.Models
{
    public class GenericDBContext : DbContext
    {
        public GenericDBContext()
           : base("School1Entities")
        {
        }

        public ISet<Student1> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}

