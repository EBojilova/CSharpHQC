namespace BULSTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ViewTests
    {
        [TestMethod]
        public void Display_ShouldReturnAStringResult()
        {
            var test = "Test";
            var createView = new MockView(test);
            var result = createView.Display();

            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void Display_ShouldReturnCorrectResult()
        {
            var test = "Test";
            var createView = new MockView(test);
            var result = createView.Display();

            Assert.AreEqual(test, result);
        }

        [TestMethod]
        public void Display_ShouldTrimResult()
        {
            var test = " Test ";
            var createView = new MockView(test);
            var result = createView.Display();

            Assert.AreEqual("Test", result);
        }
    }
}