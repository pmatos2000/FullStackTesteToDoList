using Microsoft.EntityFrameworkCore;
using ToDo.Repositories.Model.Entity;

namespace ToDo.Repositories;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; } = default!;
    public DbSet<TodoItem> TodoItems { get; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

}
