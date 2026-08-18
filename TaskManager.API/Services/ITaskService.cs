using TaskManager.API.DTOs;

namespace TaskManager.API.Services;

public interface ITaskService
{
    Task<IEnumerable<TaskResponseDto>> GetAllTasksAsync(Models.TaskStatus? status, string? search);
    Task<TaskResponseDto?> GetTaskByIdAsync(Guid id);
    Task<TaskResponseDto> CreateTaskAsync(CreateTaskDto dto);
    Task<TaskResponseDto?> UpdateTaskAsync(Guid id, UpdateTaskDto dto);
    Task<bool> DeleteTaskAsync(Guid id);
}