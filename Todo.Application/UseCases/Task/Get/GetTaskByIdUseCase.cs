using Todo.Communication.Enums;
using Todo.Communication.Responses;

namespace Todo.Application.UseCases.Task.Get;
public class GetTaskByIdUseCase
{
    public ResponseGetTaskByIdJson Execute(Guid id)
    {
        return new ResponseGetTaskByIdJson
        {
            Id = id,
            Name = "Task 1",
            Description = "Description of Task 1",
            Priority = Priority.High,
            Status = Status.Open,
            ExpiresAt = DateTime.Now
        };
    }
}
