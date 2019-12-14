namespace trivia.Question
{
    public class PopQuestion:Question
    {
        public PopQuestion()
        {
            Name = "Pop";
        }
        public override void AddLastQuestion(int index)
        {
            Questions.AddLast($"Pop Question {index}");
        }
    }
}