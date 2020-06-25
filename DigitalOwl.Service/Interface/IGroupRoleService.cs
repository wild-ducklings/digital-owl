using System.Threading.Tasks;
using DigitalOwl.Service.Dto;
using DigitalOwl.Service.Dto.Base;

namespace DigitalOwl.Service.Interface
{
    public interface IGroupRoleService
    {
        Task<DtoResponseResult<string>> GetPoliceNameById(int id);
        Task<DtoResponseResult<int>> GeIdByName(string roleName);
    }
}