namespace trivia.Question
{
    public class RockQuestion:Question
    {
        public RockQuestion()
        {
            Name = "Rock";
        }
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Rock Question {index}");
        }
    }
}