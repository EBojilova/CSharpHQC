namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;

    public class Comment
    {
        private const int MinTextLenght = 2;

        private string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < MinTextLenght)
                {
                    throw new ArgumentException(
                        string.Format("The text must be at least {0} symbols long", MinTextLenght));
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            return
                new StringBuilder().AppendLine(this.Text)
                    .AppendFormat("-- {0}", this.Author.UserName)
                    .AppendLine()
                    .ToString()
                    .Trim();
        }
    }
}