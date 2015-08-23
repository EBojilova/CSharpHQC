namespace DoFactoryDemo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    internal class LoadBalancer
    {
        // Lock synchronization object
        private static readonly object SyncLock = new object();

        private static LoadBalancer instance;

        private readonly Random random = new Random();

        private readonly List<string> servers = new List<string>();

        // Constructor (protected)
        protected LoadBalancer()
        {
            // List of available servers
            this.servers.Add("ServerI");
            this.servers.Add("ServerII");
            this.servers.Add("ServerIII");
            this.servers.Add("ServerIV");
            this.servers.Add("ServerV");
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                var r = this.random.Next(this.servers.Count);
                return this.servers[r];
            }
        }

        public static LoadBalancer Balancer
        {
            get
            {
                // Support multithreaded applications through
                // 'Double checked locking' pattern which (once
                // the instance exists) avoids locking each
                // time the method is invoked
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncLock)
                {
                    if (instance == null)
                    {
                        instance = new LoadBalancer();
                    }
                }

                return instance;
            }
        }
    }
}