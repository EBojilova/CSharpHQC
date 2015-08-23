namespace BuhtigIssueTracker.Execution
{
    using System;

    using BuhtigIssueTracker.Interfaces;

    public class Engine : IEngine
    {
        private readonly Dispatcher dispathcer;

        public Engine(Dispatcher dispathcer)
        {
            this.dispathcer = dispathcer;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            string url;
            while ((url = Console.ReadLine()) != null)
            {
                url = url.Trim();
                if (string.IsNullOrEmpty(url))
                {
                    continue;
                }

                try
                {
                    var endPoint = new Endpoint(url);
                    var viewResult = this.dispathcer.DispatchAction(endPoint);
                    Console.WriteLine(viewResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}