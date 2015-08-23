namespace Decorator
{
    using System;

    using global::Decorator.LibraryItems;

    internal class DecoratorMain
    {
        internal static void Main()
        {
            // Create book
            var book = new Book("Microsoft", "CLR via C# 3", 10);
            book.Display();

            // Create video
            var video = new Video("Stanley Kubrick", "A Clockwork Orange", 23, 92);
            video.Display();

            // Make video borrowable, then borrow and display
            Console.WriteLine("\nMaking video borrowable:");

            var borrowableVideo = new Borrowable(video);
            borrowableVideo.BorrowItem("Georgi Bastunov");
            borrowableVideo.BorrowItem("Pesho Georgiev");

            borrowableVideo.Display();

            var game = new Game("Unknown", "League of Legends", 23, 100);
            var borrowableGame = new Borrowable(game);
            borrowableGame.Display();
        }
    }
}