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

namespace TestTask.Application.Notes.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserQueryHandler(ITestTaskDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<UserVm> Handle(GetUserQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users
                .FirstOrDefaultAsync(user => user.UserID == request.UserID, cancellationToken);
            if (entity == null || entity.UserID != request.UserID)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }
            return _mapper.Map<UserVm>(entity);
        }
    }
}
