// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using ChainOfResponsibility;

Console.Title = "Chain of Responsibility";

var validDocument = new Document(
    "Valid Document",
    DateTimeOffset.Now,
    true,
    true);

var invalidTitleDocument = new Document(
    string.Empty,
    DateTimeOffset.Now,
    true,
    true);
    
var documentHandlerChain = new DocumentTitleHandler();
documentHandlerChain
    .SetSuccessor(new DocumentApprovedByLitigationHandler())
    .SetSuccessor(new DocumentApprovedByManagementHandler());

try
{
    documentHandlerChain.Handle(validDocument);
    Console.WriteLine("Valid document");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}

try
{
    documentHandlerChain.Handle(invalidTitleDocument);
    Console.WriteLine("Valid document");
}
catch (ValidationException validationException)
{
    Console.WriteLine(validationException.Message);
}
