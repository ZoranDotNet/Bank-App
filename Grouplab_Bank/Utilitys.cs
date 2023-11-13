using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grouplab_Bank
{
    internal static class Utilitys
    {
        public static void Logo()
        {
            Console.Title = "ASCII Art";
            string logo = @"
 _____         _                     _____          _         _      _               ____                 _    
|  __ \       | |                   |  __ \        | |       | |    (_)             |  _ \               | |   
| |  | |  ___ | |__   _   _   __ _  | |  | |  ___  | | _ __  | |__   _  _ __   ___  | |_) |  __ _  _ __  | | __
| |  | | / _ \| '_ \ | | | | / _` | | |  | | / _ \ | || '_ \ | '_ \ | || '_ \ / __| |  _ <  / _` || '_ \ | |/ /
| |__| ||  __/| |_) || |_| || (_| | | |__| || (_) || || |_) || | | || || | | |\__ \ | |_) || (_| || | | ||   < 
|_____/  \___||_.__/  \__,_| \__, | |_____/  \___/ |_|| .__/ |_| |_||_||_| |_||___/ |____/  \__,_||_| |_||_|\_\
                              __/ |                   | |                                                      
                             |___/                    |_|                                                      
";

            Console.WriteLine(logo);
            Console.Read();
        }
    }
}
