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
    /// <summary>
    /// Group message service. 
    /// </summary>
    public class GroupMessageService : BaseService, IGroupMessageService
    {
        /// <summary>
        /// Group message constructor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public GroupMessageService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Create group message.
        /// </summary>
        /// <param name="dto"> Object to be created. </param>
        /// <param name="userId">Id of a user creating the message. </param>
        /// <returns> Response containing created object (dto). </returns>
        public async Task<DtoResponseResult<DtoGroupMessage>> CreateAsync(DtoGroupMessage dto, int userId)
        {
            var entity = _mapper.Map<GroupMessage>(dto);

            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupMessageRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroupMessage>.CreateResponse(_mapper.Map<DtoGroupMessage>(newEntity));
        }

        /// <summary>
        /// Find all messages from particular group.
        /// </summary>
        /// <param name="groupId"> Id of the group associated with requested messages. </param>
        /// <returns> Response containing requested messages (dtos). </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoGroupMessage>>> GetAllByGroupId(int groupId)
        {
            var entities = await _unitOfWork.GroupMessageRepository.FindAllAsync(gm => gm.GroupId == groupId);
            return DtoResponseResult<IEnumerable<DtoGroupMessage>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroupMessage>>(entities));
        }

        /// <summary>
        /// Find message of given id.
        /// </summary>
        /// <param name="id"> Id of the message. </param>
        /// <returns> Response containing requested message (dto). </returns>
        public async Task<DtoResponseResult<DtoGroupMessage>> GetById(int id)
        {
            var entity = await _unitOfWork.GroupMessageRepository.FindAsync(gm => gm.Id == id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMessage>.FailedResponse("Group Message not found");
            }

            return DtoResponseResult<DtoGroupMessage>.CreateResponse(_mapper.Map<DtoGroupMessage>(entity));
        }


        /// <summary>
        /// Update message of given id.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of a user updating message. </param>
        /// <returns> Response containing updated message (dto). </returns>
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

        /// <summary>
        /// Delete message of given id.
        /// </summary>
        /// <param name="id"> Message id. </param>
        /// <returns> Success/failure message. </returns>
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