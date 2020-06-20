using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IGroupMessageService
    {
        Task<DtoResponseResult<DtoGroupMessage>> CreateAsync(DtoGroupMessage dto, int userId);
        Task<DtoResponseResult<IEnumerable<DtoGroupMessage>>> GetAllByGroupId(int groupId);
        Task<DtoResponseResult<DtoGroupMessage>> GetById(int id);
        Task<DtoResponseResult<DtoGroupMessage>> UpdateAsync(DtoGroupMessage dto, int userId);
        Task<DtoResponse> Delete(int id);
    }
}