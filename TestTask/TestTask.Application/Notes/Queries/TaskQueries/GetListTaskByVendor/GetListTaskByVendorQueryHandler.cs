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

namespace TestTask.Application.Notes.Queries.TaskQueries.GetListTaskByVendor
{
    class GetListTaskByVendorQueryHandler : IRequestHandler<GetListTaskByVendorQuery, ListTaskByVendorVm>
    {
        private readonly ITestTaskDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetListTaskByVendorQueryHandler(ITestTaskDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);
        public async Task<ListTaskByVendorVm> Handle(GetListTaskByVendorQuery request,
            CancellationToken cancellationToken)
        {
            var entites = await _dbContext.Tasks
                .Where(task => task.Vendor.UserID == request.VendorID)
                .ProjectTo<ListTaskByVendorDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return new ListTaskByVendorVm { Tasks = entites };
        }
    }
}
