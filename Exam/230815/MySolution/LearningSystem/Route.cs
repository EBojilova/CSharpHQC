namespace LearningSystem
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using LearningSystem.Interfaces;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public IDictionary<string, string> ActionParameters { get; private set; }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        private void Parse(string routeUrl)
        {
            var parts = routeUrl.Split(new[] { "/", "?" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
            {
                throw new InvalidOperationException("The provided route is invalid.");
            }

            this.ControllerName = parts[0] + "Controller";
            this.ActionName = parts[1];
            if (parts.Length < 3)
            {
                return;
            }

            this.ActionParameters = new Dictionary<string, string>();
            var parameterPairs = parts[2].Split('&');
            foreach (var pair in parameterPairs)
            {
                var pairNameValue = pair.Split('=');
                this.ActionParameters.Add(WebUtility.UrlDecode(pairNameValue[0]), WebUtility.UrlDecode(pairNameValue[1]));
            }
        }
    }
}