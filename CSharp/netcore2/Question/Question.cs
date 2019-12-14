using System;
using System.Collections.Generic;
using System.Linq;

namespace trivia.Question
{
    public abstract class Question
    {
        public String Name { get; protected set; }
        protected readonly LinkedList<string> Questions = new LinkedList<string>();

        public abstract void AddLastQuestion(int index);

        public string First()
        {
            return Questions.First();
        }

        public void RemoveFirstQuestion()
        {
            Questions.RemoveFirst();
        }
    }
}