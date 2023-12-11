namespace Singleton
{
    /// <summary>
    ///  Singleton
    /// </summary>
    public class Logger
    {
        // Lazy<T>
        private static readonly Lazy<Logger> _lazyLogger = new Lazy<Logger>(() => new Logger()); 
        // C# has its own Lazy<> class which provides support for lazy instantiation.
        // This class provides thread safety as well.
        // our manual implementation is not thread safe,
        // because if two threads try to create an instance at exactly the same time, they may be able to do so.
            
        private static Logger? _instance;
        
        /// <summary>
        /// Instance
        /// </summary>
        public static Logger Instance  // Needs to be static as it is bound to the class, but not bound to an an instance of the class.
        {
            get
            {
                // return _lazyLogger.Value;
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                
                return _instance;
            }
        }

        // Protected constructor means that clients cannot instantiate it, it can only be accessed in this class OR in a class derived from this class.
        // Private - accessible only in this class
        // Protected - accessible only in this class, or classes which inherit from it
        protected Logger()
        {
            
        }
        
        public void Log(string message)
        {
            Console.WriteLine($"Message to log: {message}");
        }
    }
}