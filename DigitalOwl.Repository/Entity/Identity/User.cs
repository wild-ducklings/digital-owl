using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DigitalOwl.Repository.Interface.Entity;
using Microsoft.AspNetCore.Identity;

namespace DigitalOwl.Repository.Entity.Identity
{
    public class User : IdentityUser<int>, IEntity
    {
        public string Role { get; set; }

        #region TimeStamps

        #endregion
    }
}