namespace BuhtigIssueTracker.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BuhtigIssueTracker.Models;

    [TestClass]
    public class SearchForIssuesTests : TestBootstrapper
    {

        [TestMethod]
        public void SearchForIssues_WithSingleIssue_ShouldReturnTheIssue()
        {
            this.tracker.RegisterUser("username", "pass123", "pass123");
            this.tracker.LoginUser("username", "pass123");
            this.tracker.CreateIssue("Issue by username", "Issue description (by username)", IssuePriority.High, new[] { "tag" });
            string message = this.tracker.SearchForIssues(new[] { "tag" });
            Assert.AreEqual(
                "Issue by username\r\n"+
                "Priority: ***\r\n"+
                "Issue description (by username)\r\n"+
                "Tags: tag",
                message);
        }

        [TestMethod]
        public void SearchForIssues_WithManyIssues_ShouldSortCorrectly()
        {
            this.tracker.RegisterUser("username", "pass123", "pass123");
            this.tracker.LoginUser("username", "pass123");
            this.tracker.CreateIssue("Issue Low", "Issue description (by username)", IssuePriority.Low, new[] { "tag" });
            this.tracker.CreateIssue("Issue Medium", "Issue description (by username)", IssuePriority.Medium, new[] { "tag", "tag2" });
            this.tracker.CreateIssue("Issue High", "Issue description (by username)", IssuePriority.High, new[] { "tag", "tag3", "tag2" });
            this.tracker.CreateIssue("An Issue High", "Issue description (by username)", IssuePriority.High, new[] { "tag", "tag3", "tag2" });
            this.tracker.CreateIssue("Issue Showstopper", "Issue description (by username)", IssuePriority.Showstopper, new[] { "tag" });
            string message = this.tracker.SearchForIssues(new[] { "tag" });
            Assert.AreEqual(
                "Issue Showstopper\r\n"+
                "Priority: ****\r\n"+
                "Issue description (by username)\r\n"+
                "Tags: tag\r\n"+
                "An Issue High\r\n"+
                "Priority: ***\r\n"+
                "Issue description (by username)\r\n"+
                "Tags: tag,tag2,tag3\r\n"+
                "Issue High\r\n"+
                "Priority: ***\r\n"+
                "Issue description (by username)\r\n"+
                "Tags: tag,tag2,tag3\r\n"+
                "Issue Medium\r\n"+
                "Priority: **\r\n"+
                "Issue description (by username)\r\n"+
                "Tags: tag,tag2\r\n"+
                "Issue Low\r\n"+
                "Priority: *\r\n"+
                "Issue description (by username)\r\n"+
                "Tags: tag",
                message);
        }

        [TestMethod]
        public void SearchForIssues_WithNoMatchingIssues_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("username", "pass123", "pass123");
            this.tracker.LoginUser("username", "pass123");
            this.tracker.CreateIssue("Issue 1", "Issue description (by username)", IssuePriority.High, new[] { "tag" });
            this.tracker.CreateIssue("Issue 2", "Issue description (by username)", IssuePriority.High, new[] { "tag", "tag2" });
            this.tracker.CreateIssue("Issue 3", "Issue description (by username)", IssuePriority.High, new[] { "tag", "tag3", "tag2" });
            this.tracker.CreateIssue("Issue 4", "Issue description (by username)", IssuePriority.High, new[] { "tag" });
            string message = this.tracker.SearchForIssues(new[] { "tag10" });
            Assert.AreEqual("There are no issues matching the tags provided", message);
        }

        [TestMethod]
        public void SearchForIssues_WithNoTags_ShouldReturnErrorMessage()
        {
            string message = this.tracker.SearchForIssues(new string[] { });
            Assert.AreEqual("There are no tags provided", message);
        }
    }
}
