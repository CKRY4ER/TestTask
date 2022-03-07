using System;
using System.Collections.Generic;
using AutoMapper;
using TestTask.WepApi.Models;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestTask.Application.Notes.Queries.TaskQueries.GetListTaskByVendor;
using TestTask.Application.Notes.Queries.TaskQueries.GetListTaskByExecutor;
using TestTask.Application.Notes.Queries.TaskQueries.GetTask;
using TestTask.Application.Notes.Commands.TaskCommands.CreateTask;
using TestTask.Application.Notes.Commands.TaskCommands.UpdateTask;

namespace TestTask.WepApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;
        public TaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet("ListByVendor")]
        public async Task<ActionResult<ListTaskByVendorVm>> GetListTaskByVendor(Guid VendorId)
        {
            var query = new GetListTaskByVendorQuery
            {
                VendorID = VendorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("ListByExecutor")]
        public async Task<ActionResult<GetListTaskByExecutorVm>> GetListTaskByExecutor(Guid ExecutorID)
        {
            var query = new GetListTaskByExecutorQuery
            {
                ExecutorID = ExecutorID
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{TaskID}")]
        public async Task<ActionResult<TaskVm>> GetTask(Guid TaskID)
        {
            var query = new GetTaskQuery
            {
                TaskID = TaskID
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPost("CreateTask")]
        public async Task<ActionResult<Guid>> CreateTask([FromBody] CreateTaskDto createTaskDto)
        {
            var command = _mapper.Map<CreateTaskCommand>(createTaskDto);
            var taskid = await Mediator.Send(command);
            return Ok(taskid);
        }
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDto updateTaskDto)
        {
            var command = _mapper.Map<UpdateTaskCommand>(updateTaskDto);
           // command.TaskID = updateTaskDto.TaskID;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatus changeStatus)
        {
            var command = _mapper.Map<ChangeStatus>(changeStatus);
           // command.TaskID = changeStatus.TaskID;
            command.Status = changeStatus.Status;
            await Mediator.Send(command);
            return NoContent();
        }
        [HttpPut("ChangeVendor")]
        public async Task<IActionResult> ChangeVendor([FromBody] ChangeVendorDto changeVendor)
        {
            var command = _mapper.Map<ChangeVendorDto>(changeVendor);
           // command.TaskID = changeVendor.TaskID;
            command.VendorID = changeVendor.VendorID;
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
