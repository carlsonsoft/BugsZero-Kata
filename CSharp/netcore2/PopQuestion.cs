namespace Trivia
{
    public class PopQuestion:Question
    {
        public override void AddLastQuestion(int index)
        {
            Questions.AddFirst($"Pop Question {index}");
        }
    }
}