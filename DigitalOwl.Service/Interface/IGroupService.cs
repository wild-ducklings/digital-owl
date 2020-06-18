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
        /// Create Entity from Dto async
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user how create this object</param>
        /// <returns>Response that contains new crate object</returns>
        Task<DtoResponseResult<DtoGroup>> CreateAsync(DtoGroup dto, int userId);

        /// <summary>
        /// Method pull all items for db
        /// </summary>
        /// <returns>list of dto</returns>
        Task<DtoResponseResult<IEnumerable<DtoGroup>>> GetAll();
        Task<DtoResponseResult<DtoGroup>> GetById(int id);

        Task<DtoResponseResult<DtoGroup>> UpdateAsync(DtoGroup dto, int userId);

        Task<DtoResponse> Delete(int id);
    }
}