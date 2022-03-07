using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interface;
using TestTask.Application.Common.Exception;
using TestTask.Domain;

namespace TestTask.Application.Notes.Commands.UserCommands.SetExecutor
{
    public class SetExecutoreCommandHandler : IRequestHandler<SetExecutorCommand>
    {
        private readonly ITestTaskDbContext _dbContext;
        public SetExecutoreCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(SetExecutorCommand request,
           CancellationToken cancellationToken)
        {
            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserID == request.ExecutorID, cancellationToken);
            if (userEntity == null || userEntity.UserID != request.ExecutorID)
            {
                throw new NotFoundException(nameof(User), request.ExecutorID);
            }
            var taskEntity = await _dbContext.Tasks.FirstOrDefaultAsync(task => task.TaskID == request.TaskID, cancellationToken);
            if (taskEntity == null || taskEntity.TaskID != request.TaskID)
            {
                throw new NotFoundException(nameof(Domain.Task), request.TaskID);
            }
            taskEntity.ExecutorID = userEntity.UserID;
            //taskEntity.Executor.UserID = userEntity.UserID;
            taskEntity.Executor = userEntity;
            userEntity.TaskExecuter = taskEntity;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
