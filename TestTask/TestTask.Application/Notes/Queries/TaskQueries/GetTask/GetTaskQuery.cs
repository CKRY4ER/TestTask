using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Queries.TaskQueries.GetTask
{
    public class GetTaskQuery : IRequest<TaskVm>
    {
        public Guid TaskID { get; set; }
    }
}
