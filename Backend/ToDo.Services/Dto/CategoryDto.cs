using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Services.Dto
{
    public record CategoryDto
    {
        public long Id { get; init; }
        public required string Name { get; init; }
    }
}
