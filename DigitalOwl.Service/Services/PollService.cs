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
    public class PollService : BaseService, IPollService
    {
        public PollService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<DtoResponseResult<DtoPoll>> CreateAsync(DtoPoll dto, int userId)
        {
            var entity = _mapper.Map<Poll>(dto);
            entity.CreatedById = userId;
            entity.CreatedDate = DateTime.UtcNow;

            var entityResponse = _unitOfWork.PollRepository.Create(entity);
            await _unitOfWork.SaveChangesAsync();
            return DtoResponseResult<DtoPoll>.CreateResponse(_mapper.Map<DtoPoll>(entityResponse));
        }

        public async Task<DtoResponseResult<IEnumerable<DtoPoll>>> GetAll()
        {
            var entities = await _unitOfWork.PollRepository.GetAllAsync();
            return DtoResponseResult<IEnumerable<DtoPoll>>.CreateResponse(_mapper.Map<IEnumerable<DtoPoll>>(entities));
        }

        public async Task<DtoResponseResult<DtoPoll>> GetById(int pollId)
        {
            var entity = await _unitOfWork.PollRepository.FindAsync(p => p.Id == pollId);
            if (entity == null)
                return DtoResponseResult<DtoPoll>.FailedResponse("Poll not found");
            return DtoResponseResult<DtoPoll>.CreateResponse(_mapper.Map<DtoPoll>(entity));
        }

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
            return DtoResponseResult<DtoPoll>.CreateResponse(_mapper.Map<DtoPoll>(entityResponse));
        }

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