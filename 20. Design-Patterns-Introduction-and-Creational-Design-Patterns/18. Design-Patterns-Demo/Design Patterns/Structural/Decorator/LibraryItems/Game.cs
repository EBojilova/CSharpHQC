namespace Decorator.LibraryItems
{
    using System;

    /// <summary>
    /// The 'ConcreteComponent' class
    /// </summary>
    internal class Game : LibraryItem
    {
        private readonly string author;
        private readonly string title;
        private readonly int edition;

        public Game(string author, string title, int copiesCount, int edition)
        {
            this.author = author;
            this.title = title;
            this.CopiesCount = copiesCount;
            this.edition = edition;
        }

        public override void Display()
        {
            Console.WriteLine("\nGame ----- ");
            Console.WriteLine(" Author: {0}", this.author);
            Console.WriteLine(" Title: {0}", this.title);
            Console.WriteLine(" # Copies: {0}", this.CopiesCount);
            Console.WriteLine(" Edition: {0}\n", this.edition);
        }
    }
}
