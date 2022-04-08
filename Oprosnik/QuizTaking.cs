using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprosnik
{
    internal class QuizTaking
    {
        public static void Taking()
        {
            Console.Clear();
            ConsoleKeyInfo key;
            Console.WriteLine("Для того, чтобы вернуться назад нажмите клавишу Esc");
            StreamReader sr = new StreamReader(System.IO.File.OpenRead(@"results.json"));
            try
            {
                var docInfo = sr.ReadToEnd();
                sr.Close();
                var obj = JArray.Parse(docInfo);
                var temp = JsonConvert.DeserializeObject<List<Quiz>>(obj.ToString());
                Console.WriteLine("Выберите опрос из списка и введите соответствующую цифру. После чего нажмите Enter");
                for (int i = 0; i < temp.Count; i++)
                {
                    int number = i + 1;
                    Console.WriteLine($"{number} - {temp[i].Name}");
                }
                int consoleNum = Convert.ToInt32(Console.ReadLine());
                consoleNum = consoleNum - 1;
                try
                {
                    Console.WriteLine(temp[consoleNum].Question);
                    for (int i = 0; i < temp[consoleNum].AnswersInfo.Count; i++)
                    {
                        int number = i + 1;
                        Console.WriteLine($"{number}. {temp[consoleNum].AnswersInfo[i].Answer}");
                    }
                    Again:
                    Console.Write("\b");
                    key = Console.ReadKey();
                    try
                    {
                        switch (key.Key)
                        {
                            case ConsoleKey.Escape:
                                EnterProgram.Enter();
                                break;
                            case ConsoleKey.D1:
                                Console.Write("\b");
                                temp[consoleNum].AnswersInfo[0].AnswerCount++;
                                Console.WriteLine(" Ответ записан");
                                break;
                            case ConsoleKey.D2:
                                Console.Write("\b");
                                temp[consoleNum].AnswersInfo[1].AnswerCount++;
                                Console.WriteLine(" Ответ записан");
                                break;
                            case ConsoleKey.D3:
                                Console.Write("\b");
                                temp[consoleNum].AnswersInfo[2].AnswerCount++;
                                Console.WriteLine(" Ответ записан");                   
                                break;
                            case ConsoleKey.D4:
                                Console.Write("\b");
                                temp[consoleNum].AnswersInfo[3].AnswerCount++;
                                Console.WriteLine(" Ответ записан");
                                break;
                            default:
                                goto Again;
                        }
                        var convertedJson = JsonConvert.SerializeObject(temp, Formatting.Indented);
                        File.WriteAllText(@"results.json", convertedJson);
                    }
                    catch
                    {
                        Console.WriteLine("Нажмите существующую цифру с ответом");
                        goto Again;
                    }
                    sr.Close();
                    Console.ReadKey();
                }
                catch
                {
                    Console.WriteLine("Введите номер существующего опроса");
                    QuizTaking.Taking();
                }
            }
            catch
            {
                sr.Close();
                Console.WriteLine("На данный момент опросов нет");
                key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    return;
                }
                else
                {
                    QuizTaking.Taking();
                }
            }
        }
    }
}
