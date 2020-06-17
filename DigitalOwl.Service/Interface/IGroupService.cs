using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IGroupService
    {
        Task<DtoResponseResult<DtoGroup>> CreateAsync(DtoGroup dto, int userId);

        Task<DtoResponseResult<IEnumerable<DtoGroup>>> GetAll();
        Task<DtoResponseResult<DtoGroup>> GetById(int id);

        Task<DtoResponse> UpdateAsync(DtoGroup dto, int userId);

        Task<DtoResponse> Delete(int id);
    }
}