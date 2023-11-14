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
                var User = new User(addName, addUserName, addPassword);
                Users.Add(user);
            }
            else
            {
                Console.WriteLine("You have to be Admin to create new users");
            }
        }

        public void Run()
        {
            User LoggedUser=Login();
            
        }
        public User Login()
        {
            bool loggedIn = false;
            User LoggedUser=new User();
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Dolphin Bank" +
                    "\n\nLogin\n");
                Console.Write("User Name: ");
                var userNameInput=Console.ReadLine();
                bool exists = Users.Exists(e => e.Username == userNameInput);
                if (exists)
                {
                    LoggedUser = Users.Find(e => e.Username == userNameInput);
                    if (LoggedUser.FailedLogin >= 3)
                    {
                        Console.WriteLine("Account Locked!\nContact customer support");
                        LoggedUser.IsLocked = true;
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"User Name: {LoggedUser.Username}\n\n");
                        Console.Write("Password: ");
                        var userPasswordInput = Console.ReadLine();
                        if (LoggedUser.Password != userPasswordInput)
                        {
                            LoggedUser.FailedLogin++;
                            Console.Clear();
                            Console.WriteLine("Loggin failed!");
                            Console.WriteLine($"You have {3 - LoggedUser.FailedLogin} attempts left");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.Clear();
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
