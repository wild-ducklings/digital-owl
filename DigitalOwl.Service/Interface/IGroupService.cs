using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    
    /// <summary>
    /// Interface of Group Service
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        Task<DtoResponseResult<DtoGroup>> CreateAsync(DtoGroup dto, int userId);

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        Task<DtoResponseResult<IEnumerable<DtoGroup>>> GetAll();
        Task<DtoResponseResult<DtoGroup>> GetById(int id);

        Task<DtoResponseResult<DtoGroup>> UpdateAsync(DtoGroup dto, int userId);

        Task<DtoResponse> Delete(int id);
    }
}