using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDo.Repositories.Model;
using ToDo.Shared.Extension;

namespace ToDo.Repositories.Map
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        private const string TABLE_USER_NAME = "users";
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(TABLE_USER_NAME);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName(nameof(User.Id).ConvertPascalToSnake())
                .ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .HasColumnName(nameof(User.UserName).ConvertPascalToSnake())
                .IsRequired();

            builder
                .Property(x => x.PasswordHash)
                .HasColumnName(nameof(User.PasswordHash).ConvertPascalToSnake())
                .IsRequired();

            builder.Property(x => x.CreatedAt)
                .HasColumnName(nameof(User.CreatedAt).ConvertPascalToSnake())
                .HasDefaultValueSql("NOW()")
                .ValueGeneratedOnAdd();
        }
    }
}
