using Domain.Common;

namespace Domain.Models
{
    public class Comment
    {
        public Comment(bool isPro, string text)
        {
            Validator.Validate(text);

            this.IsPro = isPro;
            this.Text = text;
        }
        public string Text { get; set; }

        public bool IsPro { get; set; }
    }
}