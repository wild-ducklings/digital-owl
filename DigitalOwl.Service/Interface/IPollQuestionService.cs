using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    /// <summary>
    /// Interface for PollQuestionService
    /// </summary>
    public interface IPollQuestionService
    {
        /// <summary>
        /// Create a single question.
        /// </summary>
        /// <param name="dto"> Object to be created. </param>
        /// <param name="userId"> Id of the user creating a question. </param>
        /// <returns> Created question. </returns>
        Task<DtoResponseResult<DtoPollQuestion>> CreateAsync(DtoPollQuestion dto, int userId);

        /// <summary>
        /// Create set of questions.
        /// </summary>
        /// <param name="collection"> List of questions to be created. </param>
        /// <param name="userId"> Id of the user creating list. </param>
        /// <returns> Created list of objects (dtos). </returns>
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
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating question. </param>
        /// <returns> Updated object (dto). </returns>
        Task<DtoResponseResult<DtoPollQuestion>> UpdateAsync(DtoPollQuestion dto, int userId);
        /// <summary>
        /// Delete the question of given Id.
        /// </summary>
        /// <param name="pollQuestionId">Id of question to be deleted.</param>
        /// <returns>Success/failure message.</returns>
        Task<DtoResponse> Delete(int pollQuestionId);
    }
}