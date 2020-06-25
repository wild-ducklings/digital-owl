using System.Threading.Tasks;
using AutoMapper;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Service.Dto.Base;
using DigitalOwl.Service.Interface;
using DigitalOwl.Service.Services.Base;

namespace DigitalOwl.Service.Services
{
    /// <summary>
    /// Group Role Service
    /// </summary>
    public class GroupRoleService : BaseService, IGroupRoleService
    {
        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        public GroupRoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<DtoResponseResult<string>> GetPoliceNameById(int id)
        {
            
            // TODO error checking
            var role = await _unitOfWork.GroupRoleRepository.FindAsync(g => g.Id == id);
            // TODO error checking
            var police = await _unitOfWork.GroupPoliceRepository.FindAsync(g => g.Id == role.GroupPoliceId);
            return DtoResponseResult<string>.CreateResponse(police.Name);
        }

        public async Task<DtoResponseResult<int>> GeIdByName(string roleName)
        {
            // TODO error checking
            var role = await _unitOfWork.GroupRoleRepository.FindAsync(g => g.Name == roleName);
            return DtoResponseResult<int>.CreateResponse(role.Id);
        }
    }
}