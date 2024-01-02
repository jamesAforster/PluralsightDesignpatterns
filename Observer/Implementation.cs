using System.ComponentModel.DataAnnotations;

namespace Observer;

public class TicketChange
{
    public int Amount { get; private set; }
    public int ArtistId { get; private set; }

    public TicketChange(
        int amount,
        int artistId)
    {
        Amount = amount;
        ArtistId = artistId;
    }
}

/// <summary>
/// Subject
/// </summary>
public abstract class TicketChangeNotifier
{
    private List<ITicketChangeListener> _observers = new();
    
    public void AddObserver(ITicketChangeListener observer)
    {
        _observers.Add(observer);
    }
    
    public void RemoveObserver(ITicketChangeListener observer)
    {
        _observers.Remove(observer);
    }
    
    public void Notify(TicketChange ticketChange)
    {
        foreach (var observer in _observers)
        {
            observer.ReceiveTicketChangeNotification(ticketChange);
        }
    }
}

/// <summary>
/// Observer
/// </summary>
public interface ITicketChangeListener
{
    void ReceiveTicketChangeNotification(TicketChange ticketChange);
}

/// <summary>
/// ConcreteSubject
/// </summary>
public class OrderService : TicketChangeNotifier
{
    public void CompleteTicketSale(int artistId, int amount)
    {
        // change local datastore. datastore omitted in demo.
        Console.WriteLine($"{nameof(OrderService)} is changing its state.");
        
        // notify observers
        Console.WriteLine($"{nameof(OrderService)} is notifying observers...");
        Notify(new TicketChange(amount, artistId));
    }
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class TicketResellerService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        // change local datastore. datastore omitted in demo.
        Console.WriteLine($"{nameof(TicketResellerService)} notified " +
                          $"Artist {ticketChange.ArtistId}, amount " +
                          $"{ticketChange.Amount}");
    }
}

/// <summary>
/// ConcreteObserver
/// </summary>
public class TicketStockService : ITicketChangeListener
{
    public void ReceiveTicketChangeNotification(TicketChange ticketChange)
    {
        // change local datastore. datastore omitted in demo.
        Console.WriteLine($"{nameof(TicketStockService)} notified " +
                          $"Artist {ticketChange.ArtistId}, amount " +
                          $"{ticketChange.Amount}");
    }
}