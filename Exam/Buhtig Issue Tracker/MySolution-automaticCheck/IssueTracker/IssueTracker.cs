namespace IssueTracker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Data;

    using global::IssueTracker.Enums;
    using global::IssueTracker.Interfaces;
    using global::IssueTracker.Models;

    public class IssueTracker : IIssueTracker
    {
        private IssueTracker(IBuhtigIssueTrackerData data)
        {
            this.Data = data as BuhtigIssueTrackerData;
        }

        public IssueTracker()
            : this(new BuhtigIssueTrackerData())
        {
        }

        private BuhtigIssueTrackerData Data { get; }

        public string RegisterUser(string username, string password, string confirmPassword)
        {
            // If there is already a logged in user, the action returns There is already a logged in user
            if (this.Data.CurrentUser != null)
            {
                return "There is already a logged in user";
            }

            // If the two passwords do not match, the action returns The provided passwords do not match
            if (password != confirmPassword)
            {
                return "The provided passwords do not match";
            }

            // If the username is already taken, the action returns A user with username <username> already exists
            if (this.Data.UserName_User.ContainsKey(username))
            {
                return string.Format("A user with username {0} already exists", username);
            }

            // In case of success, the action returns User <username> registered successfully
            var user = new User(username, password);
            this.Data.UserName_User.Add(username, user);
            return string.Format("User {0} registered successfully", username);
        }

        public string LoginUser(string username, string password)
        {
            // If there is already a logged in user, the action returns There is already a logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is already a logged in user";
            }

            // If there is no user with the provided username, the action returns A user with username <username> does not exist
            if (!this.Data.UserName_User.ContainsKey(username))
            {
                return string.Format("A user with username {0} does not exist", username);
            }

            // If the password is invalid, the action returns The password is invalid for user <username>
            var user = this.Data.UserName_User[username];

            // If the password is invalid, the action returns The password is invalid for user <username>
            if (user.PasswordHashed != User.HashPassword(password))
            {
                return string.Format("The password is invalid for user {0}", username);
            }

            // Logins a user in the application. After login, they become the currently active user.
            this.Data.CurrentUser = user;

            // returns User <username> logged in successfully
            return string.Format("User {0} logged in successfully", username);
        }

        public string LogoutUser()
        {
            // If there is no logged in user, the action returns There is no currently logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var username = this.Data.CurrentUser.UserName;

            // Logs out the currently active user. 
            this.Data.CurrentUser = null;

            // In case of success, the action returns User <username> logged out successfully
            return string.Format("User {0} logged out successfully", username);
        }

        public string CreateIssue(string title, string description, IssuePriority priority, string[] tags)
        {
            // If there is no logged in user, the action returns There is no currently logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            // In case of success, the action returns Issue <id> created successfully
            var issue = new Issue(title, description, priority, tags.Distinct().ToList());
            issue.Id = this.Data.NextIssueId;
            this.Data.IssueId_Issue.Add(issue.Id, issue);
            this.Data.NextIssueId++;
            this.Data.UserName_Issues[this.Data.CurrentUser.UserName].Add(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.Tag_Issues[tag].Add(issue);
            }
            return string.Format("Issue {0} created successfully.", issue.Id);
        }

        public string RemoveIssue(int issueId)
        {
            // If there is no logged in user, the action returns There is no currently logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            // If the issue ID is invalid (i. e., does not exist in the database), the action returns There is no issue with ID < id >
            if (!this.Data.IssueId_Issue.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            // If the issue does not belong to the currently logged in user, the action returns The issue with ID <id> does not belong to user <current_user_username>
            var issue = this.Data.IssueId_Issue[issueId];
            if (!this.Data.UserName_Issues[this.Data.CurrentUser.UserName].Contains(issue))
            {
                return string.Format(
                    "The issue with ID {0} does not belong to user {1}",
                    issueId,
                    this.Data.CurrentUser.UserName);
            }

            // Removes an issue given by the specified ID.
            // In case of success, the action returns Issue<id> removed
            this.Data.UserName_Issues[this.Data.CurrentUser.UserName].Remove(issue);
            foreach (var tag in issue.Tags)
            {
                this.Data.Tag_Issues[tag].Remove(issue);
            }
            this.Data.IssueId_Issue.Remove(issue.Id);
            return string.Format("Issue {0} removed", issueId);
        }

        public string AddComment(int issueId, string commentDescription)
        {
            // If there is no logged in user, the action returns There is no currently logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            // TODO Remove + 1
            // If the issue ID is invalid (i. e., does not exist in the database), the action returns There is no issue with ID < id >
            if (!this.Data.IssueId_Issue.ContainsKey(issueId))
            {
                return string.Format("There is no issue with ID {0}", issueId);
            }

            // In case of success, the action returns Comment added successfully to issue <id>
            var issue = this.Data.IssueId_Issue[issueId];
            var comment = new Comment(this.Data.CurrentUser, commentDescription);
            issue.AddComment(comment);
            this.Data.User_Comments[this.Data.CurrentUser].Add(comment);
            return string.Format("Comment added successfully to issue {0}", issue.Id);
        }

        public string GetMyIssues()
        {
            // If there is no logged in user, the action returns There is no currently logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            // returns the issues sorted by priority (in descending order) first, and by title (in alphabetical order) next
            var issues = this.Data.UserName_Issues[this.Data.CurrentUser.UserName];
            if (issues.Any())
            {
                return string.Join(Environment.NewLine, issues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
            }

            // If there are no issues, the action returns No issues
            return "No issues";
        }

        public string GetMyComments()
        {
            // If there is no logged in user, the action returns There is no currently logged in user
            if (this.Data.CurrentUser == null)
            {
                return "There is no currently logged in user";
            }

            var myComments = this.Data.User_Comments[this.Data.CurrentUser];

            // If there are no comments, the action returns No comments
            if (!myComments.Any())
            {
                return "No comments";
            }

            //  returns the comments sorted by time of adding. Each comment is printed in a user-friendly way, each on its own line.
            return string.Join(Environment.NewLine, myComments);
        }

        public string SearchForIssues(string[] tags)
        {
            // If there are no tags provided, the action returns There are no tags provided
            if (tags.Length < 0)
            {
                return "There are no tags provided";
            }

            var issues = new List<Issue>();
            foreach (var tag in tags)
            {
                issues.AddRange(this.Data.Tag_Issues[tag]);
            }

            // If there are no matching issues, the action returns There are no issues matching the tags provided
            if (!issues.Any())
            {
                return "There are no issues matching the tags provided";
            }

            // If an issue matches several tags, it is included only once in the search results. 
            var uniqueIssues = issues.Distinct();

            // In case of success, the action returns the issues sorted by priority (in descending order) first, and by title (in alphabetical order) next. 
            return string.Join(
                Environment.NewLine,
                uniqueIssues.OrderByDescending(x => x.Priority).ThenBy(x => x.Title));
        }
    }
}