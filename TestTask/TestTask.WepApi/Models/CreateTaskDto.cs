using System;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.TaskCommands.CreateTask;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.WepApi.Models
{
    public class CreateTaskDto : IMapWith<CreateTaskCommand>
    {
        public Guid TaskID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid VendorID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateTaskDto, CreateTaskCommand>()
                .ForMember(crtDto => crtDto.Name,
                    opt => opt.MapFrom(crtCommand => crtCommand.Name))
                .ForMember(crtDto => crtDto.Description,
                    opt => opt.MapFrom(crtCommand => crtCommand.Description))
                .ForMember(crtDto => crtDto.VendorID,
                    opt => opt.MapFrom(crtCommand => crtCommand.VendorID))
                .ForMember(crtDto=>crtDto.TaskID,
                    opt=>opt.MapFrom(crtCommand=>crtCommand.TaskID));
        }
    }
}
