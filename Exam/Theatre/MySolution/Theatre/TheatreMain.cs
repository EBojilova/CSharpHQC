/*//////////////////////////////////////
     ///                                  ///
    ///   Author: Huy Phuong Nguyen,     ///
   ///   Qui Nhơn, Bình Định, Vietnam   ///
  ///   Email: huy_p_n@yahoo.vn        ///
 ///                                  ///
//////////////////////////////////////*/
namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal class TheatreMain
    {
        private static readonly CommandManager CommandManager = new CommandManager();

        protected static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            string data;
            while ((data = Console.ReadLine()) != null)
            {
                if (data == string.Empty)
                {
                    continue;
                }

                string output;
                try
                {
                    output = CommandManager.CommandExecute(data);
                }
                catch (Exception ex)
                {
                    output = "Error: " + ex.Message;
                }

                Console.WriteLine(output);
            }
        }
    }
}