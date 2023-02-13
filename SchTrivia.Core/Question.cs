namespace SchTrivia.Core
{
    public class Question : IQuestion
    {
        public Question()
        {

        }

        public Question(string text, object rightAnswer)
        {
            Text = text;
            RightAnswer = rightAnswer;
        }

        public string Text { get; set; } = "";
        public object RightAnswer { get; set; } = new();
        public object[]? FakeAnswers { get; set; }
    }
}