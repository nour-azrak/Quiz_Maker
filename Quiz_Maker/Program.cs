using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get user mode
            int userMode = UI.GetUserMode(Constants.PLAY_MODE, Constants.INPUT_MODE);

            // count correctly answered questions
            int cnt = 0;

            // create list of questions
            List<Question>? listOfQuestions = new List<Question>();

            // random question number
            int randomQuestion;

            // check if user wants to overwrite existing data base
            bool overwriteDatabase;

            // deserialize json string and put in object list
            var path = @"Questions.json";
            string json = File.ReadAllText(path);

            listOfQuestions = JsonSerializer.Deserialize<List<Question>>(json);

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
