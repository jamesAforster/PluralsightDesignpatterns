using System.Diagnostics.Tracing;

namespace Decorator
{
    /// <summary>
    /// Component (As interface)
    /// </summary>
    public interface IMailService
    {
        bool SendMail(string message);
    }

    /// <summary>
    /// ConcreteComponent 1
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" + $sent via {nameof(CloudMailService)}.");
            return true;
        }
    }
    
    /// <summary>
    /// ConcreteComponent 2
    /// </summary>
    public class OnPremisesMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message \"{message}\" + sent via {nameof(OnPremisesMailService)}.");
            return true;
        }
    }

    /// <summary>
    /// Decorator
    /// </summary>
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;

        public MailServiceDecoratorBase(IMailService mailService)
        {
            _mailService = mailService;
        }
        
        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);
        }
    }
    
    /// <summary>
    /// ConcreteDecorator 1
    /// </summary>
    public class StatisticsDecorator : MailServiceDecoratorBase
    {
        public StatisticsDecorator(IMailService mailService) : base(mailService) { }
        
        public override bool SendMail(string message)
        {
            Console.WriteLine($"Collecting statistics in {nameof(StatisticsDecorator)}");
            return base.SendMail(message);
        }
    }
    
    /// <summary>
    /// ConcreteDecorator 2
    /// </summary>
    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        /// <summary>
        /// A list of sent messages - a "fake" database
        /// </summary>
        /// <param name="mailService"></param>
        public List<string> SentMessages { get; private set; } = new List<string>();
        
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService) { }
        
        public override bool SendMail(string message)
        {
            if (base.SendMail(message))
            {
                // Store sent message
                SentMessages.Add(message);
                return true;
            }

            return false;
        }
    }
}