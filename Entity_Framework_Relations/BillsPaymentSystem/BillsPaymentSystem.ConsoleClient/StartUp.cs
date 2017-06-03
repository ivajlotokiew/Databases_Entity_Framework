namespace BillsPaymentSystem.ConsoleClient
{
    using Models;
    using Data;
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            var context = new BillsPaymentSystemContext();

            //User user = context.Users.FirstOrDefault(n => n.LastName == "Prodanov");

            //user.BillingDetails = new CreditCard
            //{
            //    Number = "122555",
            //    CardType = "White",
            //};

            var newBill = new CreditCard
            {
                Number = "122555",
                CardType = "White",
                Owner = context.Users.FirstOrDefault(n => n.LastName == "Prodanov"),
            };

            context.BillingDetails
            context.SaveChanges();
        }
    }
}
