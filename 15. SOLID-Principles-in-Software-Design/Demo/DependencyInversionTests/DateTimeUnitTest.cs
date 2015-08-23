// ReSharper disable InconsistentNaming
namespace DependencyInversionTests
{
    using System;

    using DependencyInversionHelloWorldAfter;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DateTimeUnitTest
    {
        [TestMethod]
        public void Test_GrretAt5PM_ShouldRetunrGoodEvenig()
        {
            var greeting = new HelloWorld(new DateTime(2000, 12, 22, 19, 30,30));

            var greetingMessage = greeting.Greet("Eli");

            Assert.AreEqual("Good evening, Eli", greetingMessage);
        }
    }
}