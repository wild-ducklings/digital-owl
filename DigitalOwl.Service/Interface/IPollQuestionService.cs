using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IPollQuestionService
    {
        /// <summary>
        /// Create Entity from Dto async
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user how create this object</param>
        /// <returns>Response that contains new crate object</returns>
        Task<DtoResponseResult<DtoPollQuestion>> CreateAsync(DtoPollQuestion dto, int userId);

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAll(int pollId);
        /// <summary>
        /// </summary>
        /// <returns></returns>
        // Less useful one, leaving it just in case.
        Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAll();

        Task<DtoResponseResult<DtoPollQuestion>> GetById(int pollQuestionId);

        Task<DtoResponseResult<DtoPollQuestion>> UpdateAsync(DtoPollQuestion dto, int userId);
        Task<DtoResponse> Delete(int questionId);
    }
}