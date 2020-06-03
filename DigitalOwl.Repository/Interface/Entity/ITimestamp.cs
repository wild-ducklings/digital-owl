using System;
using DigitalOwl.Repository.Entity.Identity;

namespace DigitalOwl.Repository.Interface.Entity
{
    public interface ITimestamp
    {
        int CreatedById { get; set; }
        User CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int? UpdatedById { get; set; }
        User UpdatedBy { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}