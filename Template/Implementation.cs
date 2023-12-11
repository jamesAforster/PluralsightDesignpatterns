namespace Template
{
    /// <summary>
    /// AbstractClass
    ///
    public abstract class MailParser
    {
        protected virtual void FindServer() // Protected as can be overridden by subclasses
        {
            Console.WriteLine("Finding server...");
        }

        protected abstract void AuthenticateToServer(); // Protected as can be overridden by subclasses

        private string ParseHtmlMailBody(string identifier) // Private as cannot be overridden by subclasses
        {
            Console.WriteLine("Parsing HTML mail body...");
            return $"This is the body of mail with id {identifier}";
        }

        /// <summary>
        /// Template method
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public string ParseMailBody(string identifier)
        {
            Console.WriteLine("Parsing mail body (in template method)...");
            FindServer();
            AuthenticateToServer();
            return ParseHtmlMailBody(identifier);
        }
    }

    public class ExchangeMailParser : MailParser
    {
        protected override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Exchange server...");
        }
    }

    public class ApacheMailParser : MailParser
    {
        protected override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Apache server...");
        }
    }
    
    public class EudoraMailParser : MailParser
    {
        protected override void FindServer()
        {
            Console.WriteLine("Finding Eudora server through custom algorithm...");
        }
        protected override void AuthenticateToServer()
        {
            Console.WriteLine("Connecting to Eudora server...");
        }
    }
}