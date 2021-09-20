using Domain.Common;

namespace Domain.Models
{
    public class Comment : Entity<int>
    {
        public Comment(bool isPro, string text)
        {
            Validator.Validate(text);

            this.IsPro = isPro;
            this.Text = text;
        }
        public string Text { get; }

        public bool IsPro { get; private set; }

        public void ChangeIsPro() => this.IsPro = !this.IsPro;
    }
}