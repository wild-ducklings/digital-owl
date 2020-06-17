using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Service.Dto;

namespace DigitalOwl.Service.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class DtoToEntityMapperProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public DtoToEntityMapperProfile()
        {
            CreateMap<DtoGroup, Group>().ReverseMap();
            CreateMap<DtoPoll, Poll>().ReverseMap();
        }
    }
}