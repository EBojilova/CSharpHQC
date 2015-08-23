namespace BuhtigIssueTracker.Interfaces
{
    using System;

    using BuhtigIssueTracker.Models;

    /// <summary>
    /// Provides the basic operations required to run a issue tracker.
    /// </summary>
    public interface IIssueTracker
    {
        /// <summary>
        /// Registers a new user in the database.
        /// </summary>
        /// <param name="userName">The username of the user to register</param>
        /// <param name="password">The password of the user to register</param>
        /// <param name="confirmPassword">The confirmation of the password of the user to register. To complete the registration,
        /// the two passwords must match</param>
        /// <returns>In case of success, returns a success message.
        /// If the passwords do not match, there is another user with the same username in the database,
        /// or there is already a logged in user, returns an error message.</returns>
        string RegisterUser(string userName, string password, string confirmPassword);

        /// <summary>
        /// Logins a user in the application. 
        /// After login, the user becomes the currently active user.
        /// </summary>
        /// <param name="userName">Username of the user, who will be logged in.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>In case of success, returns a success message. 
        /// If there is already a logged in user, there is no user with the provided username,
        /// or the password is invalid, returns an error message.
        /// </returns>
        string LoginUser(string userName, string password);

        /// <summary>
        /// Logs out the currently active user. 
        /// </summary>
        /// <returns>In case of success, returns a success message.
        /// If there is no logged in user, returns an error message.
        /// </returns>
        string LogoutUser();

        /// <summary>
        /// Creates a new issue. Assigns the current user as its author. Gives it an ID automatically.
        /// </summary>
        /// <param name="title">Title of the issue.If the issue title is less than 3 symbols long, 
        /// or if the issue description is less than 5 symbols long, the system 
        /// throws an error message. </param>
        /// <param name="description">Description of the issue.</param>
        /// <param name="priority">Issue priority(Low, Medium, High, 
        /// or Showstopper, in order of increasing importance)</param>
        /// <param name="tags">The tags of the issue. In case there are 
        /// some repeating tags, the system only registers them once for each issue. 
        /// There will always be at least one tag per new issue.</param>
        /// <returns>In case of success, returns a success message. 
        /// If there is no logged in user, returns an error message.</returns>
        string CreateIssue(string title, string description, IssuePriority priority, string[] tags);

        /// <summary>
        /// Removes an issue given by the specified ID.
        /// </summary>
        /// <param name="issueId">The Id of the issue to be removed.</param>
        /// <returns>In case of success, returns a success message. 
        /// If there is no logged in user, the issue ID is invalid (i. e., does not exist in the database),  
        /// or the issue does not belong to the currently logged in user, returns an error message.</returns>
        string RemoveIssue(int issueId);

        /// <summary>
        /// Adds a comment to the issue given by the specified ID by the current user.
        /// </summary>
        /// <param name="issueId">The unique ID of the issue to add a comment to.</param>
        /// <param name="commentText">The text of the comment.</param>
        /// <returns>In case of success, returns a success message.
        /// If there is no issue with the specified ID, the issue text is less than 2 symbols long,
        /// or there is no currently logged in user, returns an error message.</returns>
        string AddComment(int issueId, string commentText);

        /// <summary>
        /// Returns the issues by the current user ordered by priority in descending order first
        /// and then by title in ascending order.
        /// </summary>
        /// <returns>In case of success, returns the issues. If there is no currently logged in user, 
        /// or if there are no issues to show, returns an error message.</returns>
        string GetMyIssues();

        /// <summary>
        /// Returns the comments by the current user ordered by creation time.
        /// </summary>
        /// <returns>In case of success, returns the comments. If there is no currently logged in user, 
        /// or if there are no comments to show, returns an error message.</returns>
        string GetMyComments();

        /// <summary>
        /// Searches for issues which have one or more of the provided tags.
        /// </summary>
        /// <param name="tags">The tags to search for.</param>
        /// <returns>In case of success, returns the issues ordered by priority in descending order first
        /// and then by title in ascending order. If there are no tags or no matching issues, 
        /// returns an error message.</returns>
        string SearchForIssues(string[] tags);
    }
}