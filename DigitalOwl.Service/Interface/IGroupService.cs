using System.Collections.Generic;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    
    /// <summary>
    /// Interface for GroupService.
    /// </summary>
    public interface IGroupService
    {
        /// <summary>
        /// Create group.
        /// </summary>
        /// <param name="dto"> Object to be created. </param>
        /// <param name="userId"> Id of the user creating group. </param>
        /// <returns> Response containing created object. </returns>
        Task<DtoResponseResult<DtoGroup>> CreateAsync(DtoGroup dto, int userId);

        /// <summary>
        /// Find all groups.
        /// </summary>
        /// <returns> Response containing list of DtoGroup. </returns>
        Task<DtoResponseResult<IEnumerable<DtoGroup>>> GetAll();
        
        /// <summary>
        /// Find group of given id.
        /// </summary>
        /// <param name="id"> Id of requested group. </param>
        /// <returns> Response containing requested group. </returns>
        Task<DtoResponseResult<DtoGroup>> GetById(int id);

        /// <summary>
        /// Update particular group.
        /// </summary>
        /// <param name="dto"> Updated version of an object. </param>
        /// <param name="userId"> Id of the user updating group. </param>
        /// <returns> Response containing created group (dto). </returns>
        Task<DtoResponseResult<DtoGroup>> UpdateAsync(DtoGroup dto, int userId);

        /// <summary>
        /// Delete the group of given id.
        /// </summary>
        /// <param name="id"> Group id. </param>
        /// <returns> Success/failure message. </returns>
        Task<DtoResponse> Delete(int id);
    }
}