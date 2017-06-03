namespace Sales.ConsoleClient
{
    using Data;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            var context = new SalesContext();

            context.Products.Count();
        }
    }
}
