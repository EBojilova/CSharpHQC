using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tree.Tests
{
    [TestClass]
    public class TreeTests
    {
        [TestMethod]
        public void CreateTreeWithIntegerRoot()
        {
            ITree<int> tree = new Tree<int>(5);
            Assert.AreEqual(5, tree.Root.Value);
            Assert.IsNotNull(tree.Root);
        }

        [TestMethod]
        public void CreateTreeWithEmptyRoot()
        {
            ITree<int> tree = new Tree<int>();
            Assert.IsNull(tree.Root);
        }

        [TestMethod]
        public void CreateTreeWithRootByReference()
        {
            ITreeNode<int> node = new TreeNode<int>(5);
            ITree<int> tree = new Tree<int>(node);
            Assert.AreSame(node, tree.Root);
        }

        [TestMethod]
        public void CreateTreeWithChildrenNodes()
        {
            var nodes = new List<ITreeNode<int>>();
            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new TreeNode<int>(i * 5));
            }

            ITree<int> tree = new Tree<int>(0);
            tree.Root.Children = nodes;
            Assert.AreEqual(10, tree.Root.Children.Count());
        }

        [TestMethod]
        public void CheckChildrenNodesValues()
        {
            var nodes = new List<ITreeNode<int>>();
            for (int i = 0; i < 10; i++)
            {
                nodes.Add(new TreeNode<int>(i * 5));
            }

            ITree<int> tree = new Tree<int>(0);
            tree.Root.Children = nodes;
            Assert.AreEqual(0, tree.Root.Children.First().Value);
            Assert.AreEqual(5, tree.Root.Children.Skip(1).First().Value);
        }

        [TestMethod]
        public void CheckChildrenInDepth()
        {
            ITree<int> tree = new Tree<int>(0);
            tree.Root.Children.Add(new TreeNode<int>(5));
            var node = tree.Root.Children.First();
            node.Children.Add(new TreeNode<int>(10));

            Assert.AreEqual(0, tree.Root.Value);
            Assert.AreEqual(1, tree.Root.Children.Count());
            Assert.AreEqual(5, node.Value);
            Assert.AreEqual(1, node.Children.Count());
            Assert.AreEqual(10, node.Children.First().Value);
        }
    }
}
