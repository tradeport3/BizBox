

using Domain.Common;

namespace Domain.Models
{
    public class Interview
    {
        private readonly HashSet<string> questions;

        public Interview()
        {
            this.questions = new HashSet<string>();
        }
        public IReadOnlyCollection<string> Questions => this.questions.ToList().AsReadOnly();

        public void AddQuestion(string question)
        {
            Validator.Validate(question);

            this.questions.Add(question);
        }
    }
}