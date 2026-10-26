using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user mode
            int userMode = UI.GetUserMode();

            // count correctly answered questions
            int cnt = 0;

            // store answer from user
            List<int> answer;
            bool multipleCorrectAnswers;
            bool correctAnswer;

            // create list of questions
            List<Question>? listOfQuestions = new List<Question>();

            // random question index list
            List<int> randomQuestion = new List<int>();

            // print welcome message

            // deserialize json string and put in object list
            var path = @"Questions.json";
            string json = "";
            try
            {
                json = File.ReadAllText(path);
                listOfQuestions = JsonSerializer.Deserialize<List<Question>>(json);

            }
            catch (FileNotFoundException)
            {
                listOfQuestions = null;
            }


            if (listOfQuestions == null)
            {
                UI.PrintErrors(Constants.NO_QUESTIONS_FOUND);
                // automatically forward the user into input mode
                userMode = Constants.INPUT_MODE;
            }

            switch (userMode)
            {
                case Constants.PLAY_MODE:
                    {
                        // create a unique random index to each question in the list
                        randomQuestion = Logic.ChooseRandomQuestion(listOfQuestions.Count);

                        for (int i = 0; i < listOfQuestions.Count; i++)
                        {
                            // check if question has multiple answers
                            multipleCorrectAnswers = Logic.CheckMultipleCorrectAnswers(listOfQuestions[randomQuestion[i]], out int countCorrectAnswers);

                            // display random question
                            UI.PrintQuestionFromList(listOfQuestions, randomQuestion[i], multipleCorrectAnswers);

                            // Ask for list of answers
                            answer = UI.AskForAnswer(Constants.NUMBER_OF_ANSWERS, countCorrectAnswers);

                            // check correctness of answer
                            correctAnswer = Logic.CheckUserWin(listOfQuestions[randomQuestion[i]], answer);
                            if (correctAnswer)
                            {
                                // display correct answer message
                                UI.DisplayAnswerMessage(correctAnswer);

                                // add points for correct answers
                                cnt++;
                            }
                            else
                            {
                                // display wrong answer message
                                UI.DisplayAnswerMessage(correctAnswer);
                            }
                            UI.PrintScore(cnt);
                        }
                        // print goodby message
                        break;
                    }

                case Constants.INPUT_MODE:
                    {
                        // check whether the user wants to overwrite the existing file
                        if (listOfQuestions != null)
                        {
                            if (UI.CheckFileOverwrite())
                            {
                                listOfQuestions.Clear();
                            }
                            else
                            {
                                UI.PrintListofQuestions(listOfQuestions);
                            }
                        }
                        else
                        {
                            listOfQuestions = new List<Question>();
                        }
                        bool firstLoop = true;
                        // Get Questions
                        while (UI.UserWantsToInputNextQuestion(firstLoop))
                        {
                            firstLoop = false;
                            Question newQuestion = new Question();
                            UI.GetQuestion(out newQuestion, 4);
                            listOfQuestions.Add(newQuestion);

                            Console.WriteLine();
                            Console.WriteLine($"Size of list is {listOfQuestions.Count}");

                            //debug
                            UI.PrintListofQuestions(listOfQuestions);


                        }
                        // serialize the question list. WrtieIndent = true to increase readability
                        json = JsonSerializer.Serialize(listOfQuestions,
                            new JsonSerializerOptions { WriteIndented = true });

                        /// save the questions into a file
                        File.WriteAllText(path, json);
                        break;
                    }
            }

        }
    }
}
