using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.UpdateTaskStatus
{
    public class UpdateTaskStatusCommand : IRequest
    {
        public Guid TaskID { get; set; }
        public string Status { get; set; }
    }
}
