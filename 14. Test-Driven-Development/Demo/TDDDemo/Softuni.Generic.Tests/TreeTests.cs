 // ReSharper disable InconsistentNaming

namespace Softuni.Generic.Tests
{
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Softuni.Collections.Generic.Tree;

    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void Test_TreeConstructor_ShouldCreateAnEmptyTree()
        {
            var root = new TreeNode<int>();
            var tree = new Tree<int>(root);

            Assert.AreSame(root, tree.Root);
            Assert.IsNotNull(tree.Root.Children);
            Assert.AreEqual(0, tree.Root.Children.Count);
        }

        [TestMethod]
        public void Test_TreeConstructor_WithChildren_ShouldCreateAnNoneEmptyTree()
        {
            var firstChild = new TreeNode<int>(2);
            var secondChild = new TreeNode<int>(4);
            var thirdChild = new TreeNode<int>(6);
            var children = new List<TreeNode<int>> { firstChild, secondChild, thirdChild };
            var root = new TreeNode<int>(5, children);
            var tree = new Tree<int>(root);
            Assert.AreSame(root, tree.Root);
            Assert.IsNotNull(tree.Root.Children);
            Assert.AreEqual(3, tree.Root.Children.Count);
            Assert.AreSame(firstChild, tree.Root.Children[0]);
            Assert.AreSame(secondChild, tree.Root.Children[1]);
            Assert.AreSame(thirdChild, tree.Root.Children[2]);
        }
    }
}