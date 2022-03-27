using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public record CreateEmployeeDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        public string? Name { get; init; }

        [Range(18, 70, ErrorMessage = "Age is required and it can't be lower than 18 or higher than 70")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Position is a required field.")]

        public string? Position { get; init; }
    }
}
