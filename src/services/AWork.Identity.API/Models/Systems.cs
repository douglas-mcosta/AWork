using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace AWork.Identity.API.Models
{
    public class System
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IsActive { get; set; }
    }
    public class UserSystems
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<UserSystemEntities> UserSystemEntities { get; set; }
    }

    public class UserSystemEntities
    {
        public Guid UserId { get; set; }
        public Guid EntityId { get; set; }
        public Guid UserSystemsId { get; set; }

        //EF
        public UserSystems UserSystems { get; set; }
        public IdentityUser User { get; set; }
        public Entity Entity { get; set; }
    }
}
