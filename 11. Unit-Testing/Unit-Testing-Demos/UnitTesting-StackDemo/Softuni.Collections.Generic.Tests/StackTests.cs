namespace Softuni.Collections.Generic.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    //// using SCG = System.Collections.Generic;
    [TestClass]
    public class StackTests
    {
        private const int DefaultCapacity = 4;

        ////private Stack<int> stack; // po-dobre da pravim inicializirane vav vseki test metod, za da ne stane mutirane na stack v niakoi ot metodite

        ////[TestInitialize]
        ////public void IntitializeStack()
        ////{
        ////    this.stack = new Stack<int>();
        ////}

        // ReSharper disable once InconsistentNaming
        public void Test_StackConstructor_CreateEmptyStack_ShouldHaveNoItems()
        {
            // Arrange
            var stack = new Stack<int>();

            //// SCG.Stack<int> systemStack = new SCG.Stack<int>(); -taka mojem da izvikame vgradenia Stack, ne nashia
            // Act
            // Assert
            Assert.IsNotNull(stack);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(DefaultCapacity, stack.Capacity);
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_StackConstructor_CreateStackWithGivenCapacity_ShouldHaveNoItems()
        {
            // Arrange
            var capacity = 10;
            var stack = new Stack<int>(capacity);

            // Act
            // Assert
            Assert.IsNotNull(stack);
            Assert.AreEqual(0, stack.Count);
            Assert.AreEqual(capacity, stack.Capacity);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]

        // ReSharper disable once InconsistentNaming
        public void Test_StackConstructor_CreateStackWithZeroCapacity_ShouldHaveNoItems()
        {
            // Arrange
            var capacity = 0;
            var stack = new Stack<int>(capacity);

            // Act
            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Stack whit non positive capacity should trow exeption.")]

        // ReSharper disable once InconsistentNaming
        public void Test_StackConstructor_CreateStackWithNegativeCapacity_ShouldTrowExeption()
        {
            // Arrange
            var capasicy = -10;
            var stack = new Stack<int>(capasicy);

            // Act
            // Assert
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_PushToEmptyStack_ShouldAddTheItem()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Push(1);

            // Assert
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_PushManyItemsToEmptyStack_ShouldAddTheItems()
        {
            // Arrange
            var stack = new Stack<int>();
            var itemsCount = 10;

            // Act
            for (var item = 0; item < itemsCount; item++)
            {
                stack.Push(item);
            }

            // Assert
            Assert.AreEqual(itemsCount, stack.Count);
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_PushNullItemsToEmptyStack_ShouldAddTheItems()
        {
            // Arrange
            var stack = new Stack<string>();
            var itemsCount = 10;

            // Act
            for (var item = 0; item < itemsCount; item++)
            {
                stack.Push(null);
            }

            // Assert
            Assert.AreEqual(itemsCount, stack.Count);
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_PopItemFromStack_ShouldReturnTheItem()
        {
            // Arrange
            var stack = new Stack<int>();
            var expectedTopValue = 5;
            stack.Push(expectedTopValue);

            // Act
            var actualTopValue = stack.Pop();

            // Assert
            Assert.AreEqual(expectedTopValue, actualTopValue);
            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_PopManyItemsFromStack_ShouldReturnTheItemsInCorrectOrder()
        {
            // Arrange
            var stack = new Stack<int>();
            var itemsCount = 10;
            var expectedItems = new int[itemsCount];
            for (var item = 0; item < itemsCount; item++)
            {
                stack.Push(item);
                expectedItems[item] = item;
            }

            // Act: We do not have to put this.items.Coutn for the end of iteration, because after the pop the counts changes
            var returnedItems = new int[itemsCount];
            for (var item = 0; item < itemsCount; item++)
            {
                returnedItems[item] = stack.Pop();
            }

            Array.Reverse(returnedItems);
            Assert.AreEqual(0, stack.Count);

            // Assert
            CollectionAssert.AreEqual(expectedItems, returnedItems);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Empty Stack should trow exeption.")]

        // ReSharper disable once InconsistentNaming
        public void Test_PopItemsFromEmptyStack_ShouldReturnInvalidOperationExeption()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Pop();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Empty Stack should trow exeption.")]

        // ReSharper disable once InconsistentNaming
        public void Test_TooManyPopsFromStack_ShouldReturnInvalidOperationExeption()
        {
            // Arrange
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);

            // Act
            var count = stack.Count + 1;
            for (var i = 0; i < count; i++)
            {
                stack.Pop();
            }

            // Assert
        }

        [TestMethod]

        // ReSharper disable once InconsistentNaming
        public void Test_PeakItemFromStack_ShouldReturnTheTopItem()
        {
            // Arrange
            var stack = new Stack<int>();
            var expectedTopValue = 5;
            for (var i = 0; i < expectedTopValue; i++)
            {
                stack.Push(i + 1);
            }

            // Act
            var actualTopValue = stack.Peak();

            // Assert
            Assert.AreEqual(expectedTopValue, actualTopValue);
            Assert.AreEqual(expectedTopValue, stack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Empty Stack should trow exeption.")]

        // ReSharper disable once InconsistentNaming
        public void Test_PeakItemFromEmptyStack_ShouldReturnInvalidOperationExeption()
        {
            // Arrange
            var stack = new Stack<int>();

            // Act
            stack.Peak();

            // Assert
        }
    }
}