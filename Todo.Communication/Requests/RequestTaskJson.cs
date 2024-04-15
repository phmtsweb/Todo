using Todo.Communication.Enums;

namespace Todo.Communication.Requests;
public class RequestTaskJson
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public Priority Priority { get; set; } = Priority.Medium;
    public Status Status { get; set; } = Status.Open;
    public DateTime ExpiresAt { get; set; }
}
