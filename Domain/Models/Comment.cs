using Domain.Common;

namespace Domain.Models
{
    public class Comment : Entity<int>
    {
        public Comment(string text, bool isPro)
        {
            Validator.Validate(text);

            this.Text = text;
            this.IsPro = isPro;
        }

        public string Text { get; }

        public bool IsPro { get; private set; }

        public void ChangeIsPro() => this.IsPro = !this.IsPro;
    }
}