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
    public class IssueTrackerSearchForIssue
    {
        private Comment comment1;

        private Comment comment2;

        private Comment comment3;

        private Comment comment4;

        private Issue issue1;

        private Issue issue2;

        private IIssueTracker tracker;

        private User user1;

        private User user2;

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

            this.issue2 = new Issue(
                "Not possible to practise in judge, again.", 
                "Judge system is not working, again. Not possible to log in.", 
                IssuePriority.Low, 
                new List<string> { "judge", "softuni" });

            this.user1 = new User("Helen", "0123");
            this.user2 = new User("Gosho", "0124");

            this.comment1 = new Comment(
                this.user2, 
                "The system is not working from yesterday, but they made new website and it will take a while till it starts working correctly.");
            this.comment2 = new Comment(this.user1, "Ok, thanks. I heard of that. Hope soon can practice, again.");

            this.issue1.Comments = new List<Comment> { this.comment1, this.comment2 };

            this.comment3 = new Comment(this.user2, "It just started working.");
            this.comment4 = new Comment(this.user1, "Ok, Ican practice now.");

            this.issue2.Comments = new List<Comment> { this.comment3, this.comment4 };
        }

        [TestMethod]
        public void IssueTracker_SearchForIssues_NoTags()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            var message = this.tracker.SearchForIssues(new string[] { });

            Assert.AreEqual("There are no tags provided", message);
        }

        [TestMethod]
        public void IssueTracker_SearchForIssues_NoMatching()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            var message = this.tracker.SearchForIssues(new string[] {"holliday" });

            Assert.AreEqual("There are no issues matching the tags provided", message);
        }

        [TestMethod]
        public void IssueTracker_RegisterUser_NotCorrectPassword()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            this.tracker.LoginUser("Helen", "0123");
            this.tracker.CreateIssue(
                "Not possible to practise in judge.", 
                "Judge system is not working. Not possible to log in.", 
                IssuePriority.High, 
                new[] { "judge", "softuni" });
            this.tracker.LogoutUser();

            this.tracker.RegisterUser("Gosho", "0124", "0124");
            this.tracker.LoginUser("Gosho", "0124");
            this.tracker.AddComment(
                1, 
                "The system is not working from yesterday, but they made new website and it will take a while till it starts working correctly.");
            this.tracker.LogoutUser();

            this.tracker.LoginUser("Helen", "0123");
            this.tracker.AddComment(1, "Ok, thanks. I heard of that. Hope soon can practice, again.");
            this.tracker.LogoutUser();

            this.tracker.LoginUser("Helen", "0123");
            this.tracker.CreateIssue(
                "Not possible to practise in judge, again.",
                "Judge system is not working, again. Not possible to log in.",
                IssuePriority.Low,
                new[] { "judge", "softuni" });
            this.tracker.LogoutUser();

            this.tracker.LoginUser("Gosho", "0124");
            this.tracker.AddComment(
                2,
                "It just started working.");
            this.tracker.LogoutUser();

            this.tracker.LoginUser("Helen", "0123");
            this.tracker.AddComment(2, "Ok, Ican practice now.");
            this.tracker.LogoutUser();

            var message = this.tracker.SearchForIssues(new string[] { "judge", "softuni" });

            var expected = new[] { this.issue1, this.issue2 }.Select(i => i.ToString());

            Assert.AreEqual(string.Join(Environment.NewLine, expected), message);
        }
    }
}