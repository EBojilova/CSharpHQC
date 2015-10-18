 // ReSharper disable All

namespace LearningSystem.ManualTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ViewTests
    {
        [TestMethod]
        public void Display_ReturnsCorrectResult()
        {
            // special class we create View Mock, so we can mock View
            var view = new ViewMock("Test");
            var result = view.Display();
            Assert.AreEqual("Test", result);
        }

        [TestMethod]
        public void Display_ReturnsCorrectResultTrimmed()
        {
            var view = new ViewMock(" Test ");
            var result = view.Display();
            Assert.AreEqual("Test", result);
        }

        [TestMethod]
        public void Display_ReturnStringResult()
        {
            // special class we create View Mock, so we can mock View
            var view = new ViewMock(5);
            var result = view.Display();
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void Display_ReturnEmptyString()
        {
            // special class we create View Mock, so we can mock View
            var view = new ViewMock(null);
            var result = view.Display();
            Assert.AreEqual("", result);
        }
    }
}