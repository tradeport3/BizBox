using Domain.Common;

namespace Domain.Models
{
    public class ProCon
    {
        public ProCon(string text, bool isPro)
        {
            Validator.Validate(text);

            this.Text = text;
            this.IsPro = isPro;
        }
        public string Text { get; set; }

        public bool IsPro { get; set; }
    }
}