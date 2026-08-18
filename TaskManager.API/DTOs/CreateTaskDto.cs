using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTOs;

public class CreateTaskDto
{
    [Required(ErrorMessage = "Название задачи обязательно.")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Длина названия должна быть от 3 до 100 символов.")]
    public string Title { get; set; } = string.Empty;

    [MaxLength(1000, ErrorMessage = "Описание не должно превышать 1000 символов.")]
    public string Description { get; set; } = string.Empty;
}