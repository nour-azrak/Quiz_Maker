using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    public class Question
    {
        public string questionBody { get; set; } = "";

        public Dictionary<string, bool> answers { get; set; } = new Dictionary<string, bool>();
    }
}
