using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IPollAnswerService
    {
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        Task<DtoResponseResult<DtoPollAnswer>> CreateAsync(DtoPollAnswer dto, int userId);

        Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> CreateAsync(
            IEnumerable<DtoPollAnswer> collection, int userId);

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> GetAll(int pollId);

        /// <summary>
        /// </summary>
        /// <returns></returns>
        // Less useful one, leaving it just in case.
        Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> GetAll();

        Task<DtoResponseResult<DtoPollAnswer>> GetById(int pollQuestionId);

        Task<DtoResponseResult<DtoPollAnswer>> UpdateAsync(DtoPollAnswer dto, int userId);
        Task<DtoResponse> Delete(int questionId);
    }
}