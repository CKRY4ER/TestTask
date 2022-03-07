using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestTask.Domain;
using TestTask.Application.Interface;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Common.Exception;

namespace TestTask.Application.Notes.Commands.TaskCommands.CreateTask
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, Guid>
    {
        private readonly ITestTaskDbContext _dbContext;
        public CreateTaskCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateTaskCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserID == request.VendorID, cancellationToken);
            if (user == null || user.UserID != request.VendorID)
            {
                throw new NotFoundException(nameof(User), request.VendorID);
            }

            var task = new Domain.Task
            {
                TaskID = request.TaskID,
                Name = request.Name,
                Description = request.Description,
                VendorID = request.VendorID,
                Create_Date = DateTime.Now,
                Date_Redact = null,
                Status = "Not started",
                ExecutorID = null,
                Vendor = user
            };
            user.TaskVendor = task;
            await _dbContext.Tasks.AddAsync(task, cancellationToken);
           // await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return task.TaskID;
        }
    }
}
