namespace BangaloreUniversityLearningSystem.Exeptions
{
    using System;

    internal class AuthorizationFailedException : Exception
    {
        public AuthorizationFailedException(string message)
            : base(message)
        {
        }
    }
}