using System.Security.Principal;

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
        public User? GetUser(string accountNr)
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
                runMenu=Menu.MainMenu(LoggedUser);
            } while (runMenu==true);
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
