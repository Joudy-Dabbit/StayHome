using Domain.Entities.Security;

namespace Domain.Entities.Main;

public class ContactUs : AggregateRoot
{
    private ContactUs() { }
    
    public ContactUs(string title, string content)
    {
        Title = title;
        Content = content;
    }

    public string Title { get; private set; }
    public string Content { get; private set; }
    
    public string? Reply { get; private set; }

    public Guid? EmployeeId { get; private set; }
    public Employee? Employee { get; private set; }   
    
    public Guid CustomerId { get; private set; }
    public Customer  Customer { get; private set; }

    public void SetReply(string reply, Guid employeeId)
    {
        EmployeeId = employeeId;
        Reply = reply;
    }
}