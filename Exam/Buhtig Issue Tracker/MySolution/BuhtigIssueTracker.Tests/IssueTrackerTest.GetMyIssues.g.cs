using Microsoft.Pex.Framework.Generated;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BuhtigIssueTracker;
// <copyright file="IssueTrackerTest.GetMyIssues.g.cs">Copyright ©  2015</copyright>
// <auto-generated>
// This file contains automatically generated tests.
// Do not modify this file manually.
// 
// If the contents of this file becomes outdated, you can delete it.
// For example, if it no longer compiles.
// </auto-generated>
using System;

namespace BuhtigIssueTracker.Tests
{
    public partial class IssueTrackerTest
    {

[TestMethod]
[PexGeneratedBy(typeof(IssueTrackerTest))]
public void GetMyIssues811()
{
    IssueTracker issueTracker;
    string s;
    issueTracker = new IssueTracker();
    s = this.GetMyIssues(issueTracker);
    Assert.AreEqual<string>("There is no currently logged in user", s);
    Assert.IsNotNull((object)issueTracker);
}
    }
}
