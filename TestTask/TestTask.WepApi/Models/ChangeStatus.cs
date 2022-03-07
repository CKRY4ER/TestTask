using System;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.TaskCommands.UpdateTaskStatus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.WepApi.Models
{
    public class ChangeStatus : IMapWith<UpdateTaskStatusCommand>
    {
        public Guid TaskID { get; set; }
        public string Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChangeStatus, UpdateTaskStatusCommand>()
                .ForMember(chstat => chstat.TaskID,
                    opt => opt.MapFrom(chstatCommand => chstatCommand.TaskID))
                .ForMember(chstat => chstat.Status,
                    opt => opt.MapFrom(chstatCommand => chstatCommand.Status));
        }
    }
}
