using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTask.Domain;

namespace TestTask.Application.Interface
{
    public interface ITestTaskDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Domain.Task> Tasks { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
