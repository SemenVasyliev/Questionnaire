using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oprosnik
{
    internal class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public List<AnswerInfo> AnswersInfo { get; set; }

    }
    internal class AnswerInfo
    {
        public int AnswerNumber { get; set; }
        public string Answer { get; set; }
        public int AnswerCount { get; set; }
    }
}
