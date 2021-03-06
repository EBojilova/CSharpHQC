// <copyright file="IssueTrackerTest.cs">Copyright ©  2015</copyright>

namespace BuhtigIssueTracker.Tests
{
    using System;

    using Microsoft.Pex.Framework;
    using Microsoft.Pex.Framework.Validation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    [PexClass(typeof(IssueTracker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class IssueTrackerTest
    {
        [PexMethod]
        public string RegisterUser(
            [PexAssumeUnderTest] IssueTracker target,
            string userName,
            string password,
            string confirmPassword)
        {
            var result = target.RegisterUser(userName, password, confirmPassword);
            return result;
            // TODO: add assertions to method IssueTrackerTest.RegisterUser(IssueTracker, String, String, String)
        }

        [PexMethod]
        public string AddComment([PexAssumeUnderTest] IssueTracker target, int issueId, string commentText)
        {
            var result = target.AddComment(issueId, commentText);
            return result;
            // TODO: add assertions to method IssueTrackerTest.AddComment(IssueTracker, Int32, String)
        }
    }
}