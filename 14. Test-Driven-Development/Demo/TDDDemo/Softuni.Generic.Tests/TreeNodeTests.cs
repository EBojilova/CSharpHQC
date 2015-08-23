// ReSharper disable InconsistentNaming
namespace Softuni.Generic.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Softuni.Collections.Generic.Tree;

    [TestClass]
    public class TreeNodeTests
    {
        [TestMethod]
        public void Test_TreeNodeEmptyConstructor_ShouldCreateTheTreeNode()
        {
            var node = new TreeNode<int>();
            Assert.IsNotNull(node);
        }

        [TestMethod]
        public void Test_TreeNodeEmptyConstructor_WithValueTypes_ShouldHaveTheDefaultValue()
        {
            var node = new TreeNode<int>();
            Assert.AreEqual(default(int), node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeEmptyStringConstructor_WithReferenceTypes_ShouldHaveTheDefaultValue()
        {
            var node = new TreeNode<string>();
            Assert.AreEqual(default(string), node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeEmptyConstructor_WithValueTypes_ShouldHaveTheRequestedValue()
        {
            var node = new TreeNode<int>(5);
            Assert.AreEqual(5, node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeEmptyStringConstructor_WithReferenceTypes_ShouldHaveTheRequestedValue()
        {
            var node = new TreeNode<List<string>>(new List<string> { "Pesho", "Gosho" });

            Assert.IsInstanceOfType(node.Value, typeof(List<string>));
            CollectionAssert.AreEqual(new List<string> { "Pesho", "Gosho" }, node.Value);
        }

        [TestMethod]
        public void Test_TreeNodeConstructor_WithValueTypes_ShouldHaveChildren()
        {
            var node = new TreeNode<int>(5);
            Assert.IsNotNull(node.Children);
            Assert.AreEqual(0, node.Children.Count);
        }

        [TestMethod]
        public void Test_TreeNodeConstructor_WithValueTypes_WithChildren_ShouldHaveRequestedChildren()
        {
            var node = new TreeNode<int>(5, new List<TreeNode<int>>());
            Assert.IsNotNull(node.Children);
            Assert.AreEqual(0, node.Children.Count);
        }

        [TestMethod]
        public void Test_TreeNodeConstructor_WithValueTypes_WithNotEmptyChildren_ShouldHaveRequestedChildren()
        {
            var firstChild = new TreeNode<int>(2);
            var secondChild = new TreeNode<int>(4);
            var thirdChild = new TreeNode<int>(6);
            var children = new List<TreeNode<int>> { firstChild, secondChild, thirdChild };
            var node = new TreeNode<int>(5, children);
            Assert.IsNotNull(node.Children);
            Assert.AreEqual(3, node.Children.Count);
            Assert.AreSame(firstChild, node.Children[0]);
            Assert.AreSame(secondChild, node.Children[1]);
            Assert.AreSame(thirdChild, node.Children[2]);
        }
    }
}