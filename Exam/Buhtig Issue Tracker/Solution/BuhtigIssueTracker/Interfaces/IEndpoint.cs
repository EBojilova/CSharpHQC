namespace BuhtigIssueTracker.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IEndpoint
    {
        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
