using Microsoft.AspNetCore.Identity;
using System;

namespace LandonAPI.Models
{
    public class UserRoleEntity : IdentityRole<Guid>
    {
        public UserRoleEntity()
            : base()
        { }

        public UserRoleEntity(string roleName)
            : base(roleName)
        { }

        public string RoleName { get; private set; }
    }
}
