using BuhtigIssueTracker.Models;
// <copyright file="IssueTrackerTest.cs">Copyright ©  2015</copyright>

using System;
using BuhtigIssueTracker;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuhtigIssueTracker.Tests
{
    [TestClass]
    [PexClass(typeof(IssueTracker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class IssueTrackerTest
    {

        [PexMethod]
        public string SearchForIssues([PexAssumeUnderTest]IssueTracker target, string[] tags)
        {
            string result = target.SearchForIssues(tags);
            return result;
            // TODO: add assertions to method IssueTrackerTest.SearchForIssues(IssueTracker, String[])
        }

        [PexMethod]
        public string AddComment(
            [PexAssumeUnderTest]IssueTracker target,
            int issueId,
            string commentText
        )
        {
            string result = target.AddComment(issueId, commentText);
            return result;
            // TODO: add assertions to method IssueTrackerTest.AddComment(IssueTracker, Int32, String)
        }

        [PexMethod]
        public IssueTracker Constructor()
        {
            IssueTracker target = new IssueTracker();
            return target;
            // TODO: add assertions to method IssueTrackerTest.Constructor()
        }

        [PexMethod]
        public string GetMyComments([PexAssumeUnderTest]IssueTracker target)
        {
            string result = target.GetMyComments();
            return result;
            // TODO: add assertions to method IssueTrackerTest.GetMyComments(IssueTracker)
        }

        [PexMethod]
        public string CreateIssue(
            [PexAssumeUnderTest]IssueTracker target,
            string title,
            string description,
            IssuePriority priority,
            string[] strings
        )
        {
            string result = target.CreateIssue(title, description, priority, strings);
            return result;
            // TODO: add assertions to method IssueTrackerTest.CreateIssue(IssueTracker, String, String, IssuePriority, String[])
        }

        [PexMethod]
        public string GetMyIssues([PexAssumeUnderTest]IssueTracker target)
        {
            string result = target.GetMyIssues();
            return result;
            // TODO: add assertions to method IssueTrackerTest.GetMyIssues(IssueTracker)
        }

        [PexMethod]
        public string LoginUser(
            [PexAssumeUnderTest]IssueTracker target,
            string userName,
            string password
        )
        {
            string result = target.LoginUser(userName, password);
            return result;
            // TODO: add assertions to method IssueTrackerTest.LoginUser(IssueTracker, String, String)
        }

        [PexMethod]
        public string LogoutUser([PexAssumeUnderTest]IssueTracker target)
        {
            string result = target.LogoutUser();
            return result;
            // TODO: add assertions to method IssueTrackerTest.LogoutUser(IssueTracker)
        }

        [PexMethod]
        public string RegisterUser(
            [PexAssumeUnderTest]IssueTracker target,
            string userName,
            string password,
            string confirmPassword
        )
        {
            string result = target.RegisterUser(userName, password, confirmPassword);
            return result;
            // TODO: add assertions to method IssueTrackerTest.RegisterUser(IssueTracker, String, String, String)
        }

        [PexMethod]
        public string RemoveIssue([PexAssumeUnderTest]IssueTracker target, int issueId)
        {
            string result = target.RemoveIssue(issueId);
            return result;
            // TODO: add assertions to method IssueTrackerTest.RemoveIssue(IssueTracker, Int32)
        }
    }
}
