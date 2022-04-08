using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprosnik
{
    internal class EnterProgram
    {
        public static void Enter()
        {
            Console.Clear();
            Console.WriteLine("Здравствуйте! Нажмите цифру в соответствии с желаемым действием");
            Console.WriteLine("1 - Пройти опрос");
            Console.WriteLine("2 - Редактировать опросы");
            ConsoleKeyInfo key;
        Again:
            Console.Write("\b");
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                Console.Write("\b");
                QuizTaking.Taking();
                EnterProgram.Enter();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Write("\b");
                Access access = new Access();
                if (Access.AccessCheck())
                {
                    AdminNavigation.ANavigation();
                }
                else
                {
                    EnterProgram.Enter();
                }
            }
            else
            {
                goto Again;
            }
            Console.ReadKey();
        }
    }
}
