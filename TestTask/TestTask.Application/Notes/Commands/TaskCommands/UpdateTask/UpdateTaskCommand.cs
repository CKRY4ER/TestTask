using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Commands.TaskCommands.UpdateTask
{
    public class UpdateTaskCommand : IRequest
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
