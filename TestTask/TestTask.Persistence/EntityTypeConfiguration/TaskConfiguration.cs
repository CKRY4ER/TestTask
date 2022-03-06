using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTask.Domain;

namespace TestTask.Persistence.EntityTypeConfiguration
{
    public class TaskConfiguration: IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(Task => Task.TaskID);
            builder.HasIndex(Task => Task.TaskID).IsUnique();
            builder.Property(Task => Task.TaskID).IsRequired();
            builder.Property(Task => Task.VendorID).IsRequired();
        }
    }
}
