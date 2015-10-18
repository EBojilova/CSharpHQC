namespace IssueTracker.Interfaces
{
    public interface IDispatcher
    {
        string DispatchAction(IEndpoint endpoint);
    }
}