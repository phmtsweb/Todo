using Todo.Communication.Requests;
using Todo.Communication.Responses;

namespace Todo.Application.UseCases.Task.Update;
public class UpdateTaskUseCase
{
    public ResponseTaskJson Execute(Guid id, RequestTaskJson task)
    {
        return new ResponseTaskJson()
        {
            Id = id,
            Name = task.Name,
            Description = task.Description,
            Priority = task.Priority,
            Status = task.Status,
            ExpiresAt = task.ExpiresAt
        };
    }
}
