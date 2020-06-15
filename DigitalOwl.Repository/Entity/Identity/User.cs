using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Interface.Entity;
using Microsoft.AspNetCore.Identity;

namespace DigitalOwl.Repository.Entity.Identity
{
    /// <summary>
    ///  Decorator for IdentityUser
    /// </summary>
    public class User : IdentityUser<int>, IEntity
    {
        /// <summary>
        ///  Temporary Role which allow user to do certain things 
        /// </summary>
        public string Role { get; set; }

        #region TimeStamps

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("CreatedBy")]
        public virtual IEnumerable<Group> GroupsCreated { get; set; }

        /// <summary>
        /// Inverse prop of TimeStamps
        /// </summary>
        [InverseProperty("UpdatedBy")]
        public virtual IEnumerable<Group> GroupsUpdated { get; set; }

        #endregion
    }
}