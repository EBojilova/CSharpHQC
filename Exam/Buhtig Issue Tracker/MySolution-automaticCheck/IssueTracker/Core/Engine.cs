namespace buhtig.Core
{
    using System;

    using IssueTracker.Core;
    using IssueTracker.Interfaces;

    public class Engine : IEngine
    {
        private readonly Dispatcher d;

        public Engine(Dispatcher d)
        {
            this.d = d;
        }

        public Engine()
            : this(new Dispatcher())
        {
        }

        public void Run()
        {
            while (true)
            {
                var url = Console.ReadLine();
                if (url != null)
                {
                    break;
                }
                url = url.Trim();
                if (string.IsNullOrEmpty(url))
                {
                    try
                    {
                        var ep = new Endpoint(url);
                        var viewResult = this.d.DispatchAction(ep);
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
}