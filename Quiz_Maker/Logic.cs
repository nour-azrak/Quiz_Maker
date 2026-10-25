using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    internal class Logic
    {
        static Random random = new Random();
        static public List<int> ChooseRandomQuestion (int SizeOfQuestionList)
        {
            // creates uniq
            List<int> numbers = Enumerable.Range(0, SizeOfQuestionList)
                .OrderBy(x => random.Next())
                .Take(10)
                .ToList();

            return numbers;
        }

        //static public void Track
    }
}
