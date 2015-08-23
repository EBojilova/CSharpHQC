namespace Softuni.Collections.Generic.Tree
{
    public class Tree<T>
    {
        public Tree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public TreeNode<T> Root { get; private set; }
    }
}