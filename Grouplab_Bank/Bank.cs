namespace Grouplab_Bank
{
    internal class Bank
    {
        public List<User> Users { get; set; }

        public Bank()
        {
            Users = new List<User>();

            var user = new User("Reidar", "admin", "123", true);
            Users.Add(user);
        }
        internal bool MainMenu(User user)
        {
            bool RunMenu = true;
            bool displayMain = true;
            bool displaySub = true;
            do
            {
                Utilities.DisplayLogo();
                int option = Menu.BankMenu("Account info", "Transactions", "Loan", "Administration", "Log out");

                switch (option)
                {

                    case 1:
                        do
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine($"\u001b[34mBank accounts");
                            option = Menu.BankMenu("Balance", "Account Info", "Transaction History", "Open New Account", "Return to Main Menu");
                            switch (option)
                            {
                                case 1:
                                    Utilities.DisplayLogo();
                                    user.GetBalance(user);
                                    break;
                                case 2:
                                    Utilities.DisplayLogo();
                                    user.GetAccountInfo(user);
                                    break;
                                case 3:
                                    Utilities.DisplayLogo();
                                    user.GetTransactionHistory(user);
                                    break;
                                case 4:
                                    Utilities.DisplayLogo();
                                    BankAccount account = new BankAccount();
                                    account.AddAccount(user);
                                    if (account != null)
                                    {
                                        user.BankAccounts.Add(account);
                                        user.AddTransaction(account, TransactionType.New_Account, 0);
                                    }
                                    break;
                                case 5:
                                    displaySub = false;
                                    break;
                            }
                        } while (displaySub == true);
                        break;

                    case 2:
                        do
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("\u001b[34mTransactions");
                            option = Menu.BankMenu("Deposit", "Withdraw", "Transfer", "External Transfer", "Back To Main Menu");
                            switch (option)
                            {
                                case 1:
                                    Utilities.DisplayLogo();
                                    user.MakeDeposit(user);
                                    break;
                                case 2:
                                    Utilities.DisplayLogo();
                                    user.MakeWithdraw(user);
                                    //Move Method to user and call with ^
                                    break;
                                case 3:
                                    Utilities.DisplayLogo();
                                    user.MakeTransfer(user);
                                    break;
                                case 4:
                                    Utilities.DisplayLogo();
                                    Console.WriteLine("Wich AccountNumber do you want to transfer To ");
                                    string input = Console.ReadLine();
                                    User newuser = GetUserByBankAccount(input);
                                    Utilities.DisplayLogo();
                                    user.MakeExternalTransfer(user, newuser, input);
                                    break;
                                case 5:
                                    displaySub = false;
                                    break;
                            }
                        } while (displaySub == true);
                        break;

                    case 3:
                        Utilities.DisplayLogo();
                        Console.WriteLine("\u001b[34mLoan");

                        break;
                    case 4:
                        do
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine("\u001b[34mAdministration");
                            option = Menu.BankMenu("Add new User", "Set Exchange Rate", " ", "Back To Main Menu");
                            switch (option)
                            {
                                case 1:
                                    AddUser(user);
                                    break;

                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    displaySub = false;
                                    break;
                            }
                        } while (displaySub == true);
                        break;


                    case 5:
                        Utilities.DisplayLogo();
                        option = Menu.BankMenu("Return To Login", "Exit");
                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Goodbye, you will now be logged out ");
                                Console.ReadKey();
                                displayMain = false;
                                break;
                            case 2:
                                Console.WriteLine("Goodbye, closing program");
                                Console.ReadKey();
                                RunMenu = false;
                                displayMain = false;
                                break;
                        }
                        break;

                }
            } while (displayMain == true);
            return RunMenu;
        }

        public void AddUser(User user)
        {
            if (user.Admin == true)
            {

                Console.WriteLine("Name: ");
                string addName = Console.ReadLine();
                Console.WriteLine("Username: ");
                string addUserName = Console.ReadLine();
                Console.WriteLine("Password: ");
                string addPassword = Console.ReadLine();
                var newuser = new User(addName, addUserName, addPassword);
                Users.Add(newuser);
            }
            else
            {
                Console.WriteLine("You have to be Admin to create new users");
                Console.ReadKey();
            }
        }
        public User GetUserByBankAccount(string accountNr)
        {
            foreach (var user in Users)
            {
                foreach (var item in user.BankAccounts)
                {
                    if (accountNr == item.AccountNumber)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public void Run()
        {
            bool runMenu;
            do
            {
                User LoggedUser = Login();
                runMenu = MainMenu(LoggedUser);
            } while (runMenu == true);
        }
        public User Login()
        {
            bool loggedIn = false;
            User LoggedUser = new User();
            do
            {
                Utilities.DisplayLogo();
                Console.WriteLine("\u001b[34mWelcome to Debug Dolphins Bank" +
                    "\n\nLogin\n");
                Console.Write("\u001b[32mUser Name: \x1b[7m");
                var userNameInput = Console.ReadLine();
                Console.Write("\x1b[27m");
                bool exists = Users.Exists(e => e.Username == userNameInput);
                if (exists)
                {
                    LoggedUser = Users.Find(e => e.Username == userNameInput);
                    if (LoggedUser.FailedLogin >= 3)
                    {
                        Console.WriteLine("\x1b[91mAccount Locked!\nContact customer support");
                        LoggedUser.IsLocked = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        Utilities.DisplayLogo();
                        Console.WriteLine($"\u001b[34mUser Name: {LoggedUser.Username}\n\n");
                        Console.Write("\u001b[32mPassword: \u001b[7m");
                        var userPasswordInput = Console.ReadLine();
                        Console.Write("\x1b[27m");
                        if (LoggedUser.Password != userPasswordInput)
                        {
                            LoggedUser.FailedLogin++;
                            Utilities.DisplayLogo();
                            Console.WriteLine("\x1b[91mLoggin failed!");
                            Console.WriteLine($"You have {3 - LoggedUser.FailedLogin} attempts left");
                            Console.ReadKey();
                        }
                        else
                        {
                            Utilities.DisplayLogo();
                            Console.WriteLine($"\nWelcome {LoggedUser.Name}!");
                            LoggedUser.FailedLogin = 0;
                            Console.ReadKey();
                            loggedIn = true;
                        }
                    }
                }
            } while (!loggedIn);

            return LoggedUser;
        }

    }
}
