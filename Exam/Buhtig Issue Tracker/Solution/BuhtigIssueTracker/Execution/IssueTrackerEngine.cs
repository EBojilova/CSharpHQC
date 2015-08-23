namespace BuhtigIssueTracker.Execution
{
    using System;
    using BuhtigIssueTracker.Interfaces;
    using BuhtigIssueTracker.UserInterface;

    public class IssueTrackerEngine : IEngine
    {
        private EndpointActionDispatcher dispatcher;
        private IUserInterface userInterface;

        public IssueTrackerEngine(EndpointActionDispatcher dispatcher, IUserInterface userInterface)
        {
            this.dispatcher = dispatcher;
            this.userInterface = userInterface;
        }

        public IssueTrackerEngine()
            : this(new EndpointActionDispatcher(), new ConsoleInterface())
        {
        }

        public void Run()
        {
            while (true)
            {
                string url = this.userInterface.ReadLine();
                if (url == null)
                {
                    break;
                }

                url = url.Trim();
                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var endpoint = new Endpoint(url);
                        string viewResult = this.dispatcher.DispatchAction(endpoint);
                        this.userInterface.WriteLine(viewResult);
                    }
                    catch (Exception ex) 
                    {
                        this.userInterface.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
