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
    public class GroupMessageService : BaseService, IGroupMessageService
    {
        public GroupMessageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<DtoResponseResult<DtoGroupMessage>> CreateAsync(DtoGroupMessage dto, int userId)
        {
            var entity = _mapper.Map<GroupMessage>(dto);

            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupMessageRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroupMessage>.CreateResponse(_mapper.Map<DtoGroupMessage>(newEntity));
        }

        public async Task<DtoResponseResult<IEnumerable<DtoGroupMessage>>> GetAllByGroupId(int groupId)
        {
            var entities = await _unitOfWork.GroupMessageRepository.FindAllAsync(gm => gm.GroupId == groupId);
            return DtoResponseResult<IEnumerable<DtoGroupMessage>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroupMessage>>(entities));
        }

        public async Task<DtoResponseResult<DtoGroupMessage>> GetById(int id)
        {
            var entity = await _unitOfWork.GroupMessageRepository.FindAsync(gm => gm.Id == id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMessage>.FailedResponse("Group Message not found");
            }

            return DtoResponseResult<DtoGroupMessage>.CreateResponse(_mapper.Map<DtoGroupMessage>(entity));
        }


        public async Task<DtoResponseResult<DtoGroupMessage>> UpdateAsync(DtoGroupMessage dto, int userId)
        {
            var entity = await _unitOfWork.GroupMessageRepository.FindAsync(gm => gm.Id == dto.Id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMessage>.FailedResponse("Group Message not found");
            }

            _mapper.Map(dto, entity);

            entity.UpdatedById = userId;
            entity.UpdatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupMessageRepository.Update(entity, dto.Id);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroupMessage>.CreateResponse(_mapper.Map<DtoGroupMessage>(newEntity));
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var entity = await _unitOfWork.GroupMessageRepository.FindAsync(g => g.Id == id);

            if (entity == null)
            {
                return DtoResponse.Failed("Group Message not found - task failed successfully");
            }

            _unitOfWork.GroupMessageRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponse.Success();
        }
    }
}