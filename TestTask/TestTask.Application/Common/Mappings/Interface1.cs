using AutoMapper;

namespace TestTask.Application.Common.Mappings
{
    interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
