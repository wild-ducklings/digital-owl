using AutoMapper;
using DigitalOwl.Api.Model;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Entity.Identity;
using DigitalOwl.Service.Dto;

namespace DigitalOwl.Api.Infrastructure
{
    public class ModelToDtoMapperProfile : Profile
    {
        public ModelToDtoMapperProfile()
        {
            CreateMap<CreatePoll, DtoPoll>().ReverseMap();
        }
    }
}