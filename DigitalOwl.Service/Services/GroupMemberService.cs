using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services.Base;

namespace DigitalOwl.Service.Services
{
    /// <summary>
    /// group member service
    /// </summary>
    public class GroupMemberService : BaseService, IGroupMemberService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public GroupMemberService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Create Entity from Dto async
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user how create this object</param>
        /// <returns>Response that contains new crate object</returns>
        public async Task<DtoResponseResult<DtoGroupMember>> CreateAsync(DtoGroupMember dto, int userId)
        {
            var entity = _mapper.Map<GroupMember>(dto);

            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupMemberRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroupMember>.CreateResponse(_mapper.Map<DtoGroupMember>(newEntity));
        }

        /// <summary>
        /// Method pull all items for db
        /// </summary>
        /// <returns>list of dto</returns>
        public async Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAll()
        {
            var entities = await _unitOfWork.GroupMemberRepository.GetAllAsync();
            return DtoResponseResult<IEnumerable<DtoGroupMember>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroupMember>>(entities));
        }

        public async Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAllByGroupId(int groupId)
        {
            var entities = await _unitOfWork.GroupMemberRepository.FindAllAsync(gm => gm.GroupId == groupId);
            return DtoResponseResult<IEnumerable<DtoGroupMember>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroupMember>>(entities));
        }


        public async Task<DtoResponseResult<DtoGroupMember>> GetAllByGroupAndUserId(
            int userId, int groupId)
        {
            var entity =
                await _unitOfWork.GroupMemberRepository.FindAsync(gm => gm.GroupId == groupId && gm.UserId == userId);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMember>.FailedResponse("Group Member not found");
            }

            return DtoResponseResult<DtoGroupMember>.CreateResponse(_mapper.Map<DtoGroupMember>(entity));
        }


        public async Task<DtoResponseResult<DtoGroupMember>> GetById(int id)
        {
            var entity = await _unitOfWork.GroupMemberRepository.FindAsync(gm => gm.Id == id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMember>.FailedResponse("Group Member not found");
            }

            return DtoResponseResult<DtoGroupMember>.CreateResponse(_mapper.Map<DtoGroupMember>(entity));
        }

        public async Task<DtoResponseResult<DtoGroupMember>> UpdateAsync(DtoGroupMember dto, int userId)
        {
            var entity = await _unitOfWork.GroupMemberRepository.FindAsync(gm => gm.Id == dto.Id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMember>.FailedResponse("Group Member not found");
            }

            _mapper.Map(dto, entity);

            entity.UpdatedById = userId;
            entity.UpdatedDate = DateTime.UtcNow;

            var newEntity = _unitOfWork.GroupMemberRepository.Update(entity, dto.Id);
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroupMember>.CreateResponse(_mapper.Map<DtoGroupMember>(newEntity));
        }

        public async Task<DtoResponse> Delete(int id)
        {
            var entity = await _unitOfWork.GroupMemberRepository.FindAsync(g => g.Id == id);

            if (entity == null)
            {
                return DtoResponse.Failed("Group Member not found - task failed successfully");
            }

            _unitOfWork.GroupMemberRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            
            return DtoResponse.Success();
        }
    }
}