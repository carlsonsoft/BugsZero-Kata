namespace trivia.Question
{
    public class SportsQuestion:Question
    {
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Sports Question {index}");
        }
    }
}