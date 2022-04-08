using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Oprosnik
{
    class QuizActions
    {
        public void AddQuiz()
        {
            Quiz quiz = new Quiz();
            Console.WriteLine("Введите название опроса");
            quiz.Name = Console.ReadLine();
            Console.WriteLine("Введите количество ответов (1-4):");
            int count = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите развернуто вопрос:");
            quiz.Question = Console.ReadLine();
            Console.WriteLine("Введите возможные варианты ответа (каждая новая строка - новый ответ):");
            quiz.AnswersInfo = new List<AnswerInfo>();
            for (int i = 1; i < count + 1; i++)
            {
                quiz.AnswersInfo.Add(
                    new AnswerInfo
                    {
                        Answer = Console.ReadLine(),
                        AnswerNumber = i,
                        AnswerCount = 0
                    });
            }
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
            var convertedJson = JsonConvert.SerializeObject(quiz, Formatting.Indented);
            string path = (@"results.json");
            StreamReader sr = new StreamReader(path);
            var temp = sr.ReadToEnd();
            sr.Close();
            if (temp != null && temp != "" && temp != "\n" && temp.Length != 0)
            {
                temp = temp.Substring(0, temp.Length - 1);
                temp = temp + ",";
            }
            else
            {
                temp = temp.Insert(0, "[");
            }          
            File.WriteAllText(path, temp);
            File.AppendAllText(path, convertedJson);
            File.AppendAllText(path, ",");
            File.AppendAllText(path, "\n");
            File.AppendAllText(path, "]");
        }

        public void QuizStat()
        {
            Console.Clear();
            ConsoleKeyInfo key;
            Console.WriteLine("Для того, чтобы вернуться назад нажмите клавишу Esc");
            try
            {
                StreamReader sr = new StreamReader(System.IO.File.OpenRead(@"results.json"));
                var docInfo = sr.ReadToEnd();
                sr.Close();
                var obj = JArray.Parse(docInfo);
                var temp = JsonConvert.DeserializeObject<List<Quiz>>(obj.ToString());
                for (int i = 0; i < temp.Count; i++)
                {
                    int number = i + 1;
                    Console.WriteLine("\n");
                    Console.WriteLine($"{number} - {temp[i].Name}");
                    for (int j = 0; j < temp[i].AnswersInfo.Count; j++)
                    {
                        Console.WriteLine($"  {temp[i].AnswersInfo[j].AnswerNumber}. {temp[i].AnswersInfo[j].Answer} - {temp[i].AnswersInfo[j].AnswerCount}");
                    }
                }
            }
            catch
            {
                Console.WriteLine("Опросов на данный момент нет");
            }
        }
    }
}
