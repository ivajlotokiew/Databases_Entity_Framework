namespace StudentSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<StudentSystem.Data.StudentContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(StudentContext context)
        {
            if (context.Students.Any())
            {
                return;
            }

            context.Students.AddOrUpdate(new Student
            {
                Name = "Fasko",
                Birthday = new DateTime(1991, 2, 11),
                PhoneNumber = "0888888888",
                RegistrationDate = new DateTime(2011, 6, 10),
            });

            var student = context.Students;

            context.Courses.AddOrUpdate(new Course
            {
                Description = "Course for best IT practices",
                Name = "IT Technologie",
                Price = 155.55m,
                StartDate = new DateTime(2011, 2, 11),
                EndDate = new DateTime(2011, 4, 11),
            });

            context.SaveChanges();

            context.Resources.AddOrUpdate(new Resource
            {
                Name = "This resource",
                URL = "www.softuni.bg",
                TypeOfResource = "This type",
                Course = context.Courses.FirstOrDefault(x => x.CourseId == 1)
            });

            context.SaveChanges();
        }
    }
}
