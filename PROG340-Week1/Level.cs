using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG340_Week1.Utility;

namespace PROG340_Week1
{
    public class Level
    {
        public string ASCIIArt { get; set; }

        public string Question { get; set; }
        public string[] Answers { get; set; }
        public string[] Responses { get; set; }
        public int TrueAnswer { get; set; }

        public bool Completed { get; set; }

        public Level() { }
        public void Loop()
        {
            int answer = Question(Question, Answers);

            ConsoleSpacer();

            if (answer == TrueAnswer) 
            {
                Print(Responses[answer], true, ConsoleColor.Blue);
            }
            else
            {
                Print(Responses[answer], true, ConsoleColor.Magenta);
            }

            if (TrueAnswer == answer)
            {
                Completed = true;
            }
            else
            {
                Completed = false;
            }
        }
    }
}
