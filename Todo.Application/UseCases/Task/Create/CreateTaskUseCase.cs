using Todo.Communication.Requests;
using Todo.Communication.Responses;

namespace Todo.Application.UseCases.Task.Create;
public class CreateTaskUseCase
{
    public ResponseTaskJson Execute(RequestTaskJson task)
    {
        return new ResponseTaskJson()
        {
            Id = Guid.NewGuid(),
            Name = task.Name,
            Description = task.Description,
            Priority = task.Priority,
            Status = task.Status,
            ExpiresAt = task.ExpiresAt
        };
    }
}
