using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Queries.TaskQueries.GetListTaskByExecutor
{
    public class GetListTaskByExecutorQuery : IRequest<GetListTaskByExecutorVm>
    {
        public Guid ExecutorID { get; set; }
    }
}
