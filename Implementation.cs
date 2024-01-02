sing System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility;

public class Document
{
    public string Title { get; set; }
    public DateTimeOffset LastModified { get; set; }
    public bool ApprovedByLitigation { get; set; }
    public bool ApprovedByManagement { get; set; }
    
    public Document(
        string title,
        DateTimeOffset lastModified,
        bool approvedByLitigation,
        bool approvedByManagement)
    {
        Title = title;
        LastModified = lastModified;
        ApprovedByLitigation = approvedByLitigation;
        ApprovedByManagement = approvedByManagement;
    }
}


/// <summary>
/// Abstract Handler
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IHandler<T> where T : class
{
    IHandler<T> SetSuccessor(IHandler<T> successor);
    void Handle(T request);
}

/// <summary>
/// Concrete Handler
/// </summary>
public class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        // validation doesn't check out, so we throw an error
        if (document.Title == string.Empty)
        {
            throw new ValidationException(
                new ValidationResult(
                    "Title must be filled out",
                    new List<string>() { "Title" }), null, null);
        }
        
        // validation checks out, pass to next handler
        _successor?.Handle(document);
    }
    
    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}

/// <summary>
/// Concrete Handler
/// </summary>
public class DocumentApprovedByLitigationHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        // validation doesn't check out, so we throw an error
        if (!document.ApprovedByLitigation)
        {
            throw new ValidationException(
                new ValidationResult(
                    "Document must be approved by litigation",
                    new List<string>() { "Approved by litigation" }), null, null);
        }
        
        // validation checks out, pass to next handler
        _successor?.Handle(document);
    }
    
    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}

/// <summary>
/// Concrete Handler
/// </summary>
public class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document>? _successor;

    public void Handle(Document document)
    {
        // validation doesn't check out, so we throw an error
        if (!document.ApprovedByManagement)
        {
            throw new ValidationException(
                new ValidationResult(
                    "Document must be approved by management",
                    new List<string>() { "Approved by management" }), null, null);
        }
        
        // validation checks out, pass to next handler
        _successor?.Handle(document);
    }
    
    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return _successor;
    }
}
