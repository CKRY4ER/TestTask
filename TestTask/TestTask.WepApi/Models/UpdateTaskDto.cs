using System;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.TaskCommands.UpdateTask;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.WepApi.Models
{
    public class UpdateTaskDto : IMapWith<UpdateTaskCommand>
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateTaskDto, UpdateTaskCommand>()
                .ForMember(uptDto => uptDto.TaskID,
                    opt => opt.MapFrom(uptCommand => uptCommand.TaskID))
                .ForMember(uptDto => uptDto.Name,
                    opt => opt.MapFrom(uptCommand => uptCommand.Name))
                .ForMember(uptDto => uptDto.Description,
                    opt => opt.MapFrom(uptCommand => uptCommand.Description));
        } 
    }
}
