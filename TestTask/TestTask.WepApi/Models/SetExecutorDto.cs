using System;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.UserCommands.SetExecutor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.WepApi.Models
{
    public class SetExecutorDto : IMapWith<SetExecutorCommand>
    {
        public Guid TaskID { get; set; }
        public Guid ExecutorID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<SetExecutorDto, SetExecutorCommand>()
                .ForMember(exDto => exDto.TaskID,
                    opt => opt.MapFrom(exCommand => exCommand.TaskID))
                .ForMember(exDto => exDto.ExecutorID,
                    opt => opt.MapFrom(exCommand => exCommand.ExecutorID));
        }
    }
}
