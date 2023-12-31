﻿namespace Grouplab_Bank
{
    internal static class Utilities
    {

        public static string logo = @"
 _____         _                     _____          _         _      _               ____                 _    
|  __ \       | |                   |  __ \        | |       | |    (_)             |  _ \               | |   
| |  | |  ___ | |__   _   _   __ _  | |  | |  ___  | | _ __  | |__   _  _ __   ___  | |_) |  __ _  _ __  | | __
| |  | | / _ \| '_ \ | | | | / _` | | |  | | / _ \ | || '_ \ | '_ \ | || '_ \ / __| |  _ <  / _` || '_ \ | |/ /
| |__| ||  __/| |_) || |_| || (_| | | |__| || (_) || || |_) || | | || || | | |\__ \ | |_) || (_| || | | ||   < 
|_____/  \___||_.__/  \__,_| \__, | |_____/  \___/ |_|| .__/ |_| |_||_||_| |_||___/ |____/  \__,_||_| |_||_|\_\
                              __/ |                   | |                                                      
                             |___/                    |_|                                                      
";

        public static void DisplayLogo()
        {
            Console.Clear();
            Console.Write("\u001b[33m");
            Console.Title = "Debug Dolphins Bank";
            Console.WriteLine(logo);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\u001b[34m");

        }
        public static List<ExchangeRate> rates = new List<ExchangeRate>()
        {
            new ExchangeRate(Currencies.Sek, 1),
            new ExchangeRate(Currencies.Euro, 11.42),
            new ExchangeRate(Currencies.UsDollar, 10.47)
        };
    }
}
