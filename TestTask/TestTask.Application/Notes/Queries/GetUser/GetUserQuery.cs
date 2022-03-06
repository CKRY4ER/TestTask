using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace TestTask.Application.Notes.Queries.GetUser
{
    public class GetUserQuery : IRequest<UserVm>
    {
        public Guid UserID { get; set; }
    }
}
