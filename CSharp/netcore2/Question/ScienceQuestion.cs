namespace trivia.Question
{
    public class ScienceQuestion:Question
    {
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Science Question {index}");
        }
    }
}