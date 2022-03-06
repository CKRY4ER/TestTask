using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Commands.TaskCommands.CreateTask
{
    public class CreateTaskCommand : IRequest<Guid>
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid VendorID { get; set; }
    }
}
