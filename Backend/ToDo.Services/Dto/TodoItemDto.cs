using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Repositories.Entitys;
using ToDo.Repositories.Model;

namespace ToDo.Services.Dto
{
    public record TodoItemDto
    {
        public long Id { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public bool IsCompleted { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public long? CategoryId { get; init; }
    }
}
