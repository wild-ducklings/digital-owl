using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IPollQuestionService
    {
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        Task<DtoResponseResult<DtoPollQuestion>> CreateAsync(DtoPollQuestion dto, int userId);

        /// <summary>
        /// Create set of questions.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> CreateAsync(
            IEnumerable<DtoPollQuestion> collection, int userId);

        /// <summary>
        /// Get all available questions including answers(not sure if it's going to be useful).
        /// </summary>
        /// <returns> All available questions.</returns>
        Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAllIncluded();

        /// <summary>
        /// Get whole question set from the particular poll including answers.
        /// </summary>
        /// <param name="pollId"> Desired questions' poll Id. </param>
        /// <returns> Set of particular poll questions. </returns>
        Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAllIncluded(
            int pollId);

        /// <summary>
        /// Find a question with given Id including answers.
        /// </summary>
        /// <param name="pollQuestionId"> Question Id.</param>
        /// <returns> One requested question.</returns>
        Task<DtoResponseResult<DtoPollQuestion>> GetByIdIncluded(int pollQuestionId);
        
        /// <summary>
        /// Find a question with given Id.
        /// </summary>
        /// <param name="pollQuestionId"> Question Id.</param>
        /// <returns> One requested question.</returns>
        Task<DtoResponseResult<DtoPollQuestion>> GetById(int pollQuestionId);

        /// <summary>
        /// Updates a particular question.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<DtoResponseResult<DtoPollQuestion>> UpdateAsync(DtoPollQuestion dto, int userId);
        /// <summary>
        /// Delete the question of given Id.
        /// </summary>
        /// <param name="questionId">Id of question to be deleted</param>
        /// <returns>Success/failure message.</returns>
        Task<DtoResponse> Delete(int questionId);
    }
}