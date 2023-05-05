using Domain.Entities.Security;

namespace Domain.Entities.Main;

public class ContactUs : AggregateRoot
{
    private ContactUs() { }
    
    public ContactUs(string title, string content,
        string? email, string? phoneNumber,
        string? name)
    {
        Title = title;
        Content = content;
        Email = email;
        Name = name;
    }

    public string Title { get; private set; }
    public string Content { get; private set; }

    public string Email { get; private set; }
    public string Name { get; private set; }

    public string? Reply { get; private set; }

    public Guid? EmployeeId { get; private set; }
    public Employee? Employee { get; private set; }

    public void SetReply(string reply, Guid employeeId)
    {
        EmployeeId = employeeId;
        Reply = reply;
    }
}