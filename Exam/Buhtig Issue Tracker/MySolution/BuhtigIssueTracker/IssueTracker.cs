namespace BuhtigIssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using BuhtigIssueTracker.Data;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;
    using BuhtigIssueTracker.Utilities;

    public class IssueTracker : IIssueTracker
    {
        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        private IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data;
        }

        private IBuhtigIssueTrackerData Data { get; set; }

        public string RegisterUser(string userName, string password, string confirmPassword)
        {
            // TODO: Refactor this code
            if (this.Data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            if (this.Data.UserName_User.ContainsKey(userName))
            {
                return string.Format("A user with username {0} already exists", userName);
            }

            var user = new User(userName, password);
            this.Data.UserName_User.Add(userName, user);
            return string.Format("User {0} registered successfully", userName);
        }

        public string LoginUser(string userName, string password)
        {
            if (this.Data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            if (!this.Data.UserName_User.ContainsKey(userName))
            {
                return string.Format("A user with username {0} does not exist", userName);
            }

            var user = this.Data.UserName_User[userName];
            if (user.UserPasswortHash != HashUtilities.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", userName);
            }

            this.Data.CurrentUser = user;

            return string.Format("User {0} logged in successfully", userName);
        }

        public string LogoutUser()
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var username = this.Data.CurrentUser.UserName;
            this.Data.CurrentUser = null;
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] strings)
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issue = new Issue(title, description, priority, strings.Distinct().ToList());
            var issueId = this.Data.AddIssue(issue);

            return string.Format("Issue {0} created successfully", issueId);
        }

        public string RemoveIssue(int issueId)
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Data.IssueId_Issue.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssueId_Issue[issueId];
            if (!this.Data.UserName_Issue[this.Data.CurrentUser.UserName].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}", 
                    issueId, 
                    this.Data.CurrentUser.UserName);
            }

            this.Data.RemoveIssue(issue);

            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string commentText)
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            if (!this.Data.IssueId_Issue.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            var issue = this.Data.IssueId_Issue[issueId];
            var comment = new Comment(this.Data.CurrentUser, commentText);
            issue.AddComment(comment);
            this.Data.UserComments[this.Data.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var issues = this.Data.UserName_Issue[this.Data.CurrentUser.UserName];
            if (issues.Any())
            {
                return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
            }

            return "No issues";
        }

        public string GetMyComments()
        {
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            ////var comments = new List<Comment>();
            ////this.Data.IssueId_Issue.Select(i => i.Value.Comments).ToList().ForEach(item => comments.AddRange(item));
            ////var resultComments =
            ////    comments.Where(
            ////        c =>
            ////        c.Author.UserName
            ////        == this.Data.CurrentUser.UserName).ToList();
            ////var tags = resultComments.Select(x => x.ToString());
            var myComments = this.Data.UserComments[this.Data.CurrentUser].Select(x => x.ToString());
            return myComments.Any() ? string.Join(Environment.NewLine, myComments) : "No comments";
        }

        public string SearchForIssues(string[] tags)
        {
            if (tags.Length <= 0)
            {
                return "There are no tags provided";
            }

            var foundIssues = new List<Issue>();
            foreach (var tag in tags)
            {
                foundIssues.AddRange(this.Data.TagIssue[tag]);
            }

            if (!foundIssues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            var sortedIssues =
                foundIssues.Distinct()
                    .OrderByDescending(x => x.Priority)
                    .ThenBy(x => x.Title)
                    .OrderByDescending(x => x.Priority)
                    .ThenBy(x => x.Title)
                    .Select(x => x.ToString());

            ////if (!newi.Any())
            ////{
            ////    return "No issues";
            ////}
            return string.Join(Environment.NewLine, sortedIssues);
        }
    }
}