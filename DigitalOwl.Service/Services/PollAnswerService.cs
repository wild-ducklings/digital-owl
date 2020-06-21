using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services.Base;

namespace DigitalOwl.Service.Services
{
    /// <summary>
    /// Poll answer service.
    /// </summary>
    public class PollAnswerService : BaseService, IPollAnswerService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public PollAnswerService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        /// <summary>
        /// Create a single answer.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"> Id of the user creating an answer. </param>
        /// <returns> Created answer. </returns>
        public async Task<DtoResponseResult<DtoPollAnswer>> CreateAsync(DtoPollAnswer dto, int userId)
        {
            var entity = _mapper.Map<PollAnswer>(dto);
            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var entityResponse = _unitOfWork.PollAnswerRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPollAnswer>.CreateResponse(
                _mapper.Map<DtoPollAnswer>(entityResponse));
        }
        
        /// <summary>
        /// Create set of answers.
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> CreateAsync(IEnumerable<DtoPollAnswer> collection, int userId)
        {
            var entities = _mapper.Map<IEnumerable<PollAnswer>>(collection);
            foreach (var e in entities)
            {
                e.CreatedById = userId;
                e.CreatedDate = DateTime.UtcNow;
            }

            var entitiesResponse = _unitOfWork.PollAnswerRepository.Create(entities);
            await _unitOfWork.SaveChangesAsync();
            
            return DtoResponseResult<IEnumerable<DtoPollAnswer>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollAnswer>>(entitiesResponse));
        }

        /// <summary>
        /// Get whole answer set from the particular question.
        /// </summary>
        /// <param name="questionId"> Desired answers' question Id. </param>
        /// <returns> Set of particular answers. </returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> GetAll(int questionId)
        {
            var entities =
                await _unitOfWork.PollAnswerRepository.FindAllAsync(
                    p => p.PollQuestionId == questionId);

            return DtoResponseResult<IEnumerable<DtoPollAnswer>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollAnswer>>(entities));
        }
    
        /// <summary>
        /// Get all available answers (not sure if it's going to be useful).
        /// </summary>
        /// <returns> All available answers.</returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPollAnswer>>> GetAll()
        {
            var entities = await _unitOfWork.PollAnswerRepository.GetAllAsync();
            return DtoResponseResult<IEnumerable<DtoPollAnswer>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPollAnswer>>(entities));
        }

        /// <summary>
        /// Find an answer with given Id.
        /// </summary>
        /// <param name="pollAnswerId"> Answer Id.</param>
        /// <returns> One requested answer.</returns>
        public async Task<DtoResponseResult<DtoPollAnswer>> GetById(int pollAnswerId)
        {
            var entity =
                await _unitOfWork.PollAnswerRepository.FindAsync(p =>
                    p.Id == pollAnswerId);
            if (entity == null)
                return DtoResponseResult<DtoPollAnswer>
                   .FailedResponse("Answer not found");
            return DtoResponseResult<DtoPollAnswer>.CreateResponse(
                _mapper.Map<DtoPollAnswer>(entity));
        }

        /// <summary>
        /// Update given answer.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<DtoResponseResult<DtoPollAnswer>> UpdateAsync(DtoPollAnswer dto, int userId)
        {
            var entity = await _unitOfWork.PollAnswerRepository.FindAsync(p => p.Id == dto.Id);

            if (entity == null)
                return DtoResponseResult<DtoPollAnswer>.FailedResponse("Answer not found");

            _mapper.Map(dto, entity);
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedById = userId;

            var entityResponse = _unitOfWork.PollAnswerRepository.Update(entity, dto.Id);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPollAnswer>.CreateResponse(
                _mapper.Map<DtoPollAnswer>(entityResponse));
        }

        /// <summary>
        /// Delete the answer of given Id.
        /// </summary>
        /// <param name="answerId">Id of an answer to be deleted</param>
        /// <returns>Success/failure message.</returns>
        public async Task<DtoResponse> Delete(int answerId)
        {
            var entity =
                await _unitOfWork.PollAnswerRepository.FindAsync(p => p.Id == answerId);

            if (entity == null)
                return DtoResponse.Failed("Answer not found");

            _unitOfWork.PollAnswerRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponse.Success();
        }
    }
}