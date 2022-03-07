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


namespace TestTask.WepApi.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : BaseController
    {
        private readonly IMapper _mapper;
        public TaskController(IMapper mapper) => _mapper = mapper;

        [HttpGet("VendorID")]
        public async Task<ActionResult<ListTaskByVendorVm>> GetListTaskByVendor(Guid VendorId)
        {
            var query = new GetListTaskByVendorQuery
            {
                VendorID = VendorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("ExecutorID")]
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

    }
}
