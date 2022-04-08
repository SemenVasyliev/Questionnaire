using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprosnik
{
    public class AdminNavigation
    {
        public static void ANavigation()
        {
            Console.Clear();
            Console.WriteLine("Для того, чтобы вернуться назад нажмите клавишу Esc");
            Console.WriteLine("Выберите желаемое действие:");
            Console.WriteLine("1 - Просмотреть список опросов и статистику");
            Console.WriteLine("2 - Добавить опрос");

            ConsoleKeyInfo key;
        Again:
            Console.Write("\b");
            key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                Console.Write("\b");
                QuizActions quizActions = new QuizActions();
                quizActions.QuizStat();
                Console.ReadKey();
                AdminNavigation.ANavigation();
            }
            else if (key.Key == ConsoleKey.D2)
            {
                Console.Write("\b");
                QuizActions quizActions = new QuizActions();
                quizActions.AddQuiz();
                Console.WriteLine("Опрос добавлен");
                Console.ReadKey();
                AdminNavigation.ANavigation();
            }
            else if (key.Key == ConsoleKey.Escape)
            {
                EnterProgram.Enter();
            }
            else
            {
                goto Again;
            }

        }
    }
}
