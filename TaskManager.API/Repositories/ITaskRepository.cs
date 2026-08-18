using TaskManager.API.Models;

namespace TaskManager.API.Repositories;

public interface ITaskRepository
{
    Task<IEnumerable<TaskItem>> GetAllAsync(Models.TaskStatus? status, string? search);
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<TaskItem> CreateAsync(TaskItem task);
    Task<bool> UpdateAsync(TaskItem task);
    Task<bool> DeleteAsync(Guid id);
}