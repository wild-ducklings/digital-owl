using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    /// <summary>
    /// Interface of Group Member Service
    /// </summary>
    public interface IGroupMemberService
    {
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        Task<DtoResponseResult<DtoGroupMember>> CreateAsync(DtoGroupMember dto, int userId);

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAll();

        Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAllByGroupId(int groupId);
        Task<DtoResponseResult<DtoGroupMember>> GetAllByGroupAndUserId(int groupId, int userId);

        Task<DtoResponseResult<DtoGroupMember>> GetById(int id);

        Task<DtoResponseResult<DtoGroupMember>> UpdateAsync(DtoGroupMember dto, int userId);

        Task<DtoResponse> Delete(int id);
    }
}