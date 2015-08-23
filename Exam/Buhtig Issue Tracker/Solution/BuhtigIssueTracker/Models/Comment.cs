namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Text;
    using BuhtigIssueTracker.Utilities;

    public class Comment
    {
        private string text;

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; private set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinCommentLength)
                {
                    throw new ArgumentException(string.Format("The text must be at least {0} symbols long", Constants.MinCommentLength));
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            var comment = new StringBuilder();
            comment.AppendLine(this.Text)
                .AppendFormat("-- {0}", this.Author.Username).AppendLine();
            return comment.ToString().Trim();
        }
    }
}
