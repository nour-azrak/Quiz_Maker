using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    internal class Logic
    {
        static Random random = new Random();
        static public int ChooseRandomQuestion (int SizeOfQuestionList)
        {
            int number = random.Next(1, SizeOfQuestionList+1);

            return number;
        }

        //static public void Track
    }
}
