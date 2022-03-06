using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using TestTask.Domain;
using TestTask.Application.Common.Mappings;

namespace TestTask.Application.Notes.Queries.TaskQueries.GetListTaskByExecutor
{
    public class GetListTaskByExecutorDto : IMapWith<Domain.Task>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime? Date_Redact { get; set; }
        public string Status { get; set; }
        public Guid VendorID { get; set; }
        public string VendorSurname { get; set; }
        public string VendorName { get; set; }
        public string VendorStatus { get; set; }
        public Guid? ExecutorID { get; set; }
        public string ExecutorStatus { get; set; }
        public string ExecutorName { get; set; }
        public string ExecutorSurname { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Task, GetListTaskByExecutorDto>()
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
                    opt => opt.MapFrom(task => task.ExecutorID))
                .ForMember(taskvm => taskvm.VendorName,
                    opt => opt.MapFrom(task => task.Vendor.Name))
                .ForMember(taskvm => taskvm.VendorStatus,
                    opt => opt.MapFrom(task => task.Vendor.Status))
                .ForMember(taskvm => taskvm.VendorSurname,
                    opt => opt.MapFrom(task => task.Vendor.Surname))
                .ForMember(taskvm => taskvm.ExecutorName,
                    opt => opt.MapFrom(task => task.Executor.Name))
                .ForMember(taskvm => taskvm.ExecutorSurname,
                    opt => opt.MapFrom(task => task.Executor.Surname))
                .ForMember(taskvm => taskvm.ExecutorStatus,
                    opt => opt.MapFrom(task => task.Executor.Status));
        }
    }
}
