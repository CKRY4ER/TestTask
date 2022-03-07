using System;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.UserCommands.UpdateUser;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.WepApi.Models
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public Guid UserID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(userCommand => userCommand.UserID,
                    opt => opt.MapFrom(userDto => userDto.UserID))
                .ForMember(userCommand => userCommand.Surname,
                    opt => opt.MapFrom(userDto => userDto.Surname))
                .ForMember(userCommand => userCommand.Name,
                    opt => opt.MapFrom(userDto => userDto.Name));
                
        }
    }
}
