using MediatR;
using System;

namespace TestTask.Application.Notes.Queries.GetListUsers
{
    public class GetListUsersQuery : IRequest<ListUserVm>
    {
        public Guid UserID { get; set; }
    }
}
