using System;
namespace Quiz
{
    public class Questions
    {
        private Options options;
        private string question;
        private string correctAnswer;
        private string hint;
        public Questions(string question, Options options, string hint, string correctAnswer)
        {
            this.question = question;
            this.options = options;
            this.correctAnswer = correctAnswer;
            this.hint = hint;
        }
        public string getCorrectAnswer()
        {
            return correctAnswer;
        }
        public string getQuestion()
        {
            return question;
        }
        public string getHint()
        {
            string hint1=("( "+hint+" )");
            return hint1;
        }
    }
}