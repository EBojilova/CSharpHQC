// ReSharper disable InconsistentNaming

namespace BuhtigIssueTracker.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IssueTrackerGetMyComments
    {
        private Comment comment1;

        private Comment comment2;

        private Issue issue1;

        private IIssueTracker tracker;

        private User user1;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tracker = new IssueTracker();

            this.issue1 = new Issue(
                "Not possible to practise in judge.",
                "Judge system is not working. Not possible to log in.",
                IssuePriority.High,
                new List<string> { "judge", "softuni" });

            this.user1 = new User("Helen", "0123");

            this.comment1 = new Comment(this.user1, "Can someone answer, please.");
            this.comment2 = new Comment(this.user1, "There is still no answer :(");

            this.issue1.Comments = new List<Comment> { this.comment1, this.comment2 };
        }

        [TestMethod]
        public void IssueTracker_GetMyComments_NotLogedIn()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            var message = this.tracker.GetMyComments();

            Assert.AreEqual("There is no currently logged in user", message);
        }

        [TestMethod]
        public void IssueTracker_GetMyComments_NoComments()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            this.tracker.LoginUser("Helen", "0123");
            var message = this.tracker.GetMyComments();

            Assert.AreEqual("No comments", message);
        }

        [TestMethod]
        public void IssueTracker_CetMyComments_Success()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            this.tracker.LoginUser("Helen", "0123");
            this.tracker.CreateIssue(
                "Not possible to practise in judge.",
                "Judge system is not working. Not possible to log in.",
                IssuePriority.High,
                new[] { "judge", "softuni" });
            this.tracker.LogoutUser();

            this.tracker.LoginUser("Helen", "0123");
            this.tracker.AddComment(1, "Can someone answer, please.");
            this.tracker.AddComment(1, "There is still no answer :(");
            var message = this.tracker.GetMyComments();

            var expected = this.issue1.Comments.Select(i => i.ToString());

            Assert.AreEqual(string.Join(Environment.NewLine, expected), message);
        }
    }
}