using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Quiz_Maker
{
    internal class UI
    {
        static public void AskForAnswer()
            {
                
            }

        static public void PrintQuestionFromList(List<Question> listOfQuestions, int questionIndex)
        {
            int cnt = 0;
            Console.WriteLine($"{listOfQuestions[questionIndex].questionBody}");
            foreach (var answer in listOfQuestions[questionIndex].answers)
            {
                cnt++;
                Console.WriteLine($"{cnt}. {answer.answer}");
            }
            Console.WriteLine();
        }

        static public bool CheckFileOverwrite()
        {
            bool validUserInput;
            char userInput;
            Console.Write("Do you want to overwrite the existing questions data base? yes [y] no");
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

        static public void PrintErrors(int error)
        {
            switch (error)
            {
                case Constants.NO_QUESTIONS_FOUND:
                    {
                        Console.WriteLine("In the specified path, no file was found");
                        Console.WriteLine();
                        break;
                    }
            }
        }


        static public int GetUserMode(int playMode, int inputMode)
        {
            bool validUserInput;
            int userMode;
            Console.Write($"Please choose user mode. Enter {playMode} if you want to play or {inputMode} if you want to create questions: ");
            while (true)
            {
                validUserInput = int.TryParse(Console.ReadLine(), out userMode) && (userMode == inputMode || userMode == playMode);
                if (validUserInput) break;
                else
                {
                    Console.WriteLine($"Please enter {playMode} if you want to play or {inputMode} if you want to create questions: ");
                }
            }
            return userMode;
        }

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
            Console.WriteLine("Current list of questions:");
            foreach (Question question in listOfQuestions)
            {
                cnt = 0;
                Console.WriteLine(question.questionBody);
                foreach (var answer in question.answers)
                {
                    cnt++;
                    Console.WriteLine($"{cnt}. {answer.answer} || {answer.correctness}");
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

                inputQuestion.answers.Add((inputString, answerIsCorrect));
            }
        }
    }
}
