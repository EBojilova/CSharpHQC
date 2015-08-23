namespace DoFactory.GangOfFour.Singleton.RealWorld
{
    using System;

    using DoFactoryDemo;

    /// <summary>
    /// MainApp startup class for Real-World 
    /// Singleton Design Pattern.
    /// </summary>
    internal class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        private static void Main()
        {
            ////var b1 = LoadBalancer.GetLoadBalancer();
            ////var b2 = LoadBalancer.GetLoadBalancer();
            ////var b3 = LoadBalancer.GetLoadBalancer();
            ////var b4 = LoadBalancer.GetLoadBalancer();
            ////Used prperty instead of method.
            var b1 = LoadBalancer.Balancer;
            var b2 = LoadBalancer.Balancer;
            var b3 = LoadBalancer.Balancer;
            var b4 = LoadBalancer.Balancer;

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            ////var balancer = LoadBalancer.GetLoadBalancer();
            var balancer = LoadBalancer.Balancer;
            for (var i = 0; i < 15; i++)
            {
                var server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            // Wait for user
            Console.ReadKey();
        }
    }
}