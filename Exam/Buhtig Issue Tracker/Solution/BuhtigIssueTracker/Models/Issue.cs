namespace BuhtigIssueTracker.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BuhtigIssueTracker.Utilities;

    public class Issue
    {
        private string title;
        private string description;

        public Issue(string title, string description, IssuePriority priority, List<string> tags)
        {
            this.Title = title;
            this.Description = description;
            this.Priority = priority;
            this.Tags = tags;
            this.Comments = new List<Comment>();
        }

        public int Id { get; set; }

        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinIssueTitleLength)
                {
                    throw new ArgumentException(string.Format("The title must be at least {0} symbols long", Constants.MinIssueTitleLength));
                }

                this.title = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < Constants.MinIssueDescriptionLength)
                {
                    throw new ArgumentException(string.Format("The description must be at least {0} symbols long", Constants.MinIssueDescriptionLength));
                }

                this.description = value;
            }
        }

        public IssuePriority Priority { get; private set; }

        public IList<string> Tags { get; private set; }

        public IList<Comment> Comments { get; private set; }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }

        public override string ToString()
        {
            var issue = new StringBuilder();
            issue.AppendLine(this.Title)
                .AppendFormat("Priority: {0}", this.GetPriorityAsString()).AppendLine()
                .AppendLine(this.Description);
            if (this.Tags.Count > 0)
            {
                issue.AppendFormat("Tags: {0}", string.Join(",", this.Tags.OrderBy(t => t))).AppendLine();
            }

            if (this.Comments.Count > 0)
            {
                issue.AppendFormat("Comments:{0}{1}", Environment.NewLine, string.Join(Environment.NewLine, this.Comments)).AppendLine();
            }

            return issue.ToString().Trim();
        }

        private string GetPriorityAsString()
        {
            switch (this.Priority)
            {
                case IssuePriority.Showstopper:
                    return "****";
                case IssuePriority.High:
                    return "***";
                case IssuePriority.Medium:
                    return "**";
                case IssuePriority.Low:
                    return "*";
                default:
                    throw new InvalidOperationException("The priority is invalid");
            }
        }
    }
}
