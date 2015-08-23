namespace BuhtigIssueTracker.Execution
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using BuhtigIssueTracker.Interfaces;

    public class Endpoint : IEndpoint
    {
        public Endpoint(string urlString)
        {
            this.ParseEndpointParts(urlString);
        }

        public string ActionName { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }

        private void ParseEndpointParts(string urlString)
        {
            int actionNameEnd = urlString.IndexOf('?');
            if (actionNameEnd != -1)
            {
                this.ActionName = urlString.Substring(0, actionNameEnd);
                this.Parameters = this.ParseParameters(urlString.Substring(actionNameEnd + 1));
            }
            else
            {
                this.ActionName = urlString;
            }
        }

        private IDictionary<string, string> ParseParameters(string parametersAsString)
        {
            var pairs = parametersAsString
                .Split('&')
                .Select(pair => pair
                    .Split('=')
                    .Select(pairPart => WebUtility.UrlDecode(pairPart))
                    .ToArray());
            var parameters = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                parameters.Add(pair[0], pair[1]);
            }

            return parameters;
        }
    }
}
