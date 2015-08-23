namespace BuhtigIssueTracker.Execution
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using BuhtigIssueTracker.Interfaces;

    // This is URL
    public class Endpoint : IEndpoint
    {
        public Endpoint(string url)
        {
            var questionMarkIndex = url.IndexOf('?');
            if (questionMarkIndex != -1)
            {
                this.CreateEndPointWithParameters(url, questionMarkIndex);
            }
            else
            {
                this.ActionName = url;
            }
        }

        public string ActionName { get; set; }

        public IDictionary<string, string> ActionParameters { get; set; }

        private void CreateEndPointWithParameters(string url, int questionMarkIndex)
        {
            this.ActionName = url.Substring(0, questionMarkIndex);
            var pairs =
                url.Substring(questionMarkIndex + 1)
                    .Split('&')
                    .Select(x => x.Split('=').Select(xx => WebUtility.UrlDecode(xx)).ToArray());
            var actionParameters = new Dictionary<string, string>();
            foreach (var pair in pairs)
            {
                actionParameters.Add(pair[0], pair[1]);
            }

            this.ActionParameters = actionParameters;
        }
    }
}