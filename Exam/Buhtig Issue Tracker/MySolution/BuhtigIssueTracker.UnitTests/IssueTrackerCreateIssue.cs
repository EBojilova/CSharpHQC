// ReSharper disable InconsistentNaming
namespace BuhtigIssueTracker.UnitTests
{
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using BuhtigIssueTracker.Interfaces;
    using Models;

    [TestClass]
    public class IssueTrackerCreateIssue
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tracker = new IssueTracker();
        }

        [TestMethod]
        public void IssueTracker_CreateIssue_Successfully()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            this.tracker.LoginUser("Helen", "0123");
            var message = this.tracker.CreateIssue(
                "Not possible to practise in judge.", 
                "Judge system is not working. Not possible to log in.", 
                IssuePriority.High, 
                new[] { "judge", "softuni" });

            Assert.AreEqual("Issue 1 created successfully", message);
        }

        [TestMethod]
        public void IssueTracker_CreateIssue_NotLogedIn()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            var message = this.tracker.CreateIssue(
                "Not possible to practise in judge.", 
                "Judge system is not working. Not possible to log in.", 
                IssuePriority.High, 
                new[] { "judge", "softuni" });

            Assert.AreEqual("There is no currently logged in user", message);
        }
    }
}