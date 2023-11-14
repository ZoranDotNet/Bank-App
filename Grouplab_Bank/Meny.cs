using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouplab_Bank
{
    internal class Menu
    {
        static void Menu1()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Console.WriteLine("\nUse ⬆️ and ⬇️ to navigate and press \u001b[32mEnter / Return\u001b[0m to select:");
            Console.WriteLine("Please make a choice\n ");
            (int left, int top) = Console.GetCursorPosition();
            var option = 1;
            var decorator = "✅ \u001b[32m";
            ConsoleKeyInfo key;
            bool isSelected = false;
            while (!isSelected)
            {
                Console.SetCursorPosition(left, top);
                Console.WriteLine($"{(option == 1 ? decorator : " ")}1 Bank accounts info\u001b[34m");
                Console.WriteLine($"{(option == 2 ? decorator : " ")}2 Pay & Transfer\u001b[34m");
                Console.WriteLine($"{(option == 3 ? decorator : " ")}3 Loan\u001b[34m");
                Console.WriteLine($"{(option == 4 ? decorator : " ")}4 Add user\u001b[34m");
                Console.WriteLine($"{(option == 5 ? decorator : " ")}5 Log out\u001b[34m");

                key = Console.ReadKey(false);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        option = option == 1 ? 7 : option - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        option = option == 7 ? 1 : option + 1;
                        break;
                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;
                }

            }
            Console.WriteLine($"\n{decorator}You selected {option}");




            switch (option)
            {

                case 1:
                    Console.WriteLine($"Bank accounts\u001b[34m");
                    Console.WriteLine($"1. Balance\u001b[34m");
                    Console.WriteLine($"2. Transaction\u001b[34m");
                    Console.WriteLine($"3. Open a new account\u001b[34m");
                    Console.WriteLine($"4. Go back to main menu\u001b[34m");


                    //string bankOption = Console.ReadLine();

                    break;

                case 2:
                    Console.WriteLine("Pay & Transfer\u001b[34m");
                    Console.WriteLine("1. Pay\u001b[34m");
                    Console.WriteLine("2. Transfer\u001b[34m");
                    Console.WriteLine("3. Deposit\u001b[34m");
                    Console.WriteLine("4. Withdraw\u001b[34m");
                    break;

                case 3:
                    Console.WriteLine("Loan");
                    break;
                case 4:
                    Console.WriteLine("Add user");
                    break;

                case 5:
                    Console.WriteLine("Goodbye, you will now be logged out ");
                    break;

            }

        }

    }
}
