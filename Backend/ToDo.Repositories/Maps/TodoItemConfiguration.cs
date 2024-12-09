using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Repositories.Model;
using ToDo.Shared.Extension;

namespace ToDo.Repositories.Map
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        private const string TABLE_TODO_ITEM_NAME = "tasks";
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable(TABLE_TODO_ITEM_NAME);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(TodoItem.Id).ConvertPascalToSnake())
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Title)
                .HasColumnName(nameof(TodoItem.Title).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName(nameof(TodoItem.Description).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.IsCompleted)
                .HasColumnName(nameof(TodoItem.IsCompleted).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName(nameof(TodoItem.CreatedAt).ConvertPascalToSnake())
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName(nameof(TodoItem.UpdatedAt).ConvertPascalToSnake())
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAddOrUpdate();

            builder.Property(x => x.UserId)
                .HasColumnName(nameof(TodoItem.UserId).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .HasColumnName(nameof(TodoItem.CategoryId).ConvertPascalToSnake());
        }
    }
}
