    using System;
    using System.Globalization;
    using System.Threading;
using System.Security.Cryptography;
using System.Text;

    using buhtig.Core;

class Program
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var e = new Engine();
            e.Run();
        }
    }
