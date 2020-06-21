using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services.Base;
using Microsoft.EntityFrameworkCore;

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
            entity.Points ??= 0;

            var entityResponse = _unitOfWork.PollQuestionRepository.Create(entity);

            var points = entity.Points;
            if (entityResponse != null && points != 0)
            {
                var poll = _unitOfWork.PollRepository.Get(entity.PollId);
                poll.Points += points;
                _unitOfWork.PollRepository.Update(poll, entity.PollId);
            }

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
                e.Points ??= 0;
            }

            var entitiesResponse = _unitOfWork.PollQuestionRepository.Create(entities);

            foreach (var e in entitiesResponse)
            {
                var points = e.Points;
                if (e != null && points != 0)
                {
                    var poll = _unitOfWork.PollRepository.Get(e.PollId);
                    poll.Points += points;
                    _unitOfWork.PollRepository.Update(poll, e.PollId);
                }
            }

            await _unitOfWork.SaveChangesAsync();

            return DtoResponseResult<IEnumerable<DtoPollQuestion>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollQuestion>>(entitiesResponse));
        }

        /// <summary>
        /// Get all available questions including answers(not sure if it's going to be useful).
        /// </summary>
        /// <returns> All available questions.</returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAllIncluded()
        {
            var entities = _unitOfWork.PollQuestionRepository.GetAll()
                                      .AsQueryable().Include(p => p.QuestionAnswers);
            return DtoResponseResult<IEnumerable<DtoPollQuestion>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollQuestion>>(entities));
        }

        /// <summary>
        /// Get whole question set from the particular poll including answers.
        /// </summary>
        /// <param name="pollId"> Desired questions' poll Id. </param>
        /// <returns> Set of particular poll questions. </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollQuestion>>> GetAllIncluded(
            int pollId)
        {
            var entities =
                _unitOfWork.PollQuestionRepository.FindBy(
                                p => p.PollId == pollId)
                           .AsQueryable().Include(p => p.QuestionAnswers);

            return DtoResponseResult<IEnumerable<DtoPollQuestion>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollQuestion>>(entities));
        }


        /// <summary>
        /// Find a question with given Id including answers.
        /// </summary>
        /// <param name="pollQuestionId"> Question Id.</param>
        /// <returns> One requested question.</returns>
        public async Task<DtoResponseResult<DtoPollQuestion>> GetByIdIncluded(int pollQuestionId)
        {
            var entity =
                _unitOfWork.PollQuestionRepository.FindBy(p =>
                                p.Id == pollQuestionId).AsQueryable()
                           .Include(p => p.QuestionAnswers).SingleOrDefault();

            if (entity == null)
                return DtoResponseResult<DtoPollQuestion>
                   .FailedResponse("Poll question not found");

            return DtoResponseResult<DtoPollQuestion>.CreateResponse(
                _mapper.Map<DtoPollQuestion>(entity));
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

            var points = entity.Points;
            _mapper.Map(dto, entity);
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedById = userId;

            var entityResponse = _unitOfWork.PollQuestionRepository.Update(entity, dto.Id);

            if (entityResponse != null && points != dto.Points && dto.Points != null)
            {
                var poll = _unitOfWork.PollRepository.Get(entity.PollId);
                poll.Points += dto.Points - points;
                _unitOfWork.PollRepository.Update(poll, entity.PollId);
            }

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

            if (entity.Points != 0)
            {
                var poll = _unitOfWork.PollRepository.Get(entity.PollId);
                poll.Points -= entity.Points;
                _unitOfWork.PollRepository.Update(poll, entity.PollId);
            }

            _unitOfWork.PollQuestionRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponse.Success();
        }
    }
}