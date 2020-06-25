using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    /// <summary>
    /// Interface for GroupMessageService.
    /// </summary>
    public interface IGroupMessageService
    {
        /// <summary>
        /// Create group message.
        /// </summary>
        /// <param name="dto"> Object to be created. </param>
        /// <param name="userId">Id of a user creating the message. </param>
        /// <returns> Response containing created object (dto). </returns>
        Task<DtoResponseResult<DtoGroupMessage>> CreateAsync(DtoGroupMessage dto, int userId);
        /// <summary>
        /// Find all messages from particular group.
        /// </summary>
        /// <param name="groupId"> Id of the group associated with requested messages. </param>
        /// <returns> Response containing requested messages (dtos). </returns>
        Task<DtoResponseResult<IEnumerable<DtoGroupMessage>>> GetAllByGroupId(int groupId);
        /// <summary>
        /// Find message of given id.
        /// </summary>
        /// <param name="id"> Id of the message. </param>
        /// <returns> Response containing requested message (dto). </returns>
        Task<DtoResponseResult<DtoGroupMessage>> GetById(int id);
        /// <summary>
        /// Update message of given id.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of a user updating message. </param>
        /// <returns> Response containing updated message (dto). </returns>
        Task<DtoResponseResult<DtoGroupMessage>> UpdateAsync(DtoGroupMessage dto, int userId);
        /// <summary>
        /// Delete message of given id.
        /// </summary>
        /// <param name="id"> Message id. </param>
        /// <returns> Success/failure message. </returns>
        Task<DtoResponse> Delete(int id);
    }
}