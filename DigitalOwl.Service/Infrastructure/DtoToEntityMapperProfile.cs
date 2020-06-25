using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Service.Dto;

namespace DigitalOwl.Service.Infrastructure
{
    /// <summary>
    /// Automapper profile that maps Dto to Entity
    /// </summary>
    public class DtoToEntityMapperProfile : Profile
    {
        /// <summary>
        /// Automapper profile that maps Dto to Entity.
        /// </summary>
        public DtoToEntityMapperProfile()
        {
            CreateMap<DtoGroup, Group>().ReverseMap();
            CreateMap<DtoGroupMember, GroupMember>().ReverseMap();
            CreateMap<DtoGroupMessage, GroupMessage>().ReverseMap();
            CreateMap<DtoPoll, Poll>().ReverseMap();
            CreateMap<DtoPollQuestion, PollQuestion>().ReverseMap();
            CreateMap<DtoPollAnswer, PollAnswer>().ReverseMap();
        }
    }
}