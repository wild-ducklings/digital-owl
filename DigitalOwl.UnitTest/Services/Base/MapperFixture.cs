using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AutoMapper;
using DigitalOwl.Repository;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories;
using DigitalOwl.Repository.Repositories.Base;
using DigitalOwl.Service.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DigitalOwl.UnitTest.Services.Base
{
    public sealed class MapperFixture : IDisposable
    {
        private readonly ICollection<IUnitOfWork> _unitsOfWork = new HashSet<IUnitOfWork>();

        public IUnitOfWork CreateUnitOfWork([CallerMemberName] string databaseName = "")
        {
            DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            IDbContext context = new ApplicationDbContext(options);

            IUnitOfWork unitOfWork = new UnitOfWork(context);

            _unitsOfWork.Add(unitOfWork);

            return unitOfWork;
        }
        public IMapper CreateMapper()
        {
            DtoToEntityMapperProfile profile = new DtoToEntityMapperProfile();
            MapperConfiguration cnf = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            IMapper mapper = new Mapper(cnf);
            return mapper;
        }
        public void Dispose()
        {
            foreach (IUnitOfWork unitOfWork in _unitsOfWork)
            {
                unitOfWork.Dispose();
            }
        }

    }
}