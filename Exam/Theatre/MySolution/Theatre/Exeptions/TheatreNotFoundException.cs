namespace Theatre.Exeptions
{
    using System;

    public class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string msg)
            : base(msg)
        {
        }
    }
}