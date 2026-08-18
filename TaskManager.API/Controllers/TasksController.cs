using Microsoft.AspNetCore.Mvc;
using TaskManager.API.DTOs;
using TaskManager.API.Services;

namespace TaskManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskResponseDto>>> GetTasks(
        [FromQuery] Models.TaskStatus? status, 
        [FromQuery] string? search)
    {
        var tasks = await _service.GetAllTasksAsync(status, search);
        return Ok(tasks);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<TaskResponseDto>> GetTask(Guid id)
    {
        var task = await _service.GetTaskByIdAsync(id);
        if (task == null) return NotFound();
        return Ok(task);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponseDto>> CreateTask([FromBody] CreateTaskDto dto)
    {
        var createdTask = await _service.CreateTaskAsync(dto);
        return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<TaskResponseDto>> UpdateTask(Guid id, [FromBody] UpdateTaskDto dto)
    {
        var updatedTask = await _service.UpdateTaskAsync(id, dto);
        if (updatedTask == null) return NotFound();
        return Ok(updatedTask);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        var deleted = await _service.DeleteTaskAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}