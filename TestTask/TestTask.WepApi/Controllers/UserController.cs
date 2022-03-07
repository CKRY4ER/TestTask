using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Application.Notes.Queries.UserQueries.GetUser;
using TestTask.Application.Notes.Queries.UserQueries.GetListUsers;
using TestTask.Application.Notes.Commands.UserCommands.UpdateUser;
using TestTask.WepApi.Models;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.UserCommands.SetExecutor;

namespace TestTask.WepApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;
        [HttpGet("GetListUsers")]
        public async Task<ActionResult<ListUserVm>> GetListUser()
        {
            var query = new GetListUsersQuery
            {
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{UserID}")]
        public async Task<ActionResult<UserVm>> GetUserID(Guid UserID)
        {
            var query = new GetUserQuery
            {
                UserID = UserID
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> Update([FromBody] UpdateUserDto updateUserDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(updateUserDto);
            command.UserID = updateUserDto.UserID;

            await Mediator.Send(command);
            return NoContent();

        }

        [HttpPut("SetExecutor")]
        public async Task<IActionResult> SetExecutor([FromBody] SetExecutorDto setExecutorDto)
        {
            var command = _mapper.Map<SetExecutorCommand>(setExecutorDto);
            command.ExecutorID = setExecutorDto.ExecutorID;
            command.TaskID = setExecutorDto.TaskID;
            await Mediator.Send(command);
            return NoContent();
        }
    }
    
}
