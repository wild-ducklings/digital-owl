using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IPollService
    {
        Task<DtoResponseResult<DtoPoll>> CreateAsync(DtoPoll dto, int userId);
        
        Task<DtoResponseResult<IEnumerable<DtoPoll>>> GetAll();
        Task<DtoResponseResult<DtoPoll>> GetById(int pollId);

        Task<DtoResponse> UpdateAsync(DtoPoll dto, int userId);
        Task<DtoResponse> Delete(int pollId);
    }
}