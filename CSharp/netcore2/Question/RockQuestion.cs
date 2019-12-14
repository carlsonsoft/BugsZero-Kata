namespace trivia.Question
{
    public class RockQuestion:Question
    {
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Rock Question {index}");
        }
    }
}