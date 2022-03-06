using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TestTask.Domain;
using TestTask.Application.Interface;

namespace TestTask.Application.Notes.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler:IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly ITestTaskDbContext _dbContext;
        public CreateUserCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateUserCommand request, 
            CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserID = request.UserID,
                Surname = request.Surname,
                Name = request.Name,
                Create_Date = DateTime.Now,
                Date_Redact = null,
                Status = "Online"
            };
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return user.UserID;
        }
    }
}
