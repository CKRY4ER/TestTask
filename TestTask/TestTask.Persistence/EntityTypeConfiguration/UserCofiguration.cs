using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Persistence.EntityTypeConfiguration
{
    public class UserCofiguration : IEntityTypeConfiguration<User>
    {
       public void Configure(EntityTypeBuilder<User> builder)
       {
            builder.HasKey(User => User.UserID);
            builder.HasIndex(User => User.UserID).IsUnique();
            builder.Property(User => User.UserID).IsRequired();

       }
    }
}
