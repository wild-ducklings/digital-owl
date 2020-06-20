using AutoMapper;
using DigitalOwl.Api.Model;
using DigitalOwl.Api.Model.User;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Service.Dto;

namespace DigitalOwl.Api.Infrastructure
{
    public class ModelToDtoMapperProfile : Profile
    {
        public ModelToDtoMapperProfile()
        {
            // TODO make this map to convert first to DTO 
            CreateMap<CreateUser, User>().ReverseMap();
            // TODO make this map to convert first to DTO 
            CreateMap<LoginUser, User>().ReverseMap();

            CreateMap<CreateGroup, DtoGroup>().ReverseMap();
            CreateMap<CreateGroupMessage, DtoGroupMessage>().ReverseMap();


            CreateMap<CreatePoll, DtoPoll>().ReverseMap();
            CreateMap<CreatePollQuestion, DtoPollQuestion>().ReverseMap();
        }
    }
}