using Microsoft.AspNetCore.Mvc;
using Todo.Application.UseCases.Task.Create;
using Todo.Application.UseCases.Task.Get;
using Todo.Application.UseCases.Task.GetAll;
using Todo.Application.UseCases.Task.Update;
using Todo.Communication.Requests;
using Todo.Communication.Responses;

namespace Todo.API.Controllers;
[Route("api/[controller]s")]
[ApiController]
public class TaskController : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseGetAllTaskJson))]
    public IActionResult GetAll()
    { 
        var useCase = new GetAllTaskUseCase();
        var response = useCase.Execute();
        return Ok(response);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseShortTaskJson))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorsJson))]
    public IActionResult GetById([FromRoute]Guid id)
    {
        if (!Guid.TryParse(id.ToString(), out Guid _))
        {
            var errors = new ResponseErrorsJson()
            {
                Errors =
                [
                    $"Task {id} not found"
                ]
            };
            return NotFound(errors);
        }
        var useCase = new GetTaskByIdUseCase();
        var response = useCase.Execute(id);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorsJson))]
    public IActionResult Delete(Guid id)
    {
        if (!Guid.TryParse(id.ToString(), out Guid _))
        {
            var errors = new ResponseErrorsJson()
            {
                Errors =
                [
                    $"Task {id} not found"
                ]
            };
            return NotFound(errors);
        }
        var useCase = new GetTaskByIdUseCase();
        useCase.Execute(id);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseTaskJson))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorsJson))]
    public IActionResult Create([FromBody] RequestTaskJson request)
    {
        var useCase = new CreateTaskUseCase();
        var response = useCase.Execute(request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ResponseTaskJson))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseErrorsJson))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ResponseErrorsJson))]
    public IActionResult Create([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        if (!Guid.TryParse(id.ToString(), out Guid _))
        {
            var errors = new ResponseErrorsJson()
            {
                Errors =
                [
                    $"Task {id} not found"
                ]
            };
            return NotFound(errors);
        }
        var useCase = new UpdateTaskUseCase();
        var response = useCase.Execute(id, request);
        return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
    }
}
