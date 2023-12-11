using Template;

ExchangeMailParser exchangeMailParser = new ExchangeMailParser();
Console.WriteLine(exchangeMailParser.ParseMailBody(Guid.NewGuid().ToString())); 
// we call the same method on all subclasses, but the implementation is different for each subclass

Console.WriteLine();

ApacheMailParser apacheMailParser = new ApacheMailParser();
Console.WriteLine(apacheMailParser.ParseMailBody(Guid.NewGuid().ToString()));

Console.WriteLine();

EudoraMailParser eudoraMailParser = new EudoraMailParser();
Console.WriteLine(eudoraMailParser.ParseMailBody(Guid.NewGuid().ToString()));

Console.WriteLine();

Console.ReadKey();