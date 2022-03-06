using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TestTask.Domain;
using TestTask.Application.Common.Mappings;

namespace TestTask.Application.Notes.Queries.TaskQueries.GetTask
{
    class TaskVm : IMapWith<Domain.Task>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Date_Redact { get; set; }
        public string Status { get; set; }
        public Guid VendorID { get; set; }
        public Guid? ExecutorID { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, TaskVm>()
                .ForMember(taskvm => taskvm.Name,
                    opt => opt.MapFrom(task => task.Name))
                .ForMember(taskvm => taskvm.Description,
                    opt => opt.MapFrom(task => task.Description))
                .ForMember(taskvm => taskvm.Create_Date,
                    opt => opt.MapFrom(task => task.Create_Date))
                .ForMember(taskvm => taskvm.Date_Redact,
                    opt => opt.MapFrom(task => task.Date_Redact))
                .ForMember(taskvm => taskvm.Status,
                    opt => opt.MapFrom(task => task.Status))
                .ForMember(taskvm => taskvm.VendorID,
                    opt => opt.MapFrom(task => task.VendorID))
                .ForMember(taskvm => taskvm.ExecutorID,
                    opt => opt.MapFrom(task => task.ExecutorID));
        }
    }
}
