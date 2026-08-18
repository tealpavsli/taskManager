using TaskManager.API.DTOs;
using TaskManager.API.Models;
using TaskManager.API.Repositories;

namespace TaskManager.API.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(Models.TaskStatus? status, string? search)
    {
        var tasks = await _repository.GetAllAsync(status, search);
        return tasks.Select(MapToResponseDto);
    }

    public async Task<TaskResponseDto?> GetTaskByIdAsync(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);
        return task == null ? null : MapToResponseDto(task);
    }

    public async Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Title = dto.Title.Trim(),
            Description = dto.Description?.Trim() ?? string.Empty,
            Status = Models.TaskStatus.New,
            CreatedAt = DateTime.UtcNow
        };

        var createdTask = await _repository.CreateAsync(task);
        return MapToResponseDto(createdTask);
    }

    public async Task<TaskResponseDto?> UpdateTaskAsync(Guid id, UpdateTaskDto dto)
    {
        var existingTask = await _repository.GetByIdAsync(id);
        if (existingTask == null) return null;

        existingTask.Title = dto.Title.Trim();
        existingTask.Description = dto.Description?.Trim() ?? string.Empty;
        existingTask.Status = dto.Status;

        await _repository.UpdateAsync(existingTask);
        return MapToResponseDto(existingTask);
    }

    public async Task<bool> DeleteTaskAsync(Guid id)
    {
        return await _repository.DeleteAsync(id);
    }

    private static TaskResponseDto MapToResponseDto(TaskItem task) => new()
    {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        Status = task.Status,
        CreatedAt = task.CreatedAt
    };
}