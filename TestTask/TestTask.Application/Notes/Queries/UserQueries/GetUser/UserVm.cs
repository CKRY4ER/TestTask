using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TestTask.Domain;
using TestTask.Application.Common.Mappings;

namespace TestTask.Application.Notes.Queries.UserQueries.GetUser
{
    public class UserVm : IMapWith<User>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Date_Redact { get; set; }
        public string Status { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserVm>()
                .ForMember(uservm => uservm.Surname,
                    opt => opt.MapFrom(user => user.Surname))
                .ForMember(uservm => uservm.Name,
                    opt => opt.MapFrom(user => user.Name))
                .ForMember(uservm => uservm.Create_Date,
                    opt => opt.MapFrom(user => user.Create_Date))
                .ForMember(uservm => uservm.Date_Redact,
                    opt => opt.MapFrom(user => user.Date_Redact))
                .ForMember(uservm => uservm.Status,
                    opt => opt.MapFrom(user => user.Status));
        }
    }
}
