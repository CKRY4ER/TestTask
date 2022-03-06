using MediatR;
using System;

namespace TestTask.Application.Notes.Queries.UserQueries.GetListUsers
{
    public class GetListUsersQuery : IRequest<ListUserVm>
    {
        public Guid UserID { get; set; }
    }
}
