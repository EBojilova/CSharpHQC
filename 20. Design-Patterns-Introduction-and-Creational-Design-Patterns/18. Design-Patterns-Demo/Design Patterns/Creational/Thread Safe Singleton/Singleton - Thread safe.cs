namespace ThreadSafeSingleton
{
    public sealed class SingletonThreadSafe
    {
        private static volatile SingletonThreadSafe instance;

        // volatile modifier is used to show that the variable will be accessed by multiple threads concurrently.
        private static readonly object SyncLock = new object();

        private SingletonThreadSafe()
        {
        }

        public static SingletonThreadSafe Instance
        {
            get
            {
                if (instance != null)
                {
                    return instance;
                }

                lock (SyncLock)
                {
                    if (instance == null)
                    {
                        instance = new SingletonThreadSafe();
                    }
                }

                return instance;
            }
        }
    }
}