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
using AutoMapper;

namespace TestTask.Application.Notes.Queries.TaskQueries.GetTask
{
    public class GetTaskQueryHandler : IRequestHandler<GetTaskQuery, TaskVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetTaskQueryHandler(ITestTaskDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<TaskVm> Handle(GetTaskQuery request,
           CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Tasks
               .FirstOrDefaultAsync(task => task.TaskID == request.TaskID, cancellationToken);
            if (entity == null || entity.TaskID != request.TaskID)
            {
                throw new NotFoundException(nameof(Domain.Task), request.TaskID);
            }
            return _mapper.Map<TaskVm>(entity);
        }
    }
}
