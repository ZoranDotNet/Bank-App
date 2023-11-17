﻿using System.Security.Cryptography.X509Certificates;

namespace Grouplab_Bank
{
    internal partial class User
    {
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public bool Admin { get; set; } = false;
        public int FailedLogin { get; set; } = 0;
        public bool IsLocked { get; set; } = false;
        public List<BankAccount>? BankAccounts { get; set; }


        public User()
        {

        }

        public User(string name, string username, string password)
        {
            Name = name;
            Username = username;
            Password = password;
            BankAccounts = new List<BankAccount>();
        }

        public User(string name, string username, string password, bool admin)
        {
            Name = name;
            Username = username;
            Password = password;
            Admin = admin;
            BankAccounts = new List<BankAccount>();
        }

        private decimal CalculateInterest(double interestRate, decimal amount)
        {
            decimal interestToPay = amount * Convert.ToDecimal(interestRate) / 100;
            return interestToPay;
        }
        public void MakeDeposit(User user)
        {
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("\nYou have no BankAccount ");
                Console.ReadKey();
                return;
            }

            Utilities.DisplayLogo();
            Console.Write("\nWich Account do you want to make your Deposit To\n\n");
            BankAccount selectedAccount = Menu.SelectAccount(user);
            Utilities.DisplayLogo();
            Console.WriteLine("\nHow much do you want to Deposit");
            decimal depositAmount;
            while (!decimal.TryParse(Console.ReadLine(), out depositAmount))
            {
                Console.WriteLine("Try again...");
            }

            if (selectedAccount.InterestRate > 0)
            {
                decimal interestToPay = CalculateInterest(selectedAccount.InterestRate, depositAmount);
                Console.WriteLine($"The interest on your Savings Account will be {interestToPay} {selectedAccount.Currency} / year");
                Console.ReadKey();
            }

            if (selectedAccount != null)
            {
                selectedAccount.Balance += depositAmount;
            }
            else
            {
                Console.WriteLine("Could not find Account");
                Console.ReadKey();
            }
        }
        public void GetAccountInfo(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("You have no BankAccount");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("******************************************************************************");
                Console.WriteLine("* AccountNr **    Balance     **  Currency  **  Interest %  **    Owner      *");
                Console.WriteLine("******************************************************************************");
                foreach (var item in user.BankAccounts)
                {
                    Console.WriteLine($"*  {item.AccountNumber,-8} **  {item.Balance.ToString("N2"),-13} **    {item.Currency,-7} **       {item.InterestRate,-6} **  {item.Owner.Name,-10}   *");
                    Console.WriteLine("******************************************************************************");
                }

                Console.ReadKey();
            }
        }
        //needs work
        public void MakeTransfer(User user)
        {
            Console.WriteLine("1 for Transfer to your own Account");
            Console.WriteLine("2 for Transfer to someone elses Account");
            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                if (user.BankAccounts.Count < 2)
                {
                    Console.WriteLine("\nYou need at least 2 Accounts to make a Transfer");
                    Console.ReadKey();
                    return;
                }
                ListAllBankAccounts(user);

                Console.WriteLine("\n\nWich Account do you want to Transfer From ");
                string accountNrFrom = Console.ReadLine();
                Console.WriteLine("Wich Account do you want to Transfer To ");
                string accountNrTo = Console.ReadLine();
                Console.WriteLine("How much do You want to Transfer ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount))
                {
                    Console.Write("Try again.. ");
                }
                //finding users Account to Transfer from
                var accountFrom = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrFrom);
                // finding users Account to Transfer to
                var accountTo = user.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrTo);

                //if we find both accounts we proceed otherwisw back to menu
                if (accountFrom != null && accountTo != null)
                {
                    if (accountFrom.Balance >= amount)
                    {
                        accountFrom.Balance -= amount;

                        accountTo.Balance += amount;
                    }
                    else
                    {
                        Console.WriteLine("You do not have sufficient funds in your account");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Could not find your account ");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid choice ");
                Console.ReadKey();
            }
        }
        //needs work
        public void MakeExternalTransfer(User userFrom, User userTo, string account)
        {
            ListAllBankAccounts(userFrom);

            Console.WriteLine("\n\nWich Account do you want to Transfer From ");
            string accountNrFrom = Console.ReadLine();
            Console.WriteLine("Wich Account do you want to Transfer To ");
            string accountNrTo = Console.ReadLine();
            Console.WriteLine("How much do You want to Transfer ");
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Try again.. ");
            }

            //finding users Account to Transfer from
            var accountFrom = userFrom.BankAccounts.FirstOrDefault(x => x.AccountNumber == accountNrFrom);


            Console.WriteLine("Wich AccounNumber do you want to Trasfer To");
            string accountNr = Console.ReadLine();

            // needs to make a method to find AccountNr that matches another user

        }
        public void GetBalance(User user)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (user.BankAccounts.Count == 0)
            {
                Console.WriteLine("You have no BankAccount");
                Console.ReadKey();
            }
            else
            {
                decimal total = 0;
                foreach (var item in user.BankAccounts)
                {
                    total += item.Balance;
                    Console.WriteLine($"*  {item.AccountNumber,-8} * {item.Balance.ToString("N2"),-13} * {item.Currency,-4} * ");
                    Console.WriteLine("******************************************************************************");
                }
                Console.ReadKey();
            }
        }
    }
}
