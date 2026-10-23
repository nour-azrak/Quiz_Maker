namespace Quiz_Maker
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // create list of questions
            List<Question> listOfQuestions = new List<Question>();

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
            // serialize them

            // print them
            UI.PrintListofQuestions(listOfQuestions);


            // deserielize them
            
        }
    }
}
