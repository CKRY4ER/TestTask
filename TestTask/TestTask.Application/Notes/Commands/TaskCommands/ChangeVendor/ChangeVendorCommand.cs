using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Commands.TaskCommands.ChangeVendor
{
   public class ChangeVendorCommand : IRequest
    {
        public Guid TaskID { get; set; }
        public Guid VendorID { get; set; }
    }
}
