namespace BuhtigIssueTracker.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BuhtigIssueTracker.Models;

    [TestClass]
    public class GetMyIssuesTests : TestBootstrapper
    {

        [TestMethod]
        public void GetMyIssues_SingleIssue_ShouldReturnTheIssue()
        {
            this.tracker.RegisterUser("username", "pass123", "pass123");
            this.tracker.LoginUser("username", "pass123");
            this.tracker.CreateIssue("Issue title", "Issue description", IssuePriority.High, new[] { "tag" });
            string message = this.tracker.GetMyIssues();
            Assert.AreEqual(
                "Issue title\r\n"+
                "Priority: ***\r\n"+
                "Issue description\r\n"+
                "Tags: tag",
                message);
        }

        [TestMethod]
        public void GetMyIssues_ManyIssues_ShouldReturnOnlyTheCorrectIssue()
        {
            this.tracker.RegisterUser("username", "pass123", "pass123");
            this.tracker.LoginUser("username", "pass123");
            this.tracker.CreateIssue("Issue by username", "Issue description (by username)", IssuePriority.High, new[] { "tag" });
            this.tracker.LogoutUser();
            this.tracker.RegisterUser("anotherUsername", "pass123", "pass123");
            this.tracker.LoginUser("anotherUsername", "pass123");
            this.tracker.CreateIssue("Issue by anotherUsername", "Issue description (by anotherUsername)", IssuePriority.High, new[] { "tag" });
            string message = this.tracker.GetMyIssues();
            Assert.AreEqual(
                "Issue by anotherUsername\r\n" +
                "Priority: ***\r\n" +
                "Issue description (by anotherUsername)\r\n" +
                "Tags: tag", 
                message);
        }

        [TestMethod]
        public void GetMyIssues_ManyIssue_ShouldSortProperly()
        {
            this.tracker.RegisterUser("username", "pass123", "pass123");
            this.tracker.LoginUser("username", "pass123");
            this.tracker.CreateIssue("Title B", "Issue description", IssuePriority.High, new[] { "tag1, tag2" });
            this.tracker.CreateIssue("Title C", "Issue description", IssuePriority.Low, new[] { "tag2", "tag1" });
            this.tracker.CreateIssue("Title B", "Issue description", IssuePriority.Medium, new[] { "tag" });
            this.tracker.CreateIssue("Title A", "Issue description", IssuePriority.Low, new[] { "tag2", "tag1" });
            this.tracker.CreateIssue("Title A", "Issue description", IssuePriority.Medium, new[] { "tag" });
            this.tracker.CreateIssue("Title B", "Issue description", IssuePriority.Showstopper, new[] { "tag3", "tag1", "tag2" });
            this.tracker.CreateIssue("Title B", "Issue description", IssuePriority.Low, new[] { "tag" });
            this.tracker.CreateIssue("Title C", "Issue description", IssuePriority.Showstopper, new[] { "tag" });

            string message = this.tracker.GetMyIssues();
            Assert.AreEqual(
                "Title B\r\n" +
                "Priority: ****\r\n" +
                "Issue description\r\n" +
                "Tags: tag1,tag2,tag3\r\n" +
                "Title C\r\n" +
                "Priority: ****\r\n" +
                "Issue description\r\n" +
                "Tags: tag\r\n" +
                "Title B\r\n" +
                "Priority: ***\r\n" +
                "Issue description\r\n" +
                "Tags: tag1, tag2\r\n" +
                "Title A\r\n" +
                "Priority: **\r\n" +
                "Issue description\r\n" +
                "Tags: tag\r\n" +
                "Title B\r\n" +
                "Priority: **\r\n" +
                "Issue description\r\n" +
                "Tags: tag\r\n" +
                "Title A\r\n" +
                "Priority: *\r\n" +
                "Issue description\r\n" +
                "Tags: tag1,tag2\r\n" +
                "Title B\r\n" +
                "Priority: *\r\n" +
                "Issue description\r\n" +
                "Tags: tag\r\n" +
                "Title C\r\n" +
                "Priority: *\r\n" +
                "Issue description\r\n" +
                "Tags: tag1,tag2",
                message);
        }

        [TestMethod]
        public void GetMyIssues_NoLoggedInUser_ShouldReturnErrorMessage()
        {
            string message = this.tracker.GetMyIssues();
            Assert.AreEqual("There is no currently logged in user", message);
        }
    }
}
