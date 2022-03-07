using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using TestTask.Application.Interface;
using TestTask.Application.Common.Exception;
using TestTask.Domain;

namespace TestTask.Application.Notes.Commands.TaskCommands.ChangeVendor
{
    public class ChangeVendorCommandHandler:IRequestHandler<ChangeVendorCommand>
    {
        private readonly ITestTaskDbContext _dbContext;
        public ChangeVendorCommandHandler(ITestTaskDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(ChangeVendorCommand request,
         CancellationToken cancellationToken)
        {
            var entity =
              await _dbContext.Tasks.FirstOrDefaultAsync(task => task.TaskID == request.TaskID, cancellationToken);
            if (entity == null || entity.TaskID != request.TaskID)
            {
                throw new NotFoundException(nameof(Domain.Task), request.TaskID);
            }
            entity.VendorID = request.VendorID;
            entity.Date_Redact = DateTime.Now;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
