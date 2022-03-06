using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Commands.UserCommands.UpdateUser
{
    public class UpdateUserCommand: IRequest
    {
        public Guid UserID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
    }
}
