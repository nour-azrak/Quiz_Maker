using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz_Maker
{
    public class Question
    {
        public string questionBody { get; set; } = "";

        public List<Answer> answers { get; set; } = new List<Answer>();
    }
}
