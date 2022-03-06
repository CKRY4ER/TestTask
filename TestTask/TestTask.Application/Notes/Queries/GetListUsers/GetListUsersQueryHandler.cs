using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using TestTask.Application.Interface;
using System.Threading;
using TestTask.Application.Common.Exception;
using TestTask.Application.Common.Mappings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;


namespace TestTask.Application.Notes.Queries.GetListUsers
{
    public class GetListUsersQueryHandler : IRequestHandler<GetListUsersQuery, ListUserVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetListUsersQueryHandler(ITestTaskDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ListUserVm> Handle(GetListUsersQuery request,
            CancellationToken cancellationToken)
        {
            var entites = await _dbContext.Users.Where(user => user.UserID == request.UserID)
                .ProjectTo<ListUserDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ListUserVm { Users = entites };
        }
    }
}
