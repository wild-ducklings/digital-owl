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
    /// Group Service.
    /// </summary>
    public class GroupService : BaseService, IGroupService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public GroupService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Create group.
        /// </summary>
        /// <param name="dto"> Object to be created. </param>
        /// <param name="userId"> Id of the user creating group. </param>
        /// <returns> Response containing created object. </returns>
        public async Task<DtoResponseResult<DtoGroup>> CreateAsync(DtoGroup dto, int userId)
        {
            var entity = _mapper.Map<Group>(dto);
            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;


            var newEntity = _unitOfWork.GroupRepository.Create(entity);

            
            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<DtoGroup>.CreateResponse(_mapper.Map<DtoGroup>(newEntity));
        }

        /// <summary>
        /// Find all groups.
        /// </summary>
        /// <returns> Response containing list of DtoGroup. </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoGroup>>> GetAll()
        {
            var entities = await _unitOfWork.GroupRepository.GetAllAsync();

            return DtoResponseResult<IEnumerable<DtoGroup>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoGroup>>(entities));
        }

        /// <summary>
        /// Find group of given id.
        /// </summary>
        /// <param name="id"> Id of requested group. </param>
        /// <returns> Response containing requested group. </returns>
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

        /// <summary>
        /// Update particular group.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating group. </param>
        /// <returns> Response containing created group (dto). </returns>
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

        /// <summary>
        /// Delete the group of given id.
        /// </summary>
        /// <param name="id"> Group id. </param>
        /// <returns> Success/failure message. </returns>
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