namespace IssueTracker.Interfaces
{
    using System.Collections.Generic;

    using global::IssueTracker.Models;

    using Wintellect.PowerCollections;

    internal interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UserName_User { get; }

        OrderedDictionary<int, Issue> IssueId_Issue { get; }

        MultiDictionary<string, Issue> UserName_Issues { get; }

        MultiDictionary<string, Issue> Tag_Issues { get; }

        MultiDictionary<User, Comment> User_Comments { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}