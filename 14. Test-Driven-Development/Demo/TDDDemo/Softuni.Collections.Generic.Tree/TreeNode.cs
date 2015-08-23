namespace Softuni.Collections.Generic.Tree
{
    using System.Collections.Generic;

    public class TreeNode<T>
    {
        public TreeNode(T value, IList<TreeNode<T>> children)
        {
            this.Value = value;
            this.Children = children;
        }

        public TreeNode(T value)
            : this(value, new List<TreeNode<T>>())
        {
        }

        public TreeNode()
            : this(default(T))
        {
        }

        public T Value { get; private set; }

        public IList<TreeNode<T>> Children { get; private set; }
    }
}