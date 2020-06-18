using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface.Base;

namespace DigitalOwl.Repository.Interface
{
    /// <summary>
    /// Poll question repository interface.
    /// </summary>
    public interface IPollQuestionRepository : IGenericRepository<PollQuestion>
    {
    }
}