﻿using Microsoft.EntityFrameworkCore;
using ToDo.Repositories.Interfaces;
using ToDo.Repositories.Model;

namespace ToDo.Repositories.Repositories
{
    public class TodoRepositorie : ITodoRepositorie
    {
        private readonly AppDbContext appDbContext;
        public TodoRepositorie(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<long> CreateAsync(TodoItem todoItem)
        {
            var newTodoItem = await appDbContext.TodoItems.AddAsync(todoItem);
            await appDbContext.SaveChangesAsync();
            return newTodoItem.Entity.Id;
        }

        public async Task<long?> DeleteTodoAsync(long userId, long id)
        {
            var todo = await appDbContext.TodoItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);

            if (todo == null) return null;

            appDbContext.TodoItems.Remove(todo);

            await appDbContext.SaveChangesAsync();

            return todo.Id;
        }

        public async Task<IEnumerable<TodoItem>> GetListTodoAsync(long userId, long? categoryId)
        {
            var query = appDbContext.TodoItems.Where(x => x.UserId == userId);

            if (categoryId.HasValue)
            {
                query = query.Where(query => query.CategoryId == categoryId.Value);
            }

            var list = await query.OrderBy(x => x.Id).ToListAsync();

            return list;
        }

        public Task<TodoItem?> GetTodoAsync(long userId, long id)
        {
            return appDbContext.TodoItems
                .FirstOrDefaultAsync(t => t.Id == id && t.UserId == userId);
        }

        public async Task<long?> TodoUpdateAsync(long todoId, TodoItem todoItem)
        {
            var todo = await appDbContext.TodoItems
                .FirstOrDefaultAsync(t => t.Id == todoId && t.UserId == todoItem.UserId);

            if (todo == null) return null;

            todo.Title = todoItem.Title;
            todo.Description = todoItem.Description;
            todo.CategoryId = todoItem.CategoryId;
            todo.IsCompleted = todoItem.IsCompleted;
            todo.UpdatedAt = DateTime.UtcNow;

            await appDbContext.SaveChangesAsync();

            return todo.Id;
        }

        public async Task<long?> TodoUpdateCompletionStatusAsync(long userId, long todoId, bool isCompleted)
        {
            var todo = await appDbContext.TodoItems
                .FirstOrDefaultAsync(t => t.Id == todoId && t.UserId == userId);

            if (todo == null) return null;

            todo.IsCompleted = isCompleted;
            todo.UpdatedAt = DateTime.UtcNow;

            await appDbContext.SaveChangesAsync();

            return todo.Id;
        }
    }
}
