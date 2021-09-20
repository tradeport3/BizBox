using Domain.Common;

namespace Domain.Models
{
    public class Comment
    {
        public Comment(bool isPro, string text)
        {
            Validatr.Validate(text);

            this.IsPro = isPro;
            this.Text = text;
        }
        public string Text { get; }

        public bool IsPro { get; private set; }

        public void ChangeIsPro() => this.IsPro = !this.IsPro;
    }
}