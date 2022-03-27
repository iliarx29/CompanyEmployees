using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Company
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(50, ErrorMessage = "Maximum length of company name is 50 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company address is a required field.")]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Company country is a required field.")]
        public string Country { get; set; } = string.Empty;
        public ICollection<Employee>? Employees { get; set; }
    }
}
