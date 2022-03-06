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
            builder.HasOne(Task => Task.Vendor).WithOne(User => User.TaskVendor).HasForeignKey<Task>(Task=>Task.VendorID);
            builder.HasOne(Task => Task.Executor).WithOne(User => User.TaskExecuter).HasForeignKey<Task>(Task=>Task.ExecutorID);
            builder.Property(Task => Task.Description).IsRequired();
            builder.Property(Task => Task.Name).IsRequired();
            builder.Property(Task => Task.Status).IsRequired();
            builder.Property(Task => Task.Create_Date).IsRequired();
        }
    }
}
