namespace UserDB.ConsoleClient
{
    using Models;
    using Data;
    using System;
    using System.Linq;
    using System.Data.Entity;

    public class Startup
    {
        public static void Main()
        {
            var context = new UserContext();
            //var user = new User
            //{
            //    Username = "IvaskoMladenov",
            //    FirstName = "Ivan",
            //    LastName = "Savov",
            //    Age = 22,
            //    Email = "petko@abv.bg",
            //    Password = "d3k_KSD2?df",
            //    Town = new Town
            //    {
            //        Name = "Manchester",

            //    }
            //};

            //context.Users.Add(user);

            //try
            //{
            //    context.SaveChanges();
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}

            context.Users.Count();
        }
    }
}
