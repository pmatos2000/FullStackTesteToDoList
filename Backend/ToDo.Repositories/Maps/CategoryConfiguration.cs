using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Repositories.Entitys;
using ToDo.Repositories.Model;
using ToDo.Shared.Extension;

namespace ToDo.Repositories.Maps
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        private const string TABLE_CATEGORY_NAME = "categories";
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(TABLE_CATEGORY_NAME);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(Category.Id).ConvertPascalToSnake())
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnName(nameof(Category.Name).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName(nameof(Category.UserId).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName(nameof(Category.CreatedAt).ConvertPascalToSnake())
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UpdatedAt)
                .HasColumnName(nameof(Category.UpdatedAt).ConvertPascalToSnake())
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAddOrUpdate();
        }
    }
}
