using System;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Quiz_Maker
{
    internal class UI
    {
        static public void PrintScore(int score)
        {
            Console.WriteLine();
            Console.WriteLine($"Your score is {score}");
            Console.WriteLine();
        }
        static public void DisplayAnswerMessage(bool correctAnswer)
        {
            Console.WriteLine();
            if (correctAnswer)
            {
                Console.WriteLine("Congrats. You answered correctly");
            }
            else
            {
                Console.WriteLine("Sorry. Wrong answer");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxAnswerNumber">maximum number of answers</param>
        /// <param name="CorrectAnswers"></param>
        /// <returns></returns>
        static public List<int> AskForAnswer(int maxAnswerNumber, int CorrectAnswers)
        {
            int answer = 0;
            bool validUserInput;
            List<int> answerUserInput = new List<int>();

            for (int i = 0; i < CorrectAnswers; i++)
            {
                Console.WriteLine();
                if (CorrectAnswers > 1)
                {
                    Console.Write("Please provide your answers: ");
                }
                else
                {
                    Console.Write("Please provide your answer: ");
                }
                while (true)
                {
                    validUserInput = int.TryParse(Console.ReadLine(), out answer) && answer > 0 && answer <= maxAnswerNumber && !answerUserInput.Contains(answer);
                    if (validUserInput)
                    {
                        answerUserInput.Add(answer);
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"Please enter a single digit number above zero and smaller than {maxAnswerNumber + 1}. Please make sure to not enter aleardy entered answers");
                        Console.Write("Please provide your answer: ");

                    }
                }
                if (CorrectAnswers == 1 || i == CorrectAnswers-1) break;
                if (!UserWantsToInputNextAnswer()) break;
            }
            Console.WriteLine();
            return answerUserInput;
        }

        static public bool UserWantsToInputNextAnswer()
        {
            bool validUserInput;
            char userInput;
            Console.WriteLine();
            Console.WriteLine("If you want to keep entering answers please input [y]. If not please enter [n].");

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
            Console.WriteLine();
            if (userInput == 'y') return true;
            else return false;
        }

        static public void PrintQuestionFromList(List<Question> listOfQuestions, int questionIndex, bool multipleAnswers)
        {
            int cnt = 0;
            Console.WriteLine();
            if (multipleAnswers)
            {
                Console.WriteLine("This question has multiple answers. Make sure to enter all correct answer to count as point");
                Console.WriteLine();
            }
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
            Console.WriteLine();
            Console.Write("Do you want to overwrite the existing questions data base? yes [y] no [n]: ");
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
            Console.WriteLine();
            if (userInput == 'y') return true;
            else return false;

        }

        static public void PrintErrors(int error)
        {
            Console.WriteLine();
            switch (error)
            {
                case Constants.NO_QUESTIONS_FOUND:
                    {
                        Console.WriteLine("In the specified path, no file was found");
                        Console.WriteLine();
                        break;
                    }
            }
            Console.WriteLine();
        }


        static public int GetUserMode()
        {
            bool validUserInput;
            int userMode;
            Console.WriteLine();
            Console.Write($"Please choose user mode. Enter {Constants.PLAY_MODE} if you want to play or {Constants.INPUT_MODE} if you want to create questions: ");
            while (true)
            {
                validUserInput = int.TryParse(Console.ReadLine(), out userMode) && (userMode == inputMode || userMode == playMode);
                if (validUserInput) break;
                else
                {
                    Console.WriteLine($"Please enter {playMode} if you want to play or {inputMode} if you want to create questions: ");
                }
            }
            Console.WriteLine();
            return userMode;
        }

        /// <summary>
        /// Checks whether the user wants to keep inputting questions
        /// </summary>
        /// <returns></returns>
        static public bool UserWantsToInputNextQuestion(bool firstLoop)
        {
            Console.WriteLine();
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
            Console.WriteLine();
            if (userInput == 'y') return true;
            else return false;
        }


        static public void PrintListofQuestions(List<Question> listOfQuestions)
        {
            int cnt;
            Console.WriteLine();
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
            bool correctness;
            bool validUserInput;
            char inputCorrectness;

            Console.WriteLine();
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

                if (inputCorrectness == 'y') correctness = true;
                else correctness = false;

                inputQuestion.answers.Add(new Answer
                {
                    answer = inputString,
                    correctness = correctness
                });
            }
            Console.WriteLine();
        }
    }
}
