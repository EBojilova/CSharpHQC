// ReSharper disable InconsistentNaming
namespace BuhtigIssueTracker.UnitTests
{
    using System.Globalization;
    using System.Threading;

    using BuhtigIssueTracker.Interfaces;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IssueTrackerRegisterUser
    {
        private IIssueTracker tracker;

        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tracker = new IssueTracker();
        }

        [TestMethod]
        public void IssueTracker_RegisterUser_RegisterSuccess()
        {
            var message = this.tracker.RegisterUser("Helen", "0123", "0123");

            Assert.AreEqual("User Helen registered successfully", message);
        }

        [TestMethod]
        public void IssueTracker_RegisterUser_UserAlreadyExists()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            var message = this.tracker.RegisterUser("Helen", "0123", "0123");

            Assert.AreEqual("A user with username Helen already exists", message);
        }

        [TestMethod]
        public void IssueTracker_RegisterUser_TrackerAlreadyLogedin()
        {
            this.tracker.RegisterUser("Helen", "0123", "0123");
            this.tracker.LoginUser("Helen", "0123");
            var message = this.tracker.RegisterUser("Gosho", "0124", "0124");

            Assert.AreEqual("There is already a logged in user", message);
        }

        [TestMethod]
        public void IssueTracker_RegisterUser_NotCorrectPassword()
        {
            var message = this.tracker.RegisterUser("Helen", "0123", "1123");

            Assert.AreEqual("The provided passwords do not match", message);
        }
    }
}