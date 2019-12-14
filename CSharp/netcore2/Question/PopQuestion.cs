namespace trivia.Question
{
    public class PopQuestion:Question
    {
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Pop Question {index}");
        }
    }
}