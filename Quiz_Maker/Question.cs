using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    internal class Question
    {
        public string questionBody = "";

        public Dictionary<string, bool> answers = new Dictionary<string, bool>();
    }
}
