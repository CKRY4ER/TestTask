using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Commands.UserCommands.SetExecutor
{
    class SetExecutorCommand : IRequest
    {
        public Guid TaskID { get; set; }
        public Guid ExecutorID { get; set; }
    }
}
