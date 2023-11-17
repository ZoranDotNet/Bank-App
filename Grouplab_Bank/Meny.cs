using System.Text;

namespace Grouplab_Bank
{
    internal static class Menu
    {
        //BankMenu Prints a menu with options selectable via u/down arrowkey and returns an int with the selected option number 
        //to use in a switch. BankMenu has overloads that requires inParameters of 2-6 strings wich in turn becomes the selectable options
        //To call method use -> int x = Menu.BankMenu("option1","option2"(and up to 4 more)); <-
        //then -> switch (x) case 1: do something...
        public static int BankMenu(string option1, string option2, string option3, string option4, string option5, string option6)
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
                Console.WriteLine($"{(option == 6 ? decorator : "   ")}6 {option5}\u001b[34m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 6 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 6 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"\n{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
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
            Console.CursorVisible = true;
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
            Console.CursorVisible = true;
            return option;
        }
        public static int BankMenu(string option1, string option2, string option3)
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

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 3 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 3 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"\n{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }
        public static int BankMenu(string option1, string option2)
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

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 2 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 2 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"\n{decorator}You selected {option}");
            Console.CursorVisible = true;
            return option;
        }
        /*
        Creates a selectable list of accounts using BankMenu overloads.
        Call method with -> BankAccount selectedAccount = Menu.SelectAccount(user); <-
        After checking that List.Count is not 0.
        */
        internal static BankAccount SelectAccount(User user)
        {
            int? count = user.BankAccounts.Count();
            int option = 0;
            BankAccount selectedAccount;
            if (count == 1)
            {
                option = 1;
            }
            else if (count == 2)
            {
                option = BankMenu(user.BankAccounts[0].AccountNumber, user.BankAccounts[1].AccountNumber);
            }
            else if (count == 3)
            {
                option = BankMenu(user.BankAccounts[0].AccountNumber, user.BankAccounts[1].AccountNumber, user.BankAccounts[2].AccountNumber);
            }
            else if (count == 4)
            {
                option = BankMenu(user.BankAccounts[0].AccountNumber, user.BankAccounts[1].AccountNumber, user.BankAccounts[2].AccountNumber, user.BankAccounts[3].AccountNumber);
            }
            else if (count == 5)
            {
                option = BankMenu(user.BankAccounts[0].AccountNumber, user.BankAccounts[1].AccountNumber, user.BankAccounts[2].AccountNumber, user.BankAccounts[3].AccountNumber, user.BankAccounts[4].AccountNumber);
            }

            selectedAccount = user.BankAccounts[option - 1];
            return selectedAccount;
        }
    }
}
