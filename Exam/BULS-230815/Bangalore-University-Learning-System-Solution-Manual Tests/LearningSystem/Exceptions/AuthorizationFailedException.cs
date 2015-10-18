namespace LearningSystem.Exceptions
{
    using System;

    public class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string message)
            : base(message)
        {
        }
    }
}