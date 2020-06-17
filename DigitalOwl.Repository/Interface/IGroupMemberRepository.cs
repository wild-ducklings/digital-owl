using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface.Base;

namespace DigitalOwl.Repository.Interface
{
    /// <summary>
    /// Interface to GroupRepository 
    /// </summary>
    public interface IGroupMemberRepository : IGenericRepository<GroupMember>
    {
        
    }
}