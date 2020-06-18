using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    /// <summary>
    /// Interface of Group Member Service
    /// </summary>
    public interface IGroupMemberService
    {
        /// <summary>
        /// Create Entity from Dto async
        /// </summary>
        /// <param name="dto">New object</param>
        /// <param name="userId">Id of user how create this object</param>
        /// <returns>Response that contains new crate object</returns>
        Task<DtoResponseResult<DtoGroupMember>> CreateAsync(DtoGroupMember dto, int userId);

        /// <summary>
        /// Method pull all items for db
        /// </summary>
        /// <returns>list of dto</returns>
        Task<DtoResponseResult<IEnumerable<DtoGroupMember>>> GetAll();

        Task<DtoResponseResult<DtoGroupMember>> GetById(int id);

        Task<DtoResponseResult<DtoGroupMember>> UpdateAsync(DtoGroupMember dto, int userId);

        Task<DtoResponse> Delete(int id);
    }
}