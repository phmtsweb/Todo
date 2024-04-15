using Todo.Communication.Enums;
using Todo.Communication.Responses;

namespace Todo.Application.UseCases.Task.GetAll;
public class GetAllTaskUseCase
{
    public ResponseGetAllTaskJson Execute()
    {
        var tasks = new ResponseGetAllTaskJson
        {
            Tasks =
            [
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 1",
                    Priority = Priority.High,
                    Status = Status.Open,
                    ExpiresAt = DateTime.Now
                },
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 2",
                    Priority = Priority.Medium,
                    Status = Status.Open,
                    ExpiresAt = DateTime.Now
                },
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Task 3",
                    Priority = Priority.Low,
                    Status = Status.Open,
                    ExpiresAt = DateTime.Now
                }
            ]
        };

        return tasks;
    }
}


