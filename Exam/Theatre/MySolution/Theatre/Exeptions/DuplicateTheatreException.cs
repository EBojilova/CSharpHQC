using System;

namespace Theatre.Exeptions
{
    public class DuplicateTheatreException : Exception
    {
        public DuplicateTheatreException(string msg)
            : base(msg)
        {
        }
    }
}