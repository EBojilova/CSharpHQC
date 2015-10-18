namespace IssueTracker.Core
{
    using System;

    using global::IssueTracker.Enums;
    using global::IssueTracker.Interfaces;

    public class Dispatcher : IDispatcher
    {
        private Dispatcher(IIssueTracker tracker)
        {
            this.Tracker = tracker;
        }

        public Dispatcher()
            : this(new IssueTracker())
        {
        }

        private IIssueTracker Tracker { get; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.Tracker.RegisterUser(
                        endpoint.ActionParameters["username"],
                        endpoint.ActionParameters["password"],
                        endpoint.ActionParameters["confirmPassword"]);
                case "LoginUser":
                    return this.Tracker.LoginUser(
                        endpoint.ActionParameters["username"],
                        endpoint.ActionParameters["password"]);
                case "CreateIssue":
                    return this.Tracker.CreateIssue(
                        endpoint.ActionParameters["title"],
                        endpoint.ActionParameters["description"],
                        (IssuePriority)Enum.Parse(typeof(IssuePriority), endpoint.ActionParameters["priority"], true),
                        endpoint.ActionParameters["tags"].Split('|'));
                case "RemoveIssue":
                    return this.Tracker.RemoveIssue(int.Parse(endpoint.ActionParameters["id"]));
                case "AddComment":
                    return this.Tracker.AddComment(
                        int.Parse(endpoint.ActionParameters["Id"]),
                        endpoint.ActionParameters["text"]);
                case "MyIssues":
                    return this.Tracker.GetMyIssues();
                case "MyComments":
                    return this.Tracker.GetMyComments();
                case "Search":
                    return this.Tracker.SearchForIssues(endpoint.ActionParameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}