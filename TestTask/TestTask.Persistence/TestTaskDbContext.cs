using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interface;
using TestTask.Domain;
using TestTask.Persistence.EntityTypeConfiguration;

namespace TestTask.Persistence
{
    public class TestTaskDbContext: DbContext, ITestTaskDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Task> Tasks { get; set; }
        public TestTaskDbContext(DbContextOptions<TestTaskDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TaskConfiguration());
            builder.ApplyConfiguration(new UserCofiguration());
            base.OnModelCreating(builder);
        }
    }
}
