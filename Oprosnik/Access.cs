using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprosnik
{
    public class Access
    {
        public static bool AccessCheck()
        {
            Console.Clear();
            ConsoleKeyInfo key;
            Console.WriteLine("Для того, чтобы вернуться назад нажмите клавишу Esc");
            Console.WriteLine("Введите пароль:");
            do
            {
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return false;
                }
                string password = Console.ReadLine();
                if (password == "000")
                {
                    return true;        
                }
                else
                {
                    Console.WriteLine("Пароль неверный!");
                }
            } while (key.Key != ConsoleKey.Escape);
            if (key.Key == ConsoleKey.Escape)
            {
                return false;
            }
            return true;
        }
    }
}
