using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    /// <summary>
    /// Interface of Poll Service
    /// </summary>
    public interface IPollService
    {
        /// <summary>
        /// Create Entity from Dto asynchronously.
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user creating this particular object.</param>
        /// <returns>Response that contains new created object.</returns>
        Task<DtoResponseResult<DtoPoll>> CreateAsync(DtoPoll dto, int userId);

        /// <summary>
        /// Pull all items form the database.
        /// </summary>
        /// <returns>List of Dtos</returns>
        Task<DtoResponseResult<IEnumerable<DtoPoll>>> GetAll();

        Task<DtoResponseResult<DtoPoll>> GetById(int pollId);

        Task<DtoResponseResult<DtoPoll>> UpdateAsync(DtoPoll dto, int userId);
        Task<DtoResponse> Delete(int pollId);
    }
}