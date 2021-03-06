using BuhtigIssueTracker;
// <copyright file="IssueTrackerFactory.cs">Copyright ©  2015</copyright>

using System;
using Microsoft.Pex.Framework;

namespace BuhtigIssueTracker
{
    /// <summary>A factory for BuhtigIssueTracker.IssueTracker instances</summary>
    public static partial class IssueTrackerFactory
    {
        /// <summary>A factory for BuhtigIssueTracker.IssueTracker instances</summary>
        [PexFactoryMethod(typeof(IssueTracker))]
        public static IssueTracker Create()
        {
            IssueTracker issueTracker = new IssueTracker();
            return issueTracker;

            // TODO: Edit factory method of IssueTracker
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
