using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Application.Notes.Queries.UserQueries.GetUser;
using TestTask.Application.Notes.Queries.UserQueries.GetListUsers;

namespace TestTask.WepApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ListUserVm>> GetListUser()
        {
            var query = new GetListUsersQuery
            {
                UserID = UserID
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{UserID}")]
        public async Task<ActionResult<UserVm>> GetUserID(Guid id)
        {
            var query = new GetUserQuery
            {
                UserID = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
    
}
