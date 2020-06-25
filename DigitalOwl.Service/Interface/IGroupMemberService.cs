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

        /// <summary>
        /// Find all group members of given group id.
        /// </summary>
        /// <param name="groupId"> Group id. </param>
        /// <returns> List of group members. </returns>
        Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAllByGroupId(int groupId);
        
        /// <summary>
        /// Checks if user of userId belongs to group with group Id.
        /// </summary>
        /// <param name="userId"> Id of requested user. </param>
        /// <param name="groupId"> Group id to check if particular user is assigned to it. </param>
        /// <returns> Requested group member. </returns>
        Task<DtoResponseResult<DtoGroupMember>> GetAllByGroupAndUserId(int userId, int groupId);

        /// <summary>
        /// Find the group member by given id.
        /// </summary>
        /// <param name="id"> Group member id.</param>
        /// <returns> One requested group member.</returns>
        Task<DtoResponseResult<DtoGroupMember>> GetById(int id);

        /// <summary>
        /// Updates a particular group member.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating group member. </param>
        /// <returns> Updated object (dto). </returns>
        Task<DtoResponseResult<DtoGroupMember>> UpdateAsync(DtoGroupMember dto, int userId);

        /// <summary>
        /// Remove the user of given id from group.
        /// </summary>
        /// <param name="id">Id of a group member to be deleted.</param>
        /// <returns>Success/failure message.</returns>
        Task<DtoResponse> Delete(int id);
    }
}