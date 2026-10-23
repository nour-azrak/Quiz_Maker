using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    internal class UI
    {
        /// <summary>
        /// Checks whether the user wants to keep inputting questions
        /// </summary>
        /// <returns></returns>
        static public bool UserWantsToInputNextQuestion(bool firstLoop)
        {
            if (firstLoop) return true;
            Console.WriteLine("If you want to keep entering questions please input [y]. If not please enter [n].");
            bool validUserInput;
            char userInput;

            while (true)
            {
                validUserInput = char.TryParse(Console.ReadLine()!.ToLower(), out userInput) && (userInput == 'y' || userInput == 'n');
                if (validUserInput) break;
                else
                {
                    Console.WriteLine("For a valid answer, Please enter [y] for Yes or [n] for No.");
                    Console.WriteLine();
                }
            }
            if (userInput == 'y') return true;
            else return false;
        }

        static public void PrintListofQuestions(List<Question> listOfQuestions)
        {
            int cnt;
            foreach (Question question in listOfQuestions)
            {
                cnt = 0;
                Console.WriteLine(question.questionBody);
                foreach (var answer in question.answers)
                {
                    cnt++;
                    Console.WriteLine($"{cnt}. {answer.Key}");
                }
                Console.WriteLine();
                Console.WriteLine();
            }
        }
        static public void GetQuestion(out Question inputQuestion, int numberOfAnswers)
        {
            inputQuestion = new Question();
            string inputString = string.Empty;
            bool answerIsCorrect;
            bool validUserInput;
            char inputCorrectness;

            // Input Question
            Console.WriteLine("Please input Question:");

            inputQuestion.questionBody = Console.ReadLine()!;

            Console.WriteLine();

            // Input answers and their correctness respectivaly 
            for (int i = 0; i < numberOfAnswers; i++)
            {

                Console.WriteLine($"Please input answer number {i + 1}:");
                inputString = Console.ReadLine()!;

                Console.WriteLine();
                Console.WriteLine($"Is this answer correct? for Yes please enter [y] for No please enter [n]:");
                while (true)
                {
                    validUserInput = char.TryParse(Console.ReadLine()!.ToLower(), out inputCorrectness) && (inputCorrectness == 'y' || inputCorrectness == 'n');
                    if (validUserInput) break;
                    else
                    {
                        Console.WriteLine("For a valid answer, Please enter [y] for Yes or [n] for No.");
                        Console.WriteLine();
                    }
                }

                if (inputCorrectness == 'y') answerIsCorrect = true;
                else answerIsCorrect = false;

                inputQuestion.answers.Add(inputString, answerIsCorrect);

            }
        }
    }
}
