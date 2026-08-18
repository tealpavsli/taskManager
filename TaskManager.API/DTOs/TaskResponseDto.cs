using TaskManager.API.Models;

namespace TaskManager.API.DTOs;

public class TaskResponseDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskManager.API.Models.TaskStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
}