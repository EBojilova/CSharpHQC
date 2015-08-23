namespace Theatre.Exeptions
{
    using System;

    public class TimeDurationOverlapException : Exception
    {
        public TimeDurationOverlapException(string msg)
            : base(msg)
        {
        }
    }
}