using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    internal class UI
    {
        static public void GetQuestion(out Question inputQuestion)
        {
            inputQuestion = null;
            Console.WriteLine("Please input Question:");

            inputQuestion.questionBody = Console.ReadLine();
            
            Console.WriteLine("Please input first answer:");
            inputQuestion.answer1 = Console.ReadLine();
        }
    }
}
