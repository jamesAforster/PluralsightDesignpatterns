namespace Mediator;

// public abstract class ChatRoom
// {
//     public abstract void Register(TeamMember teamMember);
//     public abstract void Send(string from, string message);
// }

/// <summary>
/// Mediator
/// </summary>
public interface IChatRoom
{
    void Register(TeamMember teamMember);
    void Send(string from, string message);

    void Send(string from, string to, string message);

    // What if we want to send to a specific type of team member? I.e. Lawyer or AccountManager?
    void SendTo<T>(string from, string message) where T : TeamMember;
}

/// <summary>
/// Colleague
/// </summary>
public abstract class TeamMember
{
    private IChatRoom? _chatRoom;
    
    public string Name { get; set; }
    
    public TeamMember(string name)
    {
        Name = name;
    }

    internal void SetChatroom(IChatRoom chatRoom)
    {
        _chatRoom = chatRoom;
    }

    public void Send(string message)
    {
        _chatRoom?.Send(Name, message);
    }
    
    public void Send(string message, string teamMember)
    {
        _chatRoom?.Send(Name, message, teamMember);
    }
    
    public void SendTo<T>(string message) where T : TeamMember
    {
        _chatRoom?.SendTo<T>(Name, message);
    }
    
    public virtual void Receive(string from, string message)
    {
        Console.WriteLine($"Message {from} to {Name}: '{message}'");
    }
}

/// <summary>
/// Concrete Colleague
/// </summary>
public class Lawyer : TeamMember
{ 
    public Lawyer(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(Lawyer)} {Name} received :");
        base.Receive(from, message);
    }
}

/// <summary>
/// Concrete Colleague
/// </summmary>
public class AccountManager : TeamMember
{
    public AccountManager(string name) : base(name)
    {
    }

    public override void Receive(string from, string message)
    {
        Console.WriteLine($"{nameof(AccountManager)} {Name} received :");
        base.Receive(from, message);
    }
}

/// <summary>
/// Concrete Mediator
/// </summary>
public class TeamChatRoom : IChatRoom
{
    private readonly Dictionary<string, TeamMember> _teamMembers = new();

    public void Register(TeamMember teamMember)
    {
        teamMember.SetChatroom(this);
        if (!_teamMembers.ContainsValue(teamMember))
        {
            _teamMembers[teamMember.Name] = teamMember; // assumes the Name will be unique
        }
    }

    public void Send(string from, string message)
    {
        foreach (var member in _teamMembers)
        {
            if (member.Key != from) // assumes everyone except for the sender needs to receive it
            {
                member.Value.Receive(from, message);
            }
        }
    }
    
    public void SendTo<T>(string from, string message) where T : TeamMember
    {
        foreach (var teamMember in _teamMembers.Values.OfType<T>())
        {
            teamMember.Receive(from, message);
        }
    }
    
    public void Send(string from, string to, string message)
    {
        if (_teamMembers.TryGetValue(to, out var teamMember))
        {
            teamMember.Receive(from, message);
        }
    }
}


