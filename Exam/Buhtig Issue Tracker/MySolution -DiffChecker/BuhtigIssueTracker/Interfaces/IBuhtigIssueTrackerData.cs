namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;

    using BuhtigIssueTracker.Models;

    using Wintellect.PowerCollections;

    internal interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UserName_User { get; }

        OrderedDictionary<int, Issue> IssueId_Issue { get; }

        MultiDictionary<string, Issue> UserName_Issue { get; }

        MultiDictionary<string, Issue> TagIssue { get; }

        MultiDictionary<User, Comment> UserComments { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}