namespace BuhtigIssueTracker.Data
{
    using System;
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
            this.UsersByUsername = new Dictionary<string, User>();
            this.IssuesById = new OrderedDictionary<int, Issue>();
            this.IssuesByUsername = new MultiDictionary<string, Issue>(true);
            this.IssuesByTags = new MultiDictionary<string, Issue>(true);
            this.CommentsByUsers = new MultiDictionary<User, Comment>(true);
        }

        public User CurrentUser { get; set; }

        public IDictionary<string, User> UsersByUsername { get; private set; }

        public OrderedDictionary<int, Issue> IssuesById { get; private set; }

        public MultiDictionary<string, Issue> IssuesByUsername { get; private set; }

        public MultiDictionary<string, Issue> IssuesByTags { get; private set; }

        public MultiDictionary<User, Comment> CommentsByUsers { get; private set; }

        public int AddIssue(Issue issue)
        {
            issue.Id = this.nextIssueId;
            this.IssuesById.Add(issue.Id, issue);
            this.nextIssueId++;
            this.IssuesByUsername[this.CurrentUser.Username].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTags[tag].Add(issue);
            }

            return issue.Id;
        }

        public void RemoveIssue(Issue issue)
        {
            this.IssuesByUsername[this.CurrentUser.Username].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.IssuesByTags[tag].Remove(issue);
            }

            this.IssuesById.Remove(issue.Id);
        }
    }
}
