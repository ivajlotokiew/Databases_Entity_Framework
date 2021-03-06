namespace StudentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;
    public class StudentContext : DbContext
    {
        public StudentContext()
            : base("name=StudentContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<StudentContext, Configuration>());
        }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Homework> Homeworks { get; set; }

        public virtual DbSet<Resource> Resources { get; set; }

        public virtual DbSet<License> Licenses { get; set; }
    }
}