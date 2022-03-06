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

namespace TestTask.Application.Notes.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand>
    {
        private readonly ITestTaskDbContext _dbContext;
        public UpdateUserCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateUserCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Users.FirstOrDefaultAsync(user => user.UserID == request.UserID, cancellationToken);
            if (entity==null||entity.UserID != request.UserID)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }
            entity.Name = request.Name;
            entity.Surname = request.Surname;
            entity.Date_Redact = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
