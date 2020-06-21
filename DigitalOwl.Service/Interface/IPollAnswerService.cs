using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IPollAnswerService
    {
        /// <summary>
        /// Create a single answer.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"> Id of the user creating an answer. </param>
        /// <returns> Created answer. </returns>
        Task<DtoResponseResult<DtoPollAnswer>> CreateAsync(DtoPollAnswer dto, int userId);

        /// <summary>
        /// Create set of answers.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> CreateAsync(
            IEnumerable<DtoPollAnswer> collection, int userId);

        /// <summary>
        /// Get whole answer set from the particular question.
        /// </summary>
        /// <param name="questionId"> Desired answers' question Id. </param>
        /// <returns> Set of particular answers. </returns>
        Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> GetAll(int questionId);

        /// <summary>
        /// Get all available answers (not sure if it's going to be useful).
        /// </summary>
        /// <returns> All available answers.</returns>
        Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> GetAll();

        /// <summary>
        /// Find an answer with given Id.
        /// </summary>
        /// <param name="answerId"> Answer Id.</param>
        /// <returns> One requested answer.</returns>
        Task<DtoResponseResult<DtoPollAnswer>> GetById(int answerId);

        /// <summary>
        /// Update given answer.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoResponseResult<DtoPollAnswer>> UpdateAsync(DtoPollAnswer dto, int userId);
        /// <summary>
        /// Delete the answer of given Id.
        /// </summary>
        /// <param name="answerId">Id of an answer to be deleted</param>
        /// <returns>Success/failure message.</returns>
        Task<DtoResponse> Delete(int answerId);
    }
}