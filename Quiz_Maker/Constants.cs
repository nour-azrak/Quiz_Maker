using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    internal class Constants
    {
        // number of answers in one question
        public const int NUMBER_OF_ANSWERS = 4;

        // play mode or input mode
        public const int INPUT_MODE = 0, PLAY_MODE = 1;

        // Error 1: no questions found when deserializing file in the specified path
        public const int NO_QUESTIONS_FOUND = 1;

        // defalt path constant
        public const string DEFAULT_PATH = @"Questions.json";
    }
}
