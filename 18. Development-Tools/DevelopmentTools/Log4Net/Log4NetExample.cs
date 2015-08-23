namespace Log4Net
{
    using System.Diagnostics.CodeAnalysis;

    using log4net;
    using log4net.Config;

    internal class Log4NetExample
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Log4NetExample));

        private static void Main()
        {
            BasicConfigurator.Configure();
            Log.Debug("Debug message");
            Log.Error("Error message");

            Sum(1, 3);
        }

        private static void Sum(int a, int b)
        {
            Log.WarnFormat("Summed {0} and {1}", a, b);
        }
    }
}