namespace StudentSystem.ConsoleClient
{
    using StudentSystem.Data;
    using System.Linq;
    using StudentSystem.Models;
    using System;

    public class Startup
    {
        static void Main()
        {
            var context = new StudentContext();
            context.Courses.Count();
        }
    }
}

