using System.Text;

namespace Grouplab_Bank
{
    public static class Menu
    {
        internal static void MainMenu(User user)
        {
            Utilitys.DisplayLogo();
            int option = BankMenu("Account info", "Transactions", "Loan", "Administration", "Log out");

            switch (option)
            {

                case 1:
                    Utilitys.DisplayLogo();
                    Console.WriteLine($"\u001b[34mBank accounts");
                    option = BankMenu("Balance", "Account Info", "Transaction History", "Open New Account");
                    switch (option)
                    {
                        case 1:
                            //Balance
                            break;
                        case 2://AccountInfo
                            break;
                        case 3://Transaction History

                            break;
                        case 4:
                            Utilitys.DisplayLogo();
                            BankAccount account = new BankAccount();
                            account.AddAccount(user);
                            MainMenu(user);
                            break;
                    }
                    break;

                case 2:
                    Utilitys.DisplayLogo();
                    Console.WriteLine("\u001b[34mTransactions");
                    option = BankMenu("Deposit", "Withdraw", "Transfer", "Back To Main Menu");
                    switch (option)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;

                case 3:
                    Utilitys.DisplayLogo();
                    Console.WriteLine("\u001b[34mLoan");

                    break;
                case 4:
                    Utilitys.DisplayLogo();
                    Console.WriteLine("\u001b[34mAdministration");
                    option = BankMenu("Add new User", "Set Exchange Rate", " ", "Back To Main Menu");
                    switch (option)
                    {
                        case 1:
                            Bank b = new Bank();
                            b.AddUser(user);
                            MainMenu(user);
                            break;

                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;


                case 5:
                    Utilitys.DisplayLogo();
                    Console.WriteLine("Goodbye, you will now be logged out ");
                    break;

            }
        }

        public static int BankMenu(string option1, string option2, string option3, string option4, string option5)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\n\u001b[34mUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[34m to select:");
            Console.WriteLine("\u001b[34mPlease make a choice\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}\u001b[34m");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}\u001b[34m");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}\u001b[34m");
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}4 {option4}\u001b[34m");
                Console.WriteLine($"{(option == 5 ? decorator : "   ")}5 {option5}\u001b[34m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 5 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 5 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"\n{decorator}You selected {option}");
            return option;
        }
        public static int BankMenu(string option1, string option2, string option3, string option4)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[34m to select:");
            Console.WriteLine("\u001b[34mPlease make a choice\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "   ")}1 {option1}\u001b[34m");
                Console.WriteLine($"{(option == 2 ? decorator : "   ")}2 {option2}\u001b[34m");
                Console.WriteLine($"{(option == 3 ? decorator : "   ")}3 {option3}\u001b[34m");
                Console.WriteLine($"{(option == 4 ? decorator : "   ")}4 {option4}\u001b[34m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 4 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 4 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"\n{decorator}You selected {option}");
            return option;
        }
    }
}
