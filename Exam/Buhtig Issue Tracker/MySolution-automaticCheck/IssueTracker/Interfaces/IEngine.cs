namespace IssueTracker.Interfaces
{
    internal interface IEngine
    {
        IDispatcher Dispatcher { get; }

        IUserInterface UserInterface { get; }

        void Run();
    }
}