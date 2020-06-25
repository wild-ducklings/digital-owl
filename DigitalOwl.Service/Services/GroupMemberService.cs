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
    /// Group member service.
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
        /// Create Entity from Dto async.
        /// </summary>
        /// <param name="dto"> New object to be created. </param>
        /// <param name="userId"> Id of the user creating particular group member. </param>
        /// <returns> Response that contains created object (dto). </returns>
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
        /// Find all group members.
        /// </summary>
        /// <returns> List of group members (dto). </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAll()
        {
            var entities = await _unitOfWork.GroupMemberRepository.GetAllAsync();
            return DtoResponseResult<IEnumerable<DtoGroupMember>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroupMember>>(entities));
        }

        /// <summary>
        /// Find all group members of given group id.
        /// </summary>
        /// <param name="groupId"> Group id. </param>
        /// <returns> List of group members. </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAllByGroupId(int groupId)
        {
            var entities = await _unitOfWork.GroupMemberRepository.FindAllAsync(gm => gm.GroupId == groupId);
            return DtoResponseResult<IEnumerable<DtoGroupMember>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroupMember>>(entities));
        }

        /// <summary>
        /// Checks if user of userId belongs to group with group Id.
        /// </summary>
        /// <param name="userId"> Id of requested user. </param>
        /// <param name="groupId"> Group id to check if particular user is assigned to it. </param>
        /// <returns> Requested group member. </returns>
        public async Task<DtoResponseResult<DtoGroupMember>> GetAllByGroupAndUserId(
            int groupId, int userId)
        {
            var entity =
                await _unitOfWork.GroupMemberRepository.FindAsync(gm => gm.GroupId == groupId && gm.UserId == userId);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMember>.FailedResponse("Group Member not found");
            }

            return DtoResponseResult<DtoGroupMember>.CreateResponse(_mapper.Map<DtoGroupMember>(entity));
        }


        /// <summary>
        /// Find the group member by given id.
        /// </summary>
        /// <param name="id"> Group member id.</param>
        /// <returns> One requested group member.</returns>
        public async Task<DtoResponseResult<DtoGroupMember>> GetById(int id)
        {
            var entity = await _unitOfWork.GroupMemberRepository.FindAsync(gm => gm.Id == id);

            if (entity == null)
            {
                return DtoResponseResult<DtoGroupMember>.FailedResponse("Group Member not found");
            }

            return DtoResponseResult<DtoGroupMember>.CreateResponse(_mapper.Map<DtoGroupMember>(entity));
        }

        /// <summary>
        /// Updates a particular group member.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating group member. </param>
        /// <returns> Updated object (dto). </returns>
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

        
        /// <summary>
        /// Remove the user of given id from group.
        /// </summary>
        /// <param name="id">Id of a group member to be deleted.</param>
        /// <returns>Success/failure message.</returns>
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