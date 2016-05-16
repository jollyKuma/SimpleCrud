using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstApproach.Models
{
    public class StudentContext: DbContext
    {
        public StudentContext()
            : base("name=DBConnectionString")
        {

        }
        public DbSet<Student> students { get; set; }    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(b => b.ID);
            modelBuilder.Entity<Student>().Property(b => b.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            base.OnModelCreating(modelBuilder);
        }
    }
}