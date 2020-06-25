using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    /// <summary>
    /// Interface of Poll Service
    /// </summary>
    public interface IPollService
    {
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        Task<DtoResponseResult<DtoPoll>> CreateAsync(DtoPoll dto, int userId);

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        Task<DtoResponseResult<IEnumerable<DtoPoll>>> GetAllIncluded();

        /// <summary>
        /// Find a poll with given Id.
        /// </summary>
        /// <param name="pollId"> Poll Id.</param>
        /// <returns> Requested poll.</returns>
        Task<DtoResponseResult<DtoPoll>> GetById(int pollId);
        
        /// <summary>
        /// Find a poll with given Id including questions and answers.
        /// </summary>
        /// <param name="pollId"> Question Id.</param>
        /// <returns> One requested poll.</returns>
        Task<DtoResponseResult<DtoPoll>> GetByIdIncluded(int pollId);
        
        /// <summary>
        /// Updates a particular poll.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating poll. </param>
        /// <returns> Updated object (dto). </returns>
        Task<DtoResponseResult<DtoPoll>> UpdateAsync(DtoPoll dto, int userId);
        /// <summary>
        /// Delete the poll of given Id.
        /// </summary>
        /// <param name="pollId">Id of a poll to be deleted.</param>
        /// <returns>Success/failure message.</returns>
        Task<DtoResponse> Delete(int pollId);
        
        
    }
}