using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTO
{
    public record CompanyDto(Guid Id, string Name, string FullAddress);
}
