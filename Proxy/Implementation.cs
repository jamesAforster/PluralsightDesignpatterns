using System.Diagnostics.Tracing;

namespace Proxy
{
    // create interface from Document
    public interface IDocument
    {
        void DisplayDocument();
    }

    /// <summary>
    /// RealSubject
    /// </summary>
    public class Document : IDocument
    {
        public string? Title { get; private set; }
        public string? Content { get; private set; }
        public int AuthorId { get; set; }
        public DateTimeOffset LastAccessed { get; private set; }
        private string _fileName;

        public Document(string fileName)
        {
            _fileName = fileName;
            LoadDocument(fileName); // Expensive operation happens when we create the object
        }
        
        private void LoadDocument(string fileName)
        {
            Console.WriteLine("Executing expensive action: loading a file from disk");
            // fake loading...
            Thread.Sleep(1000);
        
            // create some content
            Title = "An expensive document";
            Content = "This is my document";
            LastAccessed = DateTimeOffset.UtcNow;
            AuthorId = 1;
        }

        public void DisplayDocument()
        {
            Console.WriteLine($"Title: {Title}, Content: {Content}");
        }
    }

    /// <summary>
    /// Proxy - purpose is to make sure the document is not loaded until it is needed
    /// </summary>
    public class DocumentProxy : IDocument
    {
        // what we could do is do a null check for the document in the DisplayDocument method
        // this would then mean that we would only load the document if we needed to
        // using Lazy<T> has the same effect, we only load the document if we need to
        private Lazy<Document> _document;
        
        private string _fileName;
        
        public DocumentProxy(string fileName)
        {
            _fileName = fileName;
            _document = new Lazy<Document>(() => new Document(_fileName));
        }
        
        public void DisplayDocument()
        {
            _document.Value.DisplayDocument();
        }
    }
    
    
    /// <summary>
    /// Proxy - implements DocumentProxy, as well as adds additional functionality
    /// <summary>
    class ProtectedDocumentProxy : IDocument
    {
        private string _fileName;
        private string _userRole;
        private DocumentProxy _documentProxy;
        
        public ProtectedDocumentProxy(
            string fileName,
            string userRole)
        {
            _fileName = fileName;
            _userRole = userRole;
            _documentProxy = new DocumentProxy(_fileName);
        }
        
        public void DisplayDocument()
        {
            Console.WriteLine($"Entering DisplayDocument " +
                              $"in {nameof(ProtectedDocumentProxy)}.");

            if (_userRole != "Viewer")
            {
                throw new UnauthorizedAccessException();
            }
            
            _documentProxy.DisplayDocument();

            Console.WriteLine($"Exiting DisplayDocument " +
                              $"in {nameof(ProtectedDocumentProxy)}.");
        }
    }
}