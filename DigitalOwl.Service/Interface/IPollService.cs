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
        /// Create Entity from Dto async
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user how create this object</param>
        /// <returns>Response that contains new crate object</returns>
        Task<DtoResponseResult<DtoPoll>> CreateAsync(DtoPoll dto, int userId);

        /// <summary>
        /// Method pull all items for db
        /// </summary>
        /// <returns>list of dto</returns>
        Task<DtoResponseResult<IEnumerable<DtoPoll>>> GetAll();

        Task<DtoResponseResult<DtoPoll>> GetById(int pollId);

        Task<DtoResponseResult<DtoPoll>> UpdateAsync(DtoPoll dto, int userId);
        Task<DtoResponse> Delete(int pollId);
    }
}