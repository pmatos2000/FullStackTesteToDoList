﻿namespace ToDo.Services.Dto
{
    public record LoginUserDto
    {
        public bool Success { get; init; }
        public string ErrorMessage { get; init; } = String.Empty;
        public long UserId { get; init; }
        public string UserName { get; init; } = String.Empty;
    }
}
