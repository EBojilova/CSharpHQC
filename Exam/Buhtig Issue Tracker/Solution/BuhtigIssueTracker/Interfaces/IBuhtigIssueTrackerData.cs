namespace BuhtigIssueTracker.Interfaces
{
    using System.Collections.Generic;
    using BuhtigIssueTracker.Models;
    using Wintellect.PowerCollections;

    public interface IBuhtigIssueTrackerData
    {
        User CurrentUser { get; set; }

        IDictionary<string, User> UsersByUsername { get; }

        OrderedDictionary<int, Issue> IssuesById { get; }

        MultiDictionary<string, Issue> IssuesByUsername { get; }

        MultiDictionary<string, Issue> IssuesByTags { get; }

        MultiDictionary<User, Comment> CommentsByUsers { get; }

        int AddIssue(Issue issue);

        void RemoveIssue(Issue issue);
    }
}
