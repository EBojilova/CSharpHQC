namespace BuhtigIssueTracker.Data
{
    using System.Collections.Generic;

    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;

    using Wintellect.PowerCollections;

    public class BuhtigIssueTrackerData : IBuhtigIssueTrackerData
    {
        private int nextIssueId;

        public BuhtigIssueTrackerData()
        {
            this.nextIssueId = 1;
            this.UserName_User = new Dictionary<string, User>();

            ////this.Issues = new MultiDictionary<Issue, string>(true);
            this.IssueId_Issue = new OrderedDictionary<int, Issue>();
            this.UserName_Issue = new MultiDictionary<string, Issue>(true);
            ////this.Issues3 = new MultiDictionary<string, Issue>(true);
            this.UserComments = new MultiDictionary<User, Comment>(true);
            ////this.Kommentaren = new Dictionary<Comment, User>();
            this.TagIssue = new MultiDictionary<string, Issue>(true);
        }

        ////public MultiDictionary<Issue, string> Issues { get; set; }

        ////public MultiDictionary<string, Issue> Issues3 { get; set; }

        ////public Dictionary<Comment, User> Kommentaren { get; set; }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UserName_User { get; set; }

        public OrderedDictionary<int, Issue> IssueId_Issue { get; set; }

        public MultiDictionary<string, Issue> UserName_Issue { get; set; }

        public MultiDictionary<string, Issue> TagIssue { get; set; }

        public MultiDictionary<User, Comment> UserComments { get; set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.nextIssueId;
            this.IssueId_Issue.Add(issue.Id, issue);
            this.nextIssueId++;
            this.UserName_Issue[this.CurrentUser.UserName].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagIssue[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.UserName_Issue[this.CurrentUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.TagIssue[tag].Remove(issue);
            }

            this.IssueId_Issue.Remove(issue.Id);
        }
    }
}