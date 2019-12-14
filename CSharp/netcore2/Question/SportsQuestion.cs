namespace trivia.Question
{
    public class SportsQuestion:Question
    {
        public SportsQuestion()
        {
            Name = "Sports";
        }
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Sports Question {index}");
        }
    }
}