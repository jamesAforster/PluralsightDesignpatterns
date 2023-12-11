// without proxy

using System.Diagnostics;

Console.WriteLine("Constructing a document...");
// expensive operation
// you might not need to display the document, but you would still load it
var myDocument = new Proxy.Document("MyDocument.pdf");
myDocument.DisplayDocument();

// with Proxy
Console.WriteLine("Constructing a document...");
// We have not yet loaded the document by initialization
var myDocumentViaProxy = new Proxy.DocumentProxy("MyDocument.pdf");
myDocumentViaProxy.DisplayDocument();

//  with Chained Proxy
Console.WriteLine("Constructing protected document proxy.");
var myProtectedDocumentProxy = new Proxy.ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
Console.WriteLine("Protected document proxy constructed.");
myProtectedDocumentProxy.DisplayDocument();

//  with Chained Proxy, unauthorised access
Console.WriteLine("Constructing protected document proxy.");
var otherProtectedDocumentProxy = new Proxy.ProtectedDocumentProxy("MyDocument.pdf", "AnotherUser");
Console.WriteLine("Protected document proxy constructed.");
otherProtectedDocumentProxy.DisplayDocument();

Console.ReadKey();
