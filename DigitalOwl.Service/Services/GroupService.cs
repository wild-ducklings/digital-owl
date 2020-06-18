using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services.Base;

namespace DigitalOwl.Service.Services
{
    public class GroupService : BaseService, IGroupService
    {
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<DtoResponseResult<DtoGroup>> CreateAsync(DtoGroup dto, int userId)
        {
            var entity = _mapper.Map<Group>(dto);
            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupRepository.Create(entity);

            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroup>.CreateResponse(_mapper.Map<DtoGroup>(newEntity));
        }

        public async Task<DtoResponseResult<IEnumerable<DtoGroup>>> GetAll()
        {
            var entities = await _unitOfWork.GroupRepository.GetAllAsync();

            return DtoResponseResult<IEnumerable<DtoGroup>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroup>>(entities));
        }

        public async Task<DtoResponseResult<DtoGroup>> GetById(int id)
        {
            var entity = await _unitOfWork.GroupRepository.FindAsync(g => g.Id == id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroup>.FailedResponse("Group not found");
            }

            return DtoResponseResult<DtoGroup>.CreateResponse(
                _mapper.Map<DtoGroup>(entity));
        }

        public async Task<DtoResponseResult<DtoGroup>> UpdateAsync(DtoGroup dto, int userId)
        {
            var entity = await _unitOfWork.GroupRepository.FindAsync(g => g.Id == dto.Id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroup>.FailedResponse("Group not found");
            }

            _mapper.Map(dto, entity);
            entity.UpdatedById = userId;
            entity.UpdatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupRepository.Update(entity, dto.Id);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroup>.CreateResponse(_mapper.Map<DtoGroup>(newEntity));
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var entity = await _unitOfWork.GroupRepository.FindAsync(g => g.Id == id);

            if (entity == null)
            {
                return DtoResponse.Failed("Group not found - task failed successfully");
            }

            _unitOfWork.GroupRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponse.Success();
        }
    }
}