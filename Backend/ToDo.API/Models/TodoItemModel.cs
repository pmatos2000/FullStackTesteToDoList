﻿using ToDo.Repositories.Entitys;
using ToDo.Repositories.Model;

namespace ToDo.API.Models
{
    public record TodoItemModel
    {
        public long Id { get; init; }
        public required string Title { get; init; }
        public required string Description { get; init; }
        public bool IsCompleted { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        public long UserId { get; init; }
        public User? User { get; init; }
        public long? CategoryId { get; init; }
        public Category? Category { get; init; }
    }
}
