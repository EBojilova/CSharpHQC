namespace BuhtigIssueTracker.Execution
{
    using System;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;

    public class EndpointActionDispatcher
    {
        public EndpointActionDispatcher(IIssueTracker issueTracker)
        {
            this.IssueTracker = issueTracker;
        }

        public EndpointActionDispatcher()
            : this(new IssueTracker())
        {
        }

        public IIssueTracker IssueTracker { get; private set; }

        public string DispatchAction(IEndpoint endpoint)
        {
            switch (endpoint.ActionName)
            {
                case "RegisterUser":
                    return this.IssueTracker.RegisterUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"],
                        endpoint.Parameters["confirmPassword"]);
                case "LoginUser":
                    return this.IssueTracker.LoginUser(
                        endpoint.Parameters["username"],
                        endpoint.Parameters["password"]);
                case "LogoutUser":
                    return this.IssueTracker.LogoutUser();
                case "CreateIssue":
                    return this.IssueTracker.CreateIssue(
                        endpoint.Parameters["title"],
                        endpoint.Parameters["description"],
                        (IssuePriority)Enum.Parse(typeof(IssuePriority), endpoint.Parameters["priority"], true),
                        endpoint.Parameters["tags"].Split('|'));
                case "RemoveIssue":
                    return this.IssueTracker.RemoveIssue(int.Parse(endpoint.Parameters["id"]));
                case "AddComment":
                    return this.IssueTracker.AddComment(
                        int.Parse(endpoint.Parameters["id"]),
                        endpoint.Parameters["text"]);
                case "MyIssues":
                    return this.IssueTracker.GetMyIssues();
                case "MyComments":
                    return this.IssueTracker.GetMyComments();
                case "Search":
                    return this.IssueTracker.SearchForIssues(endpoint.Parameters["tags"].Split('|'));
                default:
                    return string.Format("Invalid action: {0}", endpoint.ActionName);
            }
        }
    }
}