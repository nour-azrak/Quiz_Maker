using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Quiz_Maker
{
    internal class Logic
    {
        static public void SerializeQuestions(List<Question>? listOfQuestions)
        {
            string json;

            // WrtieIndent = true to increase readability
            json = JsonSerializer.Serialize(listOfQuestions,
                            new JsonSerializerOptions { WriteIndented = true });
            // save the questions into a file
            File.WriteAllText(Constants.DEFAULT_PATH, json);
        }
        static public List<Question> DeserializeQuestions()
        {
            string json;
            List<Question>? listOfQuestions = new List<Question>();
            try
            {
                json = File.ReadAllText(Constants.DEFAULT_PATH);
                listOfQuestions = JsonSerializer.Deserialize<List<Question>>(json);

            }
            catch (FileNotFoundException)
            {
                listOfQuestions = null;
            }

            return listOfQuestions;
        }

        /// <summary>
        /// Checks if user has won
        /// </summary>
        /// <param name="answeredQuestion">chosen question te answered</param>
        /// <param name="answers">index of chosen answers from user</param>
        /// <returns>true if user has won</returns>
        static public bool CheckUserWin(Question answeredQuestion, List<int> answers)
        {
            bool userWon = true;
            int countPossibleCorrectAnswers = 0;
            foreach (var possibleAnswer in answeredQuestion.answers)
            {
                if (possibleAnswer.correctness == true)
                {
                    countPossibleCorrectAnswers ++;
                }
            }

            if (countPossibleCorrectAnswers != answers.Count)
            {
                userWon = false;
                return userWon;
            }
            foreach (var answer in answers)
            {
                if (answeredQuestion.answers[answer - 1].correctness == false)
                {
                    userWon = false;
                }
            }
            return userWon;

        }


        static public bool CheckMultipleCorrectAnswers(Question askedQuestion, out int countCorrectAnswers)
        {
            countCorrectAnswers = 0;

            for (int i = 0; i < askedQuestion.answers.Count; i++)
            {
                if (askedQuestion.answers[i].correctness)
                {
                    countCorrectAnswers++;
                }

            }
            if (countCorrectAnswers > 1) return true;
            else return false;
        }
        static Random random = new Random();
        static public List<int> ChooseRandomQuestion(int SizeOfQuestionList)
        {
            // creates uniq
            List<int> numbers = Enumerable.Range(0, SizeOfQuestionList)
                .OrderBy(x => random.Next())
                .Take(10)
                .ToList();

            return numbers;
        }
    }
}
