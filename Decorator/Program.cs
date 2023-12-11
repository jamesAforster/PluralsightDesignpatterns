using Decorator;

// Instantiate mail services
var cloudMailService = new CloudMailService();
cloudMailService.SendMail("Hi there.");

var onPremiseMailservice = new OnPremisesMailService();
onPremiseMailservice.SendMail("Hi there.");

// Add the behaviour implemented in the StatisticsDecorator
var statisticDecorator = new StatisticsDecorator(cloudMailService);
statisticDecorator.SendMail($"Hi there via {nameof(statisticDecorator)} wrapper");

// Add the behaviour implemented in the MessageDatabaseDecorator
var messageDatabaseDecorator = new MessageDatabaseDecorator(onPremiseMailservice);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 1.");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(MessageDatabaseDecorator)} wrapper, message 2.");

foreach (var message in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine($"Stored Message: \"{message}\"");
}

Console.ReadKey();