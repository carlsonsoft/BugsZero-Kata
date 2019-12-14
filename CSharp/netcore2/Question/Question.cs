using System.Collections.Generic;
using System.Linq;

namespace trivia.Question
{
    public abstract class Question
    {
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