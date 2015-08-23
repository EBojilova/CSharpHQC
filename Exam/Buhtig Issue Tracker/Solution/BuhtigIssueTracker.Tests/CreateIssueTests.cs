namespace BuhtigIssueTracker.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BuhtigIssueTracker.Models;

    [TestClass]
    public class CreateIssueTests : TestBootstrapper
    {
        [TestMethod]
        public void CreateIssue_WithValidData_ShouldCreateTheIssue()
        {
            this.tracker.RegisterUser("user", "pass123", "pass123");
            this.tracker.LoginUser("user", "pass123");
            string message = this.tracker.CreateIssue("Issue title", "Issue description", IssuePriority.Medium, new[] { "tag1", "tag2" });
            Assert.AreEqual("Issue 1 created successfully", message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssue_WithInvalidTitle_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("user", "pass123", "pass123");
            this.tracker.LoginUser("user", "pass123");
            this.tracker.CreateIssue("I", "Issue description", IssuePriority.Medium, new[] { "tag1", "tag2" });

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateIssue_WithInvalidDescription_ShouldReturnErrorMessage()
        {
            this.tracker.RegisterUser("user", "pass123", "pass123");
            this.tracker.LoginUser("user", "pass123");
            this.tracker.CreateIssue("Issue title", "I", IssuePriority.Medium, new[] { "tag1", "tag2" });
        }

        [TestMethod]
        public void CreateIssue_NoLoggedInUser_ShouldReturnErrorMessage()
        {
            string message = this.tracker.CreateIssue("I", "Issue description", IssuePriority.Medium, new[] { "tag1", "tag2" });
            Assert.AreEqual("There is no currently logged in user", message);
        }
    }
}
