using System;
using AutoMapper;
using TestTask.Application.Common.Mappings;
using TestTask.Application.Notes.Commands.TaskCommands.ChangeVendor;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask.WepApi.Models
{
    public class ChangeVendorDto : IMapWith<ChangeVendorCommand>
    {
        public Guid TaskID { get; set; }
        public string VendorID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChangeVendorDto, ChangeVendorCommand>()
                .ForMember(chve => chve.TaskID,
                    opt => opt.MapFrom(chveCommand => chveCommand.TaskID))
                .ForMember(chve => chve.VendorID,
                    opt => opt.MapFrom(chveCommand => chveCommand.VendorID));
        }
    }
}
