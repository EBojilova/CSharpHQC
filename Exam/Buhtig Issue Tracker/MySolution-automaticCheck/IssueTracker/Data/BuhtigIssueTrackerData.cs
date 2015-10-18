namespace Data
{
    using System.Collections.Generic;

    using IssueTracker.Interfaces;
    using IssueTracker.Models;

    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        public BuhtigIssueTrackerData()
        {
            this.NextIssueId = 1;
            this.UserName_User = new Dictionary<string, User>();

            this.issues = new MultiDictionary<Issue, string>(true);
            this.IssueId_Issue = new OrderedDictionary<int, Issue>();
            this.UserName_Issues = new MultiDictionary<string, Issue>(true);
            this.issues3 = new MultiDictionary<string, Issue>(true);

            this.User_Comments = new MultiDictionary<User, Comment>(true);
            this.kommentaren = new Dictionary<Comment, User>();
        }

        public int NextIssueId { get; set; }

        public MultiDictionary<Issue, string> issues { get; set; }

        public MultiDictionary<string, Issue> issues3 { get; set; }

        public Dictionary<Comment, User> kommentaren { get; set; }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UserName_User { get; set; }

        public OrderedDictionary<int, Issue> IssueId_Issue { get; set; }

        public MultiDictionary<string, Issue> UserName_Issues { get; set; }

        public MultiDictionary<string, Issue> Tag_Issues { get; set; }

        public MultiDictionary<User, Comment> User_Comments { get; set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.NextIssueId;
            this.IssueId_Issue.Add(issue.Id, issue);
            this.NextIssueId++;
            this.UserName_Issues[this.CurrentUser.UserName].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.Tag_Issues[tag].Add(issue);
            }
            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.UserName_Issues[this.CurrentUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.Tag_Issues[tag].Remove(issue);
            }
            this.IssueId_Issue.Remove(issue.Id);
        }
    }
}