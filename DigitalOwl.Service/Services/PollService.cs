using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    /// Poll service.
    /// </summary>
    public class PollService : BaseService, IPollService
    {
        /// <summary>
        /// PollService constructor.
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public PollService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork,
            mapper)
        {
        }
    
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        public async Task<DtoResponseResult<DtoPoll>> CreateAsync(DtoPoll dto, int userId)
        {
            var entity = _mapper.Map<Poll>(dto);
            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;
            entity.Points = 0;

            var entityResponse = _unitOfWork.PollRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPoll>.CreateResponse(
                _mapper.Map<DtoPoll>(entityResponse));
        }

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        public async Task<DtoResponseResult<IEnumerable<DtoPoll>>> GetAllIncluded()
        {
            var entities = _unitOfWork
                                .PollRepository.GetAll().AsQueryable().Include(p => p.PollQuestions)
                                .ThenInclude(q => q.QuestionAnswers);
            return DtoResponseResult<IEnumerable<DtoPoll>>.CreateResponse(
                _mapper.Map<IEnumerable<DtoPoll>>(entities));
        }

        /// <summary>
        /// Find a poll with given Id.
        /// </summary>
        /// <param name="pollId"> Poll Id.</param>
        /// <returns> Requested poll.</returns>
        public async Task<DtoResponseResult<DtoPoll>> GetById(int pollId)
        {
            var entity = await _unitOfWork.PollRepository.FindAsync(p => p.Id == pollId);
            if (entity == null)
                return DtoResponseResult<DtoPoll>.FailedResponse("Poll not found");
            return DtoResponseResult<DtoPoll>.CreateResponse(
                _mapper.Map<DtoPoll>(entity));
        }
        
        /// <summary>
        /// Find a poll with given Id including questions and answers.
        /// </summary>
        /// <param name="pollId"> Question Id.</param>
        /// <returns> One requested poll.</returns>
        public async Task<DtoResponseResult<DtoPoll>> GetByIdIncluded(int pollId)
        {
            var entity =  _unitOfWork.PollRepository.FindBy(p => p.Id == pollId).AsQueryable().Include(p => p.PollQuestions)
                                          .ThenInclude(q => q.QuestionAnswers).SingleOrDefault();
            if (entity == null)
                return DtoResponseResult<DtoPoll>.FailedResponse("Poll not found");
            return DtoResponseResult<DtoPoll>.CreateResponse(
                _mapper.Map<DtoPoll>(entity));
        }

        /// <summary>
        /// Updates a particular poll.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating poll. </param>
        /// <returns> Updated object (dto). </returns>
        public async Task<DtoResponseResult<DtoPoll>> UpdateAsync(DtoPoll dto, int userId)
        {
            var entity = await _unitOfWork.PollRepository.FindAsync(p => p.Id == dto.Id);

            if (entity == null)
                return DtoResponseResult<DtoPoll>.FailedResponse("Poll not found");

            _mapper.Map(dto, entity);
            entity.UpdatedDate = DateTime.UtcNow;
            entity.UpdatedById = userId;

            var entityResponse = _unitOfWork.PollRepository.Update(entity, dto.Id);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPoll>.CreateResponse(
                _mapper.Map<DtoPoll>(entityResponse));
        }

        /// <summary>
        /// Delete the poll of given Id.
        /// </summary>
        /// <param name="pollId">Id of a poll to be deleted.</param>
        /// <returns>Success/failure message.</returns>
        public async Task<DtoResponse> Delete(int pollId)
        {
            var entity = await _unitOfWork.PollRepository.FindAsync(p => p.Id == pollId);

            if (entity == null)
                return DtoResponse.Failed("Poll not found");

            _unitOfWork.PollRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponse.Success();
        }
    }
}