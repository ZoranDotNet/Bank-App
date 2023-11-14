using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grouplab_Bank
{
    public static class Menu
    {
        internal static void MainMenu(User user)
        {
            Utilitys.DiplayLogo();
            int option = BankMenu("Bank accounts info", "Pay & Transfer", "Loan", "Add user", "Log out");

            switch (option)
            {

                case 1:
                    Utilitys.DiplayLogo();
                    Console.WriteLine($"Bank accounts\u001b[34m");
                    option = BankMenu("Balance", "Transaction", "Open a new account", "Go back to main menu");
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

                case 2:
                    Utilitys.DiplayLogo();
                    Console.WriteLine("Pay & Transfer\u001b[34m");
                    option = BankMenu("Pay","Transfer","Deposit","Withdraw");
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
                    Utilitys.DiplayLogo();
                    Console.WriteLine("Loan");
                    break;
                case 4:
                    Utilitys.DiplayLogo();
                    Console.WriteLine("Add user");
                    break;

                case 5:
                    Utilitys.DiplayLogo();
                    Console.WriteLine("Goodbye, you will now be logged out ");
                    break;

            }
        }

        public static int BankMenu(string option1, string option2, string option3, string option4, string option5)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("Please make a choice\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[34m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[34m");
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}3 {option3}\u001b[34m");
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}4 {option4}\u001b[34m");
                Console.WriteLine($"{(option == 5 ? decorator : "  ")}5 {option5}\u001b[34m");

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
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("Please make a choice\n ");
            (int left, int top) = Console.GetCursorPosition();
            int option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : "  ")}1 {option1}\u001b[34m");
                Console.WriteLine($"{(option == 2 ? decorator : "  ")}2 {option2}\u001b[34m");
                Console.WriteLine($"{(option == 3 ? decorator : "  ")}3 {option3}\u001b[34m");
                Console.WriteLine($"{(option == 4 ? decorator : "  ")}4 {option4}\u001b[34m");

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
