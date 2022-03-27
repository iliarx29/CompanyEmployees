using System.ComponentModel.DataAnnotations;

namespace Service.DTO
{
    public record UpdateEmployeeDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        public string? Name { get; init; }

        [Range(18, 70, ErrorMessage = "Age is required and it can't be lower than 18 or higher than 70")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Position is a required field.")]
        public string? Position { get; init; }
    }
}
