namespace Tree
{
    public class Tree<T> : ITree<T>
    {
        public Tree(ITreeNode<T> node)
        {
            this.Root = node;
        }

        public Tree()
            : this(null)
        {
        }

        public Tree(T value)
        {
            this.Root = new TreeNode<T>(value);
        }

        public ITreeNode<T> Root { get; set; }
    }
}