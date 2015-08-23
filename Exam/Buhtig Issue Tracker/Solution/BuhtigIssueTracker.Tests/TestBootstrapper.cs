namespace BuhtigIssueTracker.Tests
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestBootstrapper
    {
        protected IssueTracker tracker { get; private set; }

        [TestInitialize]
        public void InitializeTests()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            this.tracker = new IssueTracker();
        }
    }
}
