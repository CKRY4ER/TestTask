using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Commands.TaskCommands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommand : IRequest
    {
        enum Stat
        {
            NotStartet,
            InProcess,
            Completed,
            Cancelled,
            Rejected
        }
        public Guid TaskID { get; set; }
        public string Status { get; set; }
    }
}
