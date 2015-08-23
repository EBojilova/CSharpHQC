using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System.Collections.Generic;

namespace Tree.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void TestCreateEmptyNode()
        {
            ITreeNode<int> node = new TreeNode<int>(0);
            Assert.AreEqual(0, node.Value);
            Assert.IsNotNull(node.Children);
        }

        [TestMethod]
        public void TestCreateEmptyNodeWithObject()
        {
            ITreeNode<StringBuilder> node = new TreeNode<StringBuilder>();
            Assert.IsNull(node.Value);
        }

        [TestMethod]
        public void TestCreateNonEmptyNodeWithObject()
        {
            var stringBuilder = new StringBuilder();
            ITreeNode<StringBuilder> node =
                new TreeNode<StringBuilder>(stringBuilder);
            Assert.AreSame(stringBuilder, node.Value);
        }

        [TestMethod]
        public void TestCreateNonEmptyNodeWithCollection()
        {
            var collection = new LinkedList<int>();
            var node = new TreeNode<LinkedList<int>>(collection);
            Assert.AreSame(collection, node.Value);
        }
    }
}
