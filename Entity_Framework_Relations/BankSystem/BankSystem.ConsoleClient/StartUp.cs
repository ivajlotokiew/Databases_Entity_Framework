namespace BankSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using Models;
    using Data;
    using System.Globalization;

    public class StartUp
    {
        static bool IsUserLogged = false;

        static void Main()
        {
            var context = new BankSystemContext();

            var line = Console.ReadLine();

            while (line != "END")
            {
                var command = line.Split()[0];

                switch (command)
                {
                    case "Login":
                        LoginCommand(line, context);
                        break;
                    case "Logout":
                        LogoutCommand(line, context);
                        break;
                    case "Add":
                        if (line.Split()[1] == "SavingsAccount")
                        {
                            SavingAccountCommand(line, context);
                        }
                        else
                        {
                            CheckingAccountCommand(line, context);
                        }
                        break;
                    case "Register":
                        RegisterCommand(line, context);
                        break;
                    case "ListAccounts":
                        ListAccountsCommand(context);
                        break;
                    case "Deposit":
                        DepositCommand(context, line);
                        break;
                    case "Withdraw":
                        WithdrawCommand(context, line);
                        break;
                    case "DeductFee":
                        DeductFeeCommand(context, line);
                        break;
                    case "AddInterest":
                        AddInterestCommand(context, line);
                        break;
                    default:
                        throw new ArgumentException("There is now such command.");
                }

                line = Console.ReadLine();
            }

            LogoutAllUssersFromSystem(context);
        }

        private static void AddInterestCommand(BankSystemContext context, string line)
        {
            string accountNumber = line.Split()[1];

            var interestRate = context.Accounts
                .OfType<SavingAccount>()
                .FirstOrDefault(x => x.AccountNumber == accountNumber);
            interestRate.AddInterest();

            context.SaveChanges();
        }

        private static void DeductFeeCommand(BankSystemContext context, string line)
        {
            string accountNumber = line.Split()[1];

            var deductFee = context.Accounts
                .OfType<CheckingAccount>()
                .FirstOrDefault(x => x.AccountNumber == accountNumber);
            deductFee.DeductFee();

            context.SaveChanges();
        }

        private static void WithdrawCommand(BankSystemContext context, string line)
        {
            string accountNumber = line.Split()[1];
            decimal money = decimal.Parse(line.Split()[2], CultureInfo.InvariantCulture);

            var withdrawMoney = context.Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            withdrawMoney.Withdraw(money);

            context.SaveChanges();
        }

        private static void DepositCommand(BankSystemContext context, string line)
        {
            string accountNumber = line.Split()[1];
            decimal money = decimal.Parse(line.Split()[2], CultureInfo.InvariantCulture);

            var depositMoney = context.Accounts.FirstOrDefault(x => x.AccountNumber == accountNumber);
            depositMoney.Deposit(money);

            context.SaveChanges();
        }

        private static void LogoutAllUssersFromSystem(BankSystemContext context)
        {
            var logoutAllUsers = context.Users;

            foreach (var logout in logoutAllUsers)
            {
                logout.Login = false;
            }

            context.SaveChanges();
        }

        private static void ListAccountsCommand(BankSystemContext context)
        {
            if (IsUserLogged == false)
            {
                Console.WriteLine("There is no logged user.");
                return;
            }

            var userInfo = context.Users
                .ToList()
                .First(x => x.Login == true)
                .Accounts;

            var sAcc = userInfo.OfType<SavingAccount>().Select(x => new
            {
                x.AccountNumber,
                x.Balance,
                x.InterestRate
            });

            var cAcc = userInfo.OfType<CheckingAccount>().Select(x => new
            {
                x.AccountNumber,
                x.Balance,
                x.Fee
            });

            Console.WriteLine("Saving Accounts:");
            foreach (var item in sAcc)
            {
                Console.WriteLine($"-- {item.AccountNumber} {item.Balance}");
            }
            Console.WriteLine("Checking Accounts:");
            foreach (var item in cAcc)
            {
                Console.WriteLine($"-- {item.AccountNumber} {item.Balance} ");
            }
        }

        private static void CheckingAccountCommand(string line, BankSystemContext context)
        {
            if (IsUserLogged == false)
            {
                Console.WriteLine("There is no logged user.");
                return;
            }

            decimal initialBalance = decimal.Parse(line.Split()[2]);
            double fee = double.Parse(line.Split()[3], CultureInfo.InvariantCulture);

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var accountNumber = new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            Account savingAccount = new CheckingAccount
            {
                Balance = initialBalance,
                Fee = fee,
                AccountNumber = accountNumber
            };

            var loginUser = context.Users.ToList().First(x => x.Login == true);

            loginUser.Accounts.Add(savingAccount);
            context.SaveChanges();
        }

        private static void SavingAccountCommand(string line, BankSystemContext context)
        {
            if (IsUserLogged == false)
            {
                Console.WriteLine("There is no logged user.");
                return;
            }

            decimal initialBalance = decimal.Parse(line.Split()[2]);
            double interestRate = double.Parse(line.Split()[3], CultureInfo.InvariantCulture);

            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var accountNumber = new string(Enumerable.Repeat(chars, 10)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            Account savingAccount = new SavingAccount
            {
                Balance = initialBalance,
                InterestRate = interestRate,
                AccountNumber = accountNumber
            };

            var loginUser = context.Users.ToList().First(x => x.Login == true);

            loginUser.Accounts.Add(savingAccount);
            context.SaveChanges();
        }

        private static void RegisterCommand(string line, BankSystemContext context)
        {
            var username = line.Split()[1];
            var password = line.Split()[2];
            var email = line.Split()[3];

            var user = new User
            {
                Username = username,
                Password = password,
                Email = email
            };

            context.Users.Add(user);
            try
            {
                context.SaveChanges();
            }

            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var failure in ex.EntityValidationErrors)
                {
                    foreach (var error in failure.ValidationErrors)
                    {
                        Console.WriteLine(error.ErrorMessage);
                        return;
                    }
                }
            }

            Console.WriteLine($"{username} was registered in the system");
        }

        private static void LoginCommand(string line, BankSystemContext context)
        {
            var username = line.Split()[1];
            var password = line.Split()[2];

            var loginUser = context.Users
                .FirstOrDefault(x => x.Username == username && x.Password == password);

            if (loginUser != null)
            {
                Console.WriteLine($"Succesfully logged in {username}");
                loginUser.Login = true;
                IsUserLogged = true;
                return;
            }

            Console.WriteLine("Incorrect username / password");
        }

        private static void LogoutCommand(string line, BankSystemContext context)
        {
            if (IsUserLogged == false)
            {
                Console.WriteLine("Cannot log out. No user was logged in.");
                return;
            }

            var loggedUser = context.Users.ToList();

            foreach (var user in loggedUser)
            {
                if (user.Login == true)
                {
                    Console.WriteLine($"User {user.Username} successfully logged out");
                    user.Login = false;
                    IsUserLogged = false;
                }
            }
        }
    }
}