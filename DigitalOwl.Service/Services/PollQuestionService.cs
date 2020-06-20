using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services.Base;

namespace DigitalOwl.Service.Services
{
    /// <summary>
    /// Poll question service.
    /// </summary>
    public class PollQuestionService : BaseService, IPollQuestionService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public PollQuestionService(IUnitOfWork unitOfWork, IMapper mapper) : base(
            unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Create a single question.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"> Id of the user creating a question. </param>
        /// <returns> Created question. </returns>
        public async Task<DtoResponseResult<DtoPollQuestion>> CreateAsync(
            DtoPollQuestion dto, int userId)
        {
            var entity = _mapper.Map<PollQuestion>(dto);
            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var entityResponse = _unitOfWork.PollQuestionRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPollQuestion>.CreateResponse(
                _mapper.Map<DtoPollQuestion>(entityResponse));
        }

        /// <summary>
        /// Create set of questions.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> CreateAsync(
            IEnumerable<DtoPollQuestion> collection, int userId)
        {
            var entities = _mapper.Map<IEnumerable<PollQuestion>>(collection);
            foreach (var e in entities)
            {
                e.CreatedById = userId;
                e.CreatedDate = DateTime.UtcNow;
            }

            var entitiesResponse = _unitOfWork.PollQuestionRepository.Create(entities);
            await _unitOfWork.SaveChangesAsync();
            
            return DtoResponseResult<IEnumerable<DtoPollQuestion>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollQuestion>>(entitiesResponse));
        }

        /// <summary>
        /// Get whole question set from the particular poll.
        /// </summary>
        /// <param name="pollId"> Desired questions' poll Id. </param>
        /// <returns> Set of particular poll questions. </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAll(int pollId)
        {
            var entities =
                await _unitOfWork.PollQuestionRepository.FindAllAsync(
                    p => p.PollId == pollId);

            return DtoResponseResult<IEnumerable<DtoPollQuestion>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollQuestion>>(entities));
        }

        /// <summary>
        /// Get all available questions (not sure if it's going to be useful).
        /// </summary>
        /// <returns> All available questions.</returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAll()
        {
            var entities = await _unitOfWork.PollQuestionRepository.GetAllAsync();
            return DtoResponseResult<IEnumerable<DtoPollQuestion>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollQuestion>>(entities));
        }

        /// <summary>
        /// Find a question with given Id.
        /// </summary>
        /// <param name="pollQuestionId"> Question Id.</param>
        /// <returns> One requested question.</returns>
        public async Task<DtoResponseResult<DtoPollQuestion>> GetById(int pollQuestionId)
        {
            var entity =
                await _unitOfWork.PollQuestionRepository.FindAsync(p =>
                    p.Id == pollQuestionId);
            if (entity == null)
                return DtoResponseResult<DtoPollQuestion>
                   .FailedResponse("Poll question not found");
            return DtoResponseResult<DtoPollQuestion>.CreateResponse(
                _mapper.Map<DtoPollQuestion>(entity));
        }

        /// <summary>
        /// Updates a particular question.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoResponseResult<DtoPollQuestion>> UpdateAsync(
            DtoPollQuestion dto, int userId)
        {
            var entity = await _unitOfWork.PollQuestionRepository.FindAsync(p => p.Id == dto.Id);

            if (entity == null)
                return DtoResponseResult<DtoPollQuestion>.FailedResponse("Poll question not found");

            _mapper.Map(dto, entity);
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedById = userId;

            var entityResponse = _unitOfWork.PollQuestionRepository.Update(entity, dto.Id);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPollQuestion>.CreateResponse(
                _mapper.Map<DtoPollQuestion>(entityResponse));
        }

        /// <summary>
        /// Delete the question of given Id.
        /// </summary>
        /// <param name="pollQuestionId">Id of question to be deleted</param>
        /// <returns>Success/failure message.</returns>
        public async Task<DtoResponse> Delete(int pollQuestionId)
        {
            var entity =
                await _unitOfWork.PollQuestionRepository.FindAsync(p => p.Id == pollQuestionId);

            if (entity == null)
                return DtoResponse.Failed("Poll question not found");

            _unitOfWork.PollQuestionRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponse.Success();
        }
    }
}